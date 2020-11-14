import React, { Component } from 'react';

// import { withAuthorization } from '../Session';

import { withFirebase } from '../Firebase';

import Tree from 'react-d3-tree';
import { Spinner } from 'react-bootstrap'

import './shijra.css';

var _ = require('lodash');

// var textWidth = require('text-width');


class ShijraPage extends Component {

    constructor(props) {
        super(props);

        this.state = {
            loading: false,
            person: {},
            children: [],
            persons: []
        };
    }

    componentDidMount() {

        const dimensions = this.treeContainer.getBoundingClientRect();
        this.setState({
            loading: true,
            translate: {
                x: dimensions.width / 2,
                y: (dimensions.height / 2) - 200
            }
        });

        this.getAllMale();
    }

    createPersonData(person) {
        // console.log("person data", person);
        return { key: person.id, name: person.name, urduName: person.urduName, gender: person.gender, isRoot: person.isRoot, _collapsed: person.collapsed };
    }

    loadData(id) {
        if (id === undefined) {
            this.setState({ father: undefined });
            return;
        }

        this.loadParentTree(id).then(father => {
            this.setState({ father: father });
        });

    }

    loadParentTree(id) {
        return new Promise((resolveTree, rejectTree) => {

            this.props.firebase.person(id).on('value', snapshot => {
                // console.log("id", id);
                var p = snapshot.val();
                p.id = snapshot.key;

                if (p.father !== undefined) {
                    var fatherId = Object.keys(p.father)[0];
                    this.props.firebase.person(fatherId).on('value', fSnapshot => {
                        var f = fSnapshot.val();
                        f.id = fSnapshot.key;
                        f.isRoot = true;
                        var father = this.createPersonData(f);
                        father.children = [];
                        var promisses = [];
                        if (f.children !== undefined) {
                            father.childrenCount = Object.keys(f.children).length;
                            Object.keys(f.children).forEach(pid => {

                                promisses.push(new Promise((resolve, reject) => {

                                    this.props.firebase.person(pid).on('value', pSnapshot => {
                                        var person = pSnapshot.val();
                                        person.id = pSnapshot.key;
                                        person.collapsed = person.id !== id;
                                        // person.isRoot = false;
                                        var child = this.createPersonData(person);

                                        child.children = [];
                                        if (person.children !== undefined) {
                                            child.childrenCount = Object.keys(person.children).length;
                                            Object.keys(person.children).forEach(cid => {
                                                person.children[cid]['id'] = cid;
                                                // person.children[cid]['isRoot'] = false;
                                                child.children.push(this.createPersonData(person.children[cid]));
                                            });
                                        } else if (child.gender === 1) {
                                            child.childrenCount = 0;
                                        }

                                        father.children.push(child);
                                        resolve();
                                    });
                                }));

                                Promise.all(promisses).then(() => {
                                    // this.setState({ father: father });
                                    // console.log("Father", father);
                                    resolveTree(father);
                                });

                            })
                        }
                    });
                }
            });

        });
    }

    loadParent(personId) {
        const { father } = this.state;
        this.loadParentTree(personId).then(fatherTree => {
            fatherTree.children.map((value, index) => {
                if (value.key === personId) {
                    father.isRoot = false;
                    fatherTree.children[index] = father;
                }
                return true;
            });

            console.log("With new parent: ", fatherTree);
            this.setState({ father: undefined });
            setTimeout(() => {
                this.setState({ father: fatherTree });
            }, 0);

        });
    }

    loadChildren(parentId) {
        const { father } = this.state;
        this.props.firebase.person(parentId).on('value', pSnapshot => {
            var person = pSnapshot.val();
            var children = [];
            if (person.children !== undefined) {
                Object.keys(person.children).forEach(cid => {
                    person.children[cid]['id'] = cid;
                    children.push(this.createPersonData(person.children[cid]));
                })
            }

            // assign to correct parent
            this.formatData([father], parentId, children);

            this.setState({ father: undefined });
            setTimeout(() => {
                this.setState({ father: father });
            }, 0);

            // console.log("father updated", father);
        });
    }

    formatData(arr, value, children) {
        arr.forEach(i => {
            if (i.key === value) {

                arr.forEach(o => {
                    o._collapsed = true;
                });

                i.children = children;
                i.childrenCount = children.length;
                i._collapsed = false;
            } else {

                if (i.children !== undefined)
                    this.formatData(i.children, value, children)
            }
        });

        // console.log("father updated", arr);
    }

    render() {
        const { persons, father } = this.state;
        // console.log("render father", father);
        const svgSquare = {
            shape: 'rect',
            shapeProps: {
                width: 230,
                height: 120,
                x: -115,
                rx: 20,
                y: -80,
            }
        }
        // console.log("render", persons);

        return (
            <div id='main' style={{ display: 'flex' }}>
                <div style={{ width: '20%', height: '92vh', overflow: 'scroll', backgroundColor: 'gray' }}>
                    {this.RenderList(persons)}
                </div>
                <div style={{ width: '80%', textAlign: 'center', paddingTop: '20px', backgroundColor: 'white' }}
                    ref={tc => (this.treeContainer = tc)}>
                    {
                        father !== undefined &&

                        <Tree data={father}
                            orientation='vertical'
                            separation={{ siblings: 1.8, nonsiblings: 4 }}
                            pathFunc={'step'}
                            nodeSvgShape={svgSquare}
                            translate={this.state.translate}
                            shouldCollapseNeighborNodes={true}
                            zoom={0.75}
                            // textLayout={{ x: -90, y: 20 }}
                            useCollapseData={true}
                            allowForeignObjects
                            nodeLabelComponent={{
                                render: <NodeLabel parent={this} />,
                                foreignObjectWrapper: {
                                    width: 230,
                                    x: -114,
                                    height: 119,
                                    y: -69
                                }
                            }}
                        />
                    }
                </div>
            </div >
        );
    }

    getAllMale() {
        this.props.firebase.getAllMale().on('value', snapshot => {
            var persons = [];
            Object.keys(snapshot.val()).forEach(id => {
                // console.log("id", id);
                var p = snapshot.val()[id];
                p.id = id;
                persons.push(p);
            });
            this.setState({ persons: persons });
        });
    }

    getMale(term) {
        var newTerm = term.split(' ').map(str => {
            return _.capitalize(str);
        }).join(' ');
        this.props.firebase.getMale(newTerm).on('value', snapshot => {
            console.log(snapshot.val());
            if (snapshot.val() !== null) {
                var persons = [];
                Object.keys(snapshot.val()).forEach(id => {
                    // console.log("id", id);
                    var p = snapshot.val()[id];
                    // if (p.gender === 1) {
                    p.id = id;
                    persons.push(p);
                    // }
                });
                console.log(persons.length);
                this.setState({ persons: persons });
            }
        });
    }

    filterPersons(e) {
        // console.log(this);

        if (e.target.value === "") {
            this.getAllMale();
        }
        else {
            this.getMale(e.target.value);
        }
    }

    RenderList(persons) {
        return (
            <div >
                <div className="searchContainer">
                    <input onChange={(e) => this.filterPersons(e)}></input>
                </div>
                {
                    (persons === undefined || persons.length === 0) &&
                    <div style={{ textAlign: 'center', marginTop: '200px' }}>
                        < Spinner animation="border" />
                    </div>
                }
                {
                    // console.log(param.persons)
                    persons.map((value, index) => {
                        // return <RenderListItem key={index} person={value}></RenderListItem>
                        return this.RenderListItem({ key: index, person: value });
                    })
                }
            </div>
        );
    }

    RenderListItem(param) {
        var altClass = param.key % 2 === 0 ? 'listItem alternateListItem' : 'listItem'
        return (
            <div key={param.person.id} className={altClass} onClick={() => this.selectPerson(param.person.id)}>
                {/* <div style={{ fontSize: '12px' }}>{param.person.id}</div> */}
                <div style={{ fontSize: '12px' }}>{param.person.name}</div>
                <div style={{ fontSize: '12px' }}>{param.person.urduName}</div>
            </div>
        );
    }

    selectPerson(id) {
        // this.setState({ id: id });
        this.loadData(id);
    }

}

class NodeLabel extends React.PureComponent {
    render() {
        const { nodeData, parent } = this.props;
        var bgColor = nodeData.gender === 0 ? 'pink' : 'lightblue';
        // if (nodeData.key === '-MKZb9MqVJ3x9efL9Pcx')
        // console.log("conditonal", nodeData);

        return <div className="nodeContainer" style={{ backgroundColor: bgColor }}>

            {
                nodeData.isRoot && nodeData.key !== "-MKZb7gR9XPdOeLr6eOl" && // Qusai key
                <div className="node root"
                    onClick={() => { parent.loadParent(nodeData.key) }}>
                    ▲
                </div>
            }
            {
                (nodeData.childrenCount !== undefined && nodeData.childrenCount > 0) &&
                <div className="node nonroot">
                    {nodeData.childrenCount}
                </div>
            }
            {
                (nodeData.childrenCount === undefined && nodeData.gender === 1) &&
                <div className="node nonroot leaf"
                    onClick={() => { parent.loadChildren(nodeData.key) }}>
                    ?
                </div>
            }
            <div>
                {nodeData.name}
            </div>

            <div>
                {nodeData.urduName}
            </div>

        </div >
    }


}

export default withFirebase(ShijraPage);