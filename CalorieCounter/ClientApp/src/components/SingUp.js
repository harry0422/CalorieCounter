import React, { Component } from 'react';
import { SessionGlobals } from './SessionGlobals'
import { ApiManager } from './ApiManager';

export class SingUp extends Component {
    constructor(props) {
        super(props);
        this.state = {
            dailyActivities: [],
            email: "",
            password: "",
            name: "",
            age: 0,
            weight: 0,
            height: 0,
            gender: "",
            dailyActivityId: 0
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Sing up form</h1>
                <p>Fill in the information requested below to create your profile</p>
                <form onSubmit={this.handleSubmit} noValidate>
                    <div className="form-group">
                        <label htmlFor="email">Email address</label>
                        <input type="email" className="form-control" name="email" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input type="password" className="form-control" name="password" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="name">Name</label>
                        <input type="input" className="form-control" name="name" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="age">Age</label>
                        <input type="input" className="form-control" name="age" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="weight">Weight</label>
                        <input type="input" className="form-control" name="weight" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="height">Height</label>
                        <input type="input" className="form-control" name="height" onChange={this.handleChange} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="gender">Gender</label>
                        <select className="form-control" name="gender" value={this.state.value} onChange={this.handleChange} >
                            <option value="">Select an option.</option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label htmlFor="dailyActivity">Daily Activity</label>
                        <select className="form-control" name="dailyActivityId" value={this.state.value} onChange={this.handleChange} >
                            <option value="">Select an option.</option>
                            {this.state.dailyActivities.map(dailyActivity =>
                                <option value={dailyActivity.id}>{dailyActivity.description}</option>
                            )}
                        </select>
                    </div>
                    <input type="submit" value="Submit" />
                </form>
            </div>
        );
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
        console.log(event.target.name + ' ' + event.target.value);
    }

    async handleSubmit(event) {
        event.preventDefault();
        await ApiManager.CreateUser(
            this.state.email,
            this.state.password,
            this.state.name,
            this.state.age,
            this.state.weight,
            this.state.height,
            this.state.gender,
            this.state.dailyActivityId
        );

        var tokenInformation = await ApiManager.getTokenInformation(this.state.email, this.state.password);
        SessionGlobals.Login(tokenInformation, '/profile');
    }

    componentDidMount() {
        this.getDailyActivities();
    }

    async getDailyActivities() {
        const data = await ApiManager.getDailyActivities();
        this.setState({ dailyActivities: data });
    }
}