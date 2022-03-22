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
    console.log(user)
    localStorage.setItem("userData", user);
}

export const getIcon = () => {
    const user = getUserData();
    return user ? user['fullname'][0] : null;
};

export const getUserRole = () => {
    const user = getUser();
    return user ? user['role'] : null;
};

export const getUserData = () => {
    return JSON.parse(localStorage.getItem("userData"));
}
