import React, { Component } from 'react';

export class SingUp extends Component {
    static displayName = SingUp.name;

    constructor(props) {
        super(props);
        this.state = {
            dailyActivities: [],
            loading: false
        };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        this.getDailyActivities();
    }

    handleSubmit(event) {
        alert('A name was submitted');
        event.preventDefault();
    }

    static renderSingUpForm(dailyActivities) {
        return (
            <form onSubmit={this.handleSubmit} noValidate>
                <div className="form-group">
                    <label htmlFor="email">Email address</label>
                    <input type="email" className="form-control" id="email" />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input type="password" className="form-control" id="password" />
                </div>
                <div className="form-group">
                    <label htmlFor="age">Age</label>
                    <input type="input" className="form-control" id="age" />
                </div>
                <div className="form-group">
                    <label htmlFor="weight">Weight</label>
                    <input type="input" className="form-control" id="weight" />
                </div>
                <div className="form-group">
                    <label htmlFor="height">Height</label>
                    <input type="input" className="form-control" id="height" />
                </div>
                <div className="form-group">
                    <label htmlFor="gender">Gender</label>
                    <select className="form-control" id="gender">
                        <option>Male</option>
                        <option>Female</option>
                    </select>
                </div>
                <div className="form-group">
                    <label htmlFor="dailyActivity">Gender</label>
                    <select className="form-control" id="dailyActivity">
                    {dailyActivities.map(dailyActivity =>
                        <option>{dailyActivity.description}</option>        
                    )}
                    </select>
                </div>
                <input type="submit" value="Submit" />
            </form>
        );
    }

    render() {
        let contents =  this.state.loading
            ? <p><em>Loading...</em></p>
            : SingUp.renderSingUpForm(this.state.dailyActivities);

        return (
            <div>
                <h1 id="tabelLabel" >Sing up form</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async getDailyActivities() {
        //const response = await fetch('http://localhost:49585/dailyactivities');
        //const data = await response.json();
        //this.setState({ dailyActivities: data, loading: false });
        //console.log(data);
    }
}