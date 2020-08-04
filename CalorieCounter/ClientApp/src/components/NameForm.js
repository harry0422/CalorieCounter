import React, { Component } from 'react';

export class NameForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            dailyActivities: [],
            loading: false,
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

    componentDidMount() {
        this.getDailyActivities();
    }

    render() {
        return (
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
                    <label htmlFor="dailyActivity">Gender</label>
                    <select className="form-control" name="dailyActivityId" value={this.state.value} onChange={this.handleChange} >
                        <option value="">Select an option.</option>
                        {this.state.dailyActivities.map(dailyActivity =>
                            <option value={dailyActivity.id}>{dailyActivity.description}</option>
                        )}
                    </select>
                </div>
                <input type="submit" value="Submit" />
            </form>
        );
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
        console.log(event.target.name + ": " + event.target.value);
    }

    handleSubmit(event) {
        event.preventDefault();
        var json = this.getRequest();

        fetch('http://localhost:49585/users', {
            headers: new Headers({
                'Content-Type': 'application/json'
            }), 
            method: 'POST',
            body: json,
        });

        console.log(json);
    }

    getRequest() {
        var object = {};

        object['email'] = this.state.email;
        object['password'] = this.state.password;
        object['name'] = this.state.name;
        object['age'] = parseInt(this.state.age);
        object['weight'] = parseFloat(this.state.weight);
        object['height'] = parseFloat(this.state.height);
        object['gender'] = this.state.gender
        object['dailyActivityId'] = parseInt(this.state.dailyActivityId);

        return JSON.stringify(object);
    }

    async getDailyActivities() {
        const response = await fetch('http://localhost:49585/dailyactivities');
        const data = await response.json();
        this.setState({ dailyActivities: data, loading: false });
        console.log(data);
    }
}