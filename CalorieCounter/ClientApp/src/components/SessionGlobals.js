export class SessionGlobals {

    static tokenInformation = {};
    static isLogedIn = false;

    static Login(tokenInformation) {
        this.tokenInformation = tokenInformation;
        this.isLogedIn = true;
        
    }

    static Logout() {
        this.tokenInformation = {};
        this.isLogedIn = false;
    }

    static getAuthorizationToken() {
        if (this.isLogedIn)
            return this.tokenInformation.tokenType + ' ' + this.tokenInformation.accessToken;
    }
}