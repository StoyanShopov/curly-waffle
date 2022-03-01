export default function authHeader() {
    let user = JSON.parse(localStorage.getItem('user'));
    const token = localStorage.getItem('token');
    
    if (user && token) {
        return `Authorization: Bearer ${token}`;
    } else {
        return {};
    }
}
