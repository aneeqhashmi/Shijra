import React, { Component } from 'react';
import { withFirebase } from '../Firebase';


class LandingComponent extends Component {
    render() {
        return <div>
            <div>This is a landing page</div>
        </div>
    }
}

const LandingPage = withFirebase(LandingComponent);

const Landing = () => (
    <div>
        <h1>Landing</h1>
        <LandingPage />
    </div>
);

export default Landing;