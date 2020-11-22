import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import { compose } from 'recompose';

import { withFirebase } from '../Firebase';
import * as ROUTES from '../../constants/routes';
import { Form, Button } from 'react-bootstrap'

const SignInPage = () => (
    <div style={{ width: '50%', margin: 'auto', marginTop: '100px' }}>
        <SignInForm />
    </div>
);

const INITIAL_STATE = {
    email: '',
    password: '',
    error: null,
};

class SignInFormBase extends Component {
    constructor(props) {
        super(props);

        this.state = { ...INITIAL_STATE };

        // this.state.email = "aneeqhashmi@yahoo.com";
        // this.state.password = "click123";
    }

    onSubmit = event => {
        const { email, password } = this.state;
        console.log(email, password);
        this.props.firebase
            .doSignInWithEmailAndPassword(email, password)
            .then(() => {
                this.setState({ ...INITIAL_STATE });
                this.props.history.push(ROUTES.HOME);
            })
            .catch(error => {
                this.setState({ error });
            });

        event.preventDefault();
    };

    onChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

    render() {
        const { email, password, error } = this.state;

        const isInvalid = password === '' || email === '';

        return (

            <Form onSubmit={this.onSubmit}>
                <Form.Group controlId="formBasicEmail">
                    <Form.Label>Email address</Form.Label>
                    <Form.Control name="email" type="email" placeholder="Enter email" onChange={this.onChange} value={this.state.email} />
                    <Form.Text className="text-muted">
                    </Form.Text>
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control name="password" type="password" placeholder="Password" onChange={this.onChange} value={this.state.password} />
                    {error != null && <Form.Control.Feedback type="invalid" tooltip style={{ position: 'relative', display: 'block', marginTop: '10px' }}>
                        {error.message}
                    </Form.Control.Feedback>}
                </Form.Group>
                <Button variant="dark" type="submit">
                    Login
                </Button>
            </Form >

        );
    }
}

const SignInForm = compose(
    withRouter,
    withFirebase,
)(SignInFormBase);

export default SignInPage;

export { SignInForm };