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
            <div class="container">
                <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
                    <h1 class="display-4">{this.state.profile.name}</h1>
                </div>
                <div class="card-deck mb-3 text-center">
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">Gender</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.gender}</h1></div>
                    </div>
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">Age</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.age}</h1></div>
                    </div>
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">Height</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.height}</h1></div>
                    </div>
                </div>
                <div class="card-deck mb-3 text-center">
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">BMR</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.bmr}</h1></div>
                    </div>
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">Calories Needed</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.dailyCaloriesNeeded}</h1></div>
                    </div>
                    <div class="card mb-4 box-shadow">
                        <div class="card-header"><h4 class="my-0 font-weight-normal">Weight</h4></div>
                        <div class="card-body"><h1 class="card-title pricing-card-title">{this.state.profile.weight}</h1></div>
                    </div>
                </div>
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