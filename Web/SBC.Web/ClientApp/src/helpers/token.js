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
    return JSON.parse(localStorage.getItem('user'));
};

export const setUser = (response) => {
    localStorage.setItem('token', response.jwt);
    localStorage.setItem('user', JSON.stringify(jwt(response.jwt)));
};

export const removeUser = () => {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    localStorage.removeItem('userData');
};

export const setUserData = async (user) => {
    localStorage.setItem("userData", user);
}

export const getUserData = () => {
    // const _user = 
    return JSON.parse(localStorage.getItem("userData"));
    // const email = _user['email']?_user['email']:null;
    // const fullname = _user['fullname'];
    // const index = _user['fullname'][0];
    // const profileSummary = _user['profileSummary'];
    // const photoUrl = _user['photoUrl'];

    // return {
    //     email, fullname, index, profileSummary,photoUrl
    // }
}
