import React, { Component } from 'react';
import { SessionGlobals } from './SessionGlobals'
import { ApiManager } from './ApiManager';

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
                <p>Gender: {this.state.profile.gender}</p>
                <p>Daily Activity: {this.state.profile.dailyActivity}</p>
                <p>BMR: {this.state.profile.bmr}</p>
                <p>Daily Calories Needed: {this.state.profile.dailyCaloriesNeeded}</p>
            </div>
        );
    }

    componentDidMount() {
        if (SessionGlobals.isLogedIn) {
            this.getProfile();
        } else {
            window.location.replace('/login');
        }
    }

    async getProfile() {
        const data = await ApiManager.getUserProfile(SessionGlobals.tokenInformation.userId);
        this.setState({ profile: data });
    }
}