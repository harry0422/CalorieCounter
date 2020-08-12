import React, { Component } from 'react';

import { SessionGlobals } from './SessionGlobals'
import { ApiManager } from './ApiManager';

import './Login.css';

export class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: '',
            error: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        let error = '';
        if (this.state.error !== '')
            error = <div className="alert alert-danger" role="alert" > {this.state.error}</div>;

        return (
            <div className="text-center login-container">
                <h1 id="tabelLabel" >Login</h1>
                
                <form className="form-signin" onSubmit={this.handleSubmit} >
                    {error}
                    <label htmlFor="email" className="sr-only">Email address</label>
                    <input type="email" className="form-control" placeholder="Email address" name="email" onChange={this.handleChange} required autoFocus />

                    <label htmlFor="password" className="sr-only">Password</label>
                    <input type="password" id="password" className="form-control" placeholder="Password" name="password" onChange={this.handleChange} required />
                    <button className="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                </form>
            </div>
        );
    }

    componentDidMount() {
        if (SessionGlobals.isLogedIn)
            SessionGlobals.Logout();
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    async handleSubmit(event) {
        event.preventDefault();

        var response = await ApiManager.getTokenInformation(this.state.email, this.state.password)
        var tokenInformation = await response.json();

        if (response.status === 200) {
            SessionGlobals.Login(tokenInformation);
            this.props.history.push('/profile');
        } else {
            this.setState({ error: tokenInformation.description });
        }
    }
}