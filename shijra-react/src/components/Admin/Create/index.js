import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import { compose } from 'recompose';

import { withFirebase } from '../../Firebase';
import { Form, Button } from 'react-bootstrap'

const CreatePage = () => (
    <div style={{ width: '50%', margin: 'auto', marginTop: '100px' }}>
        <CreateForm />
    </div>
);

const INITIAL_STATE = {
    name: "",
    urduName: "",
    error: null,
    // options: [],
    // fathers: {},
    fatherName: "Select a father",
    fatherId: "none",
    gender: 1,
    children: []
};

class CreateFormBase extends Component {
    constructor(props) {
        super(props);

        this.state = { ...INITIAL_STATE, options: [], fathers: {} };

    }

    componentDidMount() {

        this.props.firebase.getAllMale().on('value', snapshot => {
            var options = [{ value: "none", label: "Select a Father" }];
            var fathers = {};
            Object.keys(snapshot.val()).forEach(id => {
                // console.log("id", id);
                var p = snapshot.val()[id];
                // p.id = id;
                fathers[id] = p;
                var label = "";
                if (p.father !== undefined) {
                    var fatherId = Object.keys(p.father)[0];
                    label = p.name + ' s/o ' + p.father[fatherId].name;
                } else {
                    label = p.name;
                }
                var option = { value: id, label: label }
                options.push(option);
            });
            this.setState({ options: options, fathers: fathers });
        });
    }

    onSubmit = event => {
        const { name, urduName, fatherId, gender, fathers } = this.state;
        // console.log(name, urduName, fatherId, gender);
        if (name !== null && name.trim() !== "" && urduName !== null && urduName.trim() !== "" && fatherId !== null && fatherId !== "none") {
            console.log("submit");
            var father = fathers[fatherId];
            delete father["children"];
            delete father["father"];
            this.props.firebase
                .addPerson(name, urduName, gender, fatherId, father)
                .then((person) => {
                    console.log(person.key);
                    return this.props.firebase.addChild(person.key, name, urduName, gender, fatherId);
                    // console.log(person);
                })
                .then(() => {
                    alert("Record has been added successfully");
                    this.setState({ ...INITIAL_STATE });
                })
                .catch(error => {
                    this.setState({ error });
                });
        } else {
            alert("Please submit valid values. Father must be selected and names cannot be empty");
        }


        event.preventDefault();
    };

    onChange = event => {
        // console.log(event.target.name, event.target.value);
        this.setState({ [event.target.name]: event.target.value });

        if (event.target.name === "fatherId") {

            if (event.target.value === 'none') {
                this.setState({ "children": [] });
            } else {

                this.props.firebase.person(event.target.value).on('value', snapshot => {
                    var father = snapshot.val();
                    var children = [];
                    if (father.children !== undefined && father.children !== null) {
                        // console.log(father.children);
                        Object.keys(father.children).forEach(id => {
                            var child = father.children[id];
                            child.id = id;
                            children.push(child);
                        });
                    }
                    this.setState({ "children": children });
                });
            }
        }
    };

    onGenderClick(val) {
        this.setState({ gender: val });
    }

    onDelete(id) {
        // alert(id);
        const { children } = this.state;
        var updatedChildren = children.filter((child) => {
            return child.id !== id;
        })

        this.setState({ "children": updatedChildren });
        // console.log(updatedChildren);
    }

    render() {
        const { name, urduName, gender, fatherId, error } = this.state;

        // const isInvalid = password === '' || email === '';

        return (
            <div>
                <div style={{ marginBottom: '20px' }}><h3>Add New Record</h3></div>
                < Form onSubmit={this.onSubmit} >

                    <Form.Group controlId="fatherId">
                        <Form.Label>Father</Form.Label>
                        <Form.Control as="select" name="fatherId" onChange={this.onChange} value={fatherId}>
                            {this.state.options.map(({ value, label }, index) => <option key={index} value={value} >{label}</option>)}
                        </Form.Control>
                    </Form.Group>
                    {this.state.children.length > 0 && <ul style={{ border: '1px solid #ced4da', padding: '10px 40px' }}>
                        {this.state.children.map((child) => <li key={child.id}>{child.name}</li>)}
                    </ul>}
                    <Form.Group controlId="name">
                        <Form.Label>Name</Form.Label>
                        <Form.Control type="text" name="name" placeholder="Type here" onChange={this.onChange} value={name} />
                    </Form.Group>
                    <Form.Group controlId="urduname">
                        <Form.Label>Urdu Name</Form.Label>
                        <Form.Control type="text" name="urduName" placeholder="Type here" onChange={this.onChange} value={urduName} />
                    </Form.Group>
                    <Form.Group>
                        <Form.Check inline label="Male" type="radio" name="gender" value={1} checked={gender === 1 ? true : false} onChange={() => { this.onGenderClick(1) }} />
                        <Form.Check inline label="Female" type="radio" name="gender" value={0} checked={gender === 0 ? true : false} onChange={() => { this.onGenderClick(0) }} />
                    </Form.Group>

                    <Button variant="dark" type="submit">
                        Submit
                    </Button>
                </Form >
            </div>

        );
    }
}

const CreateForm = compose(
    withRouter,
    withFirebase,
    // withAuthorization(condition)
)(CreateFormBase);

export default CreatePage;
