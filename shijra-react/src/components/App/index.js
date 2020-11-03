import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

import Navigation from '../Navigation';
import LandingPage from '../Landing';
import SignInPage from '../SignIn';
import HomePage from '../Home';
import AdminPage from '../Admin';

import * as ROUTES from '../../constants/routes';
import { withAuthentication } from '../Session';
import './App.css';

class AppComponent extends Component {
    render() {
        return App();
    }
}

const App = () => (
    <Router>
        <div>
            <Navigation />

            <hr />

            <Route exact path={ROUTES.LANDING} component={LandingPage} />
            <Route path={ROUTES.SIGN_IN} component={SignInPage} />
            <Route path={ROUTES.HOME} component={HomePage} />
            <Route path={ROUTES.ADMIN} component={AdminPage} />
        </div>
    </Router>
);

export default withAuthentication(AppComponent);
