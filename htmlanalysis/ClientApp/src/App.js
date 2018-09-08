import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Shared/Layout';
import { Home } from './components/Home/Home';
import { Report } from './components/Report/Report';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/admin' component={Report} />
            </Layout>
        );
    }
}