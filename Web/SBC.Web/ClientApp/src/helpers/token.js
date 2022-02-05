export const getLocalRefreshToken = () => {
    const user = JSON.parse(localStorage.getItem('user'));
    return user?.refreshToken;
};

export const getLocalAccessToken = () => {
    const user = JSON.parse(localStorage.getItem('user'));
    return user?.token;
};

export const updateLocalAccessToken = (token) => {
    let user = JSON.parse(localStorage.getItem('user'));
    user.token = token;
    localStorage.setItem('user', JSON.stringify(user));
};

export const getUser = () => {
    return JSON.parse(localStorage.getItem('user'));
};

export const setUser = (user) => {
    console.log(JSON.stringify(user));
    localStorage.setItem('user', JSON.stringify(user));
};

export const removeUser = () => {
    localStorage.removeItem('user');
};

