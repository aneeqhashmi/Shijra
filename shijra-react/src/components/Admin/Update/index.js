import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import { compose } from 'recompose';

import { withFirebase } from '../../Firebase';
import { Form, Button } from 'react-bootstrap'

const UpdatePage = () => (
    <div style={{ width: '50%', margin: 'auto', marginTop: '100px' }}>
        <UpdateForm />
    </div>
);

const INITIAL_STATE = {
    name: "",
    urduName: "",
    error: null,
    personId: "none",
    gender: 1,
    children: []
};

class UpdateFormBase extends Component {
    constructor(props) {
        super(props);

        this.state = { ...INITIAL_STATE, options: [], fathers: {} };

    }

    componentDidMount() {

        this.props.firebase.persons().on('value', snapshot => {
            var options = [{ value: "none", label: "Select a Person" }];
            var persons = {};
            Object.keys(snapshot.val()).forEach(id => {
                // console.log("id", id);
                var p = snapshot.val()[id];
                // p.id = id;
                persons[id] = p;
                var label = "";
                if (p.father !== undefined) {
                    var fatherId = Object.keys(p.father)[0];
                    p.fatherId = fatherId;
                    label = p.name + ' s/o ' + p.father[fatherId].name;
                } else {
                    label = p.name;
                }
                var option = { value: id, label: label }
                options.push(option);
            });
            this.setState({ options: options, persons: persons });
        });
    }

    onSubmit = event => {
        const { name, urduName, personId, gender, persons } = this.state;
        // console.log(name, urduName, fatherId, gender);
        if (name !== null && name.trim() !== "" && urduName !== null && urduName.trim() !== "" && personId !== null && personId !== "none") {
            // console.log("submit");
            var person = persons[personId];
            // delete father["children"];
            // delete father["father"];
            this.props.firebase
                .updatePerson(name, urduName, gender, personId)
                .then(() => {
                    // console.log(person.key);

                    return this.props.firebase.updateSelfAsChild(name, urduName, gender, personId, person.fatherId);

                })
                .then(() => {
                    // console.log(person);
                    if (person.children !== undefined)
                        return this.props.firebase.updateSelfAsFather(name, urduName, gender, Object.keys(person.children), personId);
                    else
                        return Promise.resolve(true);
                })
                .then(() => {
                    alert("Record has been updated successfully");
                    this.setState({ ...INITIAL_STATE });
                })
                .catch(error => {
                    this.setState({ error });
                });
        } else {
            alert("Please submit valid values. Names cannot be empty");
        }


        event.preventDefault();
    };

    onChange = event => {
        // console.log(event.target.name, event.target.value);
        this.setState({ [event.target.name]: event.target.value });

        if (event.target.name === "personId") {
            this.props.firebase.person(event.target.value).on('value', snapshot => {
                var person = snapshot.val();
                var children = [];
                if (person != null && person.children !== undefined && person.children !== null) {
                    Object.keys(person.children).forEach(id => {
                        var child = person.children[id];
                        child.id = id;
                        children.push(child);
                    });
                }
                this.setState({ "children": children, name: person.name, urduName: person.urduName, gender: person.gender });
            });
        }
    };

    onGenderClick(val) {
        this.setState({ gender: val });
    }

    onChildDelete(id, fatherId) {
        // alert(id);
        const { children } = this.state;
        var updatedChildren = children.filter((child) => {
            return child.id !== id;
        })

        this.setState({ "children": updatedChildren });
        // console.log(updatedChildren);
        this.props.firebase.deleteSelfAsChild(id, fatherId).then(() => {
            alert("Child deleted successfully");
        });
    }

    onPersonDelete(id) {

        if (id === null || id === undefined || id === "none")
            alert("Please select a person to delete");
        else {
            this.props.firebase.deletePerson(id)
                .then(() => {
                    alert("Person deleted successfully");
                });
        }
    }

    render() {
        const { name, urduName, gender, personId, error } = this.state;

        // const isInvalid = password === '' || email === '';

        return (
            <div>
                <div style={{ marginBottom: '20px' }}><h3>Update Record</h3></div>
                < Form onSubmit={this.onSubmit} >

                    <Form.Group controlId="personId">
                        <Form.Label>Person</Form.Label>
                        <Form.Control as="select" name="personId" onChange={this.onChange} value={personId}>
                            {this.state.options.map(({ value, label }, index) => <option key={index} value={value} >{label}</option>)}
                        </Form.Control>
                    </Form.Group>
                    {this.state.children.length > 0 && <ul style={{ border: '1px solid #ced4da', padding: '10px 40px' }}>
                        {this.state.children.map((child) => <li key={child.id}>{child.name} <span onClick={() => { if (window.confirm("Are you sure to delete this child?")) this.onChildDelete(child.id, personId) }} style={{ cursor: 'pointer', marginLeft: '10px', fontWeight: 'bold', color: 'red', padding: '0px 5px', backgroundColor: '#ced4da' }}>x</span></li>)}
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

                    <Button style={{ marginLeft: '10px' }} variant="dark" onClick={() => { if (window.confirm("Are you sure to delete the selected person?")) this.onPersonDelete(personId) }}>
                        Delete
                    </Button>
                </Form >
            </div>

        );
    }
}

const UpdateForm = compose(
    withRouter,
    withFirebase,
)(UpdateFormBase);

export default UpdatePage;
