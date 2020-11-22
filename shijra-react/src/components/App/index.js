import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

import Navigation from '../Navigation';
import HomePage from '../Home';
import SignInPage from '../SignIn';
import ShijraPage from '../Shijra';
import AdminPage from '../Admin';
import CreatePage from '../Admin/Create';
import UpdatePage from '../Admin/Update';

import * as ROUTES from '../../constants/routes';
import { withAuthentication } from '../Session';
import { Container, Row, Col } from 'react-bootstrap'
import './App.css';

class AppComponent extends Component {
    render() {
        return App();
    }
}

const App = () => (
    <Router>
        <Navigation />
        <Container fluid>
            <Row>
                <Col>
                    <Route exact path={ROUTES.HOME} component={HomePage} />
                    <Route path={ROUTES.SIGN_IN} component={SignInPage} />
                    <Route path={ROUTES.SHIJRA} component={ShijraPage} />
                    <Route path={ROUTES.ADMIN} component={AdminPage} />
                    <Route path={ROUTES.CREATE} component={CreatePage} />
                    <Route path={ROUTES.UPDATE} component={UpdatePage} />
                </Col>
            </Row>
        </Container>
        {/* <div>
            <Navigation />

            <Route exact path={ROUTES.HOME} component={HomePage} />
            <Route path={ROUTES.SIGN_IN} component={SignInPage} />
            <Route path={ROUTES.SHIJRA} component={ShijraPage} />
            <Route path={ROUTES.ADMIN} component={AdminPage} />
        </div> */}
    </Router>
);

export default withAuthentication(AppComponent);
