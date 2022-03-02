export function authHeader() {
    let token = (localStorage.getItem('token'));

    if (token) {
        return { 'Authorization': 'Bearer ' + token };
    } else {
        return {};
    }
}
