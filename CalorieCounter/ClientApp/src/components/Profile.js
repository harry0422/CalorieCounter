import React, { Component } from 'react';

export class Profile extends Component {
    constructor(props) {
        super(props);

        this.state = {
            profile: {}
        };
    }

    render() {
        return (
            <div>
                <p>Name: {this.state.profile.name}</p>
                <p>Age: {this.state.profile.age}</p>
                <p>Weight: {this.state.profile.weight}</p>
                <p>Height: {this.state.profile.height}</p>
                <p>Gender: {this.state.profile.male}</p>
                <p>Daily Activity: {this.state.profile.dailyActivity}</p>
                <p>BMR: {this.state.profile.bmr}</p>
                <p>Daily Calories Needed: {this.state.profile.dailyCaloriesNeeded}</p>
            </div>
        );
    }

    componentDidMount() {
        this.getProfile();
    }

    async getProfile() {
        const response = await fetch('http://localhost:49585/users/' + this.props.match.params.userId);
        const data = await response.json();
        this.setState({ profile: data });

    }
}