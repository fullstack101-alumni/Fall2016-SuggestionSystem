export class Utility {
    static isUserLoggedIn(): boolean {
        return localStorage.getItem('userName') !== null;
    }
}