import { TokenManagement } from '../helpers';

export async function GetUser(_setUserData) {
    let a = TokenManagement.getUserData();

    _setUserData(a)
}