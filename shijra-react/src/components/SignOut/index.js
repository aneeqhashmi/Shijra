import React from 'react';

import { withFirebase } from '../Firebase';
import { Nav } from 'react-bootstrap'

const SignOutButton = ({ firebase }) => (
    // <button type="button" onClick={firebase.doSignOut}>
    //     Sign Out
    // </button>
    <Nav.Link onClick={firebase.doSignOut}>Signout</Nav.Link>
);

export default withFirebase(SignOutButton);