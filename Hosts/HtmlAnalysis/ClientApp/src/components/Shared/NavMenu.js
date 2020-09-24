import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Nav, Navbar, NavItem } from 'react-bootstrap';
import { FaHome, FaUserCircle } from 'react-icons/fa';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
        <Navbar bg="dark" variant="dark">
            <Navbar.Brand>
                <Link to={'/'}>HtmlAnalysis</Link>
            </Navbar.Brand>
            <Navbar.Collapse>
                <Nav>
                    <LinkContainer to={'/'} exact>
                        <NavItem>
                            <FaHome  /> Home
                      </NavItem>
                    </LinkContainer>
                    <LinkContainer to={'/admin'}>
                        <NavItem>
                            <FaUserCircle /> Admin
                      </NavItem>
                    </LinkContainer>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
  }
}