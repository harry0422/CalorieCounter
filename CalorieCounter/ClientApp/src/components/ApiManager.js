import { SessionGlobals } from './SessionGlobals';

export class ApiManager {

    static baseUrl = 'http://localhost:49585';

    static async getTokenInformation(email, password) {
        const url = this.baseUrl + '/oauth/token';
        var object = {};

        object['username'] = email;
        object['password'] = password;
        object['granttype'] = 'password';
        object['scope'] = 'write';

        var request = JSON.stringify(object);

        console.log(url);

        var response = await fetch(url, {
            headers: new Headers({
                'Content-Type': 'application/json'
            }),
            method: 'POST',
            body: request,
        });

        var data = await response.json();

        return data;
    }

    static async getUserProfile(userId) {
        const url = this.baseUrl + '/users/' + userId;
        const accessToken = SessionGlobals.getAuthorizationToken();

        const response = await fetch(url, {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Authorization': accessToken
            }),
            method: 'GET'
        });
        const data = await response.json();

        return data;
    }

    static async CreateUser(email, password, name, age, weight, height, gender, dailyActivityId) {
        const url = this.baseUrl + '/users';

        var object = {};

        object['email'] = email;
        object['password'] = password;
        object['name'] = name;
        object['age'] = parseInt(age);
        object['weight'] = parseFloat(weight);
        object['height'] = parseFloat(height);
        object['gender'] = gender
        object['dailyActivityId'] = parseInt(dailyActivityId);

        var request = JSON.stringify(object);

        console.log(request);

        fetch(url, {
            headers: new Headers({
                'Content-Type': 'application/json'
            }),
            method: 'POST',
            body: request,
        });
    }

    static async getDailyActivities() {
        const url = this.baseUrl + '/dailyactivities';
        const response = await fetch(url);
        const data = await response.json();

        console.log(data);

        return data;
    }
}