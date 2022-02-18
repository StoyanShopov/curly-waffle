import jwt from 'jwt-decode';

export const getLocalRefreshToken = () => {
    const user = (localStorage.getItem('user'));
    return user?.refreshToken;
};

export const getLocalAccessToken = () => {
    return (localStorage.getItem('token'));
    // return JSON.parse(localStorage.getItem('token'));
};

export const getUser = () => {
    return (localStorage.getItem('user'));
};

export const setUser = (response) => {
    localStorage.setItem('token', response.jwt);
    localStorage.setItem('user', (jwt(response.jwt)));
};

export const removeUser = () => {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
};

