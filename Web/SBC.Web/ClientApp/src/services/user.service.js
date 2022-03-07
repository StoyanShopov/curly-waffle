import axios from 'axios';
import { TokenManagement, instance } from '../helpers';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/Identity/';

const login = async (email, password) => {
    let data = instance
        .post(apiUrl + "Login", {
            email,
            password,
        })
        .then((response) => {
            if (response.data.jwt) {
                TokenManagement.setUser(response.data);
            }
            return response.data.jwt;
        });


    return data;
};

const register = async (fullName, companyName, email, password, confirmPassword) => {
    let data = instance
        .post(apiUrl + "Register", {
            fullName,
            companyName,
            email,
            password,
            confirmPassword
        })
        .then((response) => {
            if (response.data.jwt) {
                TokenManagement.setUser(response.data);
            }
            return response.data.jwt;
        });

    return data;
};

const logout = async () => {
    TokenManagement.removeUser();
    window.location.href = "/";
    return;
    //todo url does not response to real url or method fault on BE
    return await axios
        .post(apiUrl + "logout")
        .then((data) => {
        },
            (err) => console.error(err));
};

const GetUserData = async () => {
    let response = await axios({
        method: 'get',
        url: apiUrl + "Profile",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        }
    });
    TokenManagement.setUserData(JSON.stringify(response.data));
    return response.data;
}

const EditUser = async (_data) => {
    return await axios({
        method: 'PUT',
        url: apiUrl + 'Profile',
        data: _data,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        },
    });
}

export const userService = {
    login,
    register,
    logout,
    GetUserData,
    EditUser,
};