export const getLocalRefreshToken = () => {
    const user = JSON.parse(localStorage.getItem('user'));
    return user?.refreshToken;
};

export const getLocalAccessToken = () => {
    return JSON.parse(localStorage.getItem('token'));
};

export const getUser = () => {
    return JSON.parse(localStorage.getItem('user'));
};

export const setUser = (user) => {
    localStorage.setItem('user', JSON.stringify(user.jwt));
};

export const removeUser = () => {
    localStorage.removeItem('user');
};

