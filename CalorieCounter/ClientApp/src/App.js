import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { Profile } from './components/Profile';
import { SingUp } from './components/SingUp';
import { Login } from './components/Login';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/'  component={Home} />
        <Route path='/profile/' component={Profile} />
        <Route path='/singup' component={SingUp} />
        <Route path='/login' component={Login} />
      </Layout>
    );
  }
}