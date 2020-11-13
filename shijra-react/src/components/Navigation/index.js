import React, { useEffect } from 'react';
import SignOutButton from '../SignOut';
import * as ROUTES from '../../constants/routes';
import { AuthUserContext } from '../Session';
import { Navbar, Nav, NavLink } from 'react-bootstrap'
import { DoorOpen } from 'react-bootstrap-icons';
// import { matchPath } from 'react-router';

const NavigationBar = (params) => {

    let pathname = window.location.pathname;
    useEffect(() => {
        pathname = window.location.pathname;
    }, [window.location.pathname]);

    return <Navbar bg="dark" expand="lg" variant="dark">
        <Navbar.Brand href="/shijra">
            <img alt="Shijra" width="50px" src='shijra-tree.png'></img>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            {params.auth ?
                <NavigationAuth activePath={pathname} />
                :
                <NavigationNonAuth activePath={pathname} />}

            {/* <Form inline>
                <FormControl type="text" placeholder="Search" className="mr-sm-2" />
                <Button variant="outline-success">Search</Button>
            </Form> */}
        </Navbar.Collapse>
    </Navbar>
}

const Navigation = () => (
    <div id="navigation" >
        <AuthUserContext.Consumer>
            {authUser =>
                <NavigationBar auth={authUser} />
            }
        </AuthUserContext.Consumer>
    </div>
);

const NavigationAuth = (params) => {
    return <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
            <Nav.Link className={params.activePath === ROUTES.HOME ? 'active' : ''} href={ROUTES.HOME}>Home</Nav.Link>
            <Nav.Link className={params.activePath === ROUTES.SHIJRA ? 'active' : ''} href={ROUTES.SHIJRA}>Shijra</Nav.Link>
            <Nav.Link className={params.activePath === ROUTES.ADMIN ? 'active' : ''} href={ROUTES.ADMIN}>Admin</Nav.Link>
        </Nav>
        <Nav>
            <Nav.Link href="#"><SignOutButton /></Nav.Link>
        </Nav>
    </Navbar.Collapse>
}

const NavigationNonAuth = (params) => {


    return <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
            <NavLink className={params.activePath === ROUTES.HOME ? 'active' : ''} href={ROUTES.HOME}>Home</NavLink>
            <NavLink className={params.activePath === ROUTES.SHIJRA ? 'active' : ''} href={ROUTES.SHIJRA}>Shijra</NavLink>
        </Nav>
        <Nav>
            <NavLink href={ROUTES.SIGN_IN} >Admin Login <DoorOpen /></NavLink>
        </Nav>
    </Navbar.Collapse>
}


export default Navigation;