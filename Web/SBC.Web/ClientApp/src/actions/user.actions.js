import { userConstants } from '../constants';
import { userService } from '../services';
import { alertActions } from './';
import { history } from '../helpers';
import jwt from 'jwt-decode';


export const login = (email, password) => (dispatch) => {
    dispatch(request({email}));
    
    return userService.login(email, password).then(
        (data) => {
            dispatch(success(data));
            //history.push('/');
            return Promise.resolve();
        },
        (error) => {
            const errorMessage = 
            (error.response &&
                error.response.data &&
                error.response.data.message) || error.message || error.toString();

            dispatch(failure(errorMessage));
            dispatch(alertActions.error(errorMessage));
            

            return Promise.reject();
        }
    );

    function request(email) { return { type: userConstants.LOGIN_REQUEST, email } }
    function success(data) { return { type: userConstants.LOGIN_SUCCESS,  payload: { user: jwt(data.token) } } }
    function failure(error) { return { type: userConstants.LOGIN_FAILURE, error } }
};

export const logout = async () => {
    await userService.logout();
    return { type: userConstants.LOGOUT };
}

