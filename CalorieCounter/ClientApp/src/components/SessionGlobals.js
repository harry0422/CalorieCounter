export class SessionGlobals {
    static tokenInformation = {};
    static isLogedIn = false;

    static Login(tokenInformation, redirectionPath) {
        this.tokenInformation = tokenInformation;
        this.isLogedIn = true;
        //Redirect.to(redirectionPath);
    }

    static Logout(redirectionPath) {
        this.tokenInformation = {};
        this.isLogedIn = false;
        //Redirect.to(redirectionPath);
    }

    static getAuthorizationToken() {
        if (this.isLogedIn)
            return this.tokenInformation.tokenType + ' ' + this.tokenInformation.accessToken;
    }
}