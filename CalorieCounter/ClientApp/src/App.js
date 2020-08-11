import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { Profile } from './components/Profile';
import { SignUp } from './components/SignUp';
import { Login } from './components/Login';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/'  component={Home} />
        <Route path='/profile/' component={Profile} />
        <Route path='/signup' component={SignUp} />
        <Route path='/login' component={Login} />
      </Layout>
    );
  }
}