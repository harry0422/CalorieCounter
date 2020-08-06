import React, { Component } from 'react';
import { SessionGlobals } from './SessionGlobals'
import { ApiManager } from './ApiManager';

export class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Login</h1>
                <p>Fill in the information requested below to login.</p>
                <form onSubmit={this.handleSubmit} noValidate>
                    <div className="form-group">
                        <label htmlFor="email">Email address</label>
                        <input type="email" className="form-control" name="email" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input type="password" className="form-control" name="password" onChange={this.handleChange} />
                    </div>
                    <input type="submit" value="Login" />
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

        const tokenInformation = await ApiManager.getTokenInformation(this.state.email, this.state.password);
        SessionGlobals.Login(tokenInformation);
        this.props.history.push('/profile');
    }
}