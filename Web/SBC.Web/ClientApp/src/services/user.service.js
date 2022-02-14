import axios from 'axios';
import { TokenManagement, authHeader, instance } from '../helpers';
import jwt from 'jwt-decode';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/Identity/';

const login = async(email, password) => {
    return instance
      .post(apiUrl + "Login", {
          email,
          password,
      })
        .then((response) => {
          if (response.data.jwt) {
              TokenManagement.setUser(response.data);
              localStorage.setItem('token', response.data.jwt);
              localStorage.setItem('user', JSON.stringify(jwt(response.data.jwt)));
          }
          return response.data.jwt;
      });
};

const logout = async () => {
    return await axios
      .post(apiUrl + "logout")
      .then(() => {
          localStorage.removeItem('user');
          localStorage.removeItem('token');
      });
};

const getUser = () => {
    return JSON.parse(localStorage.getItem('user')) || null;
}

export const userService = {
    login,
    logout,
    getUser,
};