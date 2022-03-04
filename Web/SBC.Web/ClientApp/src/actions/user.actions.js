import { userConstants } from '../constants';
import { userService } from '../services';
import { alertActions } from './';
import { GetAdminData } from '../services/super-admin-service';
import jwt from 'jwt-decode';


export const login = (email, password) => (dispatch) => {
    dispatch(request({ email }));
    
    return userService.login(email, password).then(
        (data) => {
            dispatch(success(data));

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
    function success(data) { return { type: userConstants.LOGIN_SUCCESS,  payload: { user: jwt(data) } } }
    function failure(error) { return { type: userConstants.LOGIN_FAILURE, error } }
};

export const logout = async () => {
    await userService.logout();
    return { type: userConstants.LOGOUT };
}
