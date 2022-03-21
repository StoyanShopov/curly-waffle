import axios from 'axios';
import { TokenManagement, instance } from '../helpers';
import { baseUrl } from '../constants';


const getAllCoaches = async () => {
    return await axios.get(baseUrl + "api/employees/coaches", {
        headers: {
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    })
}

export const EmployeeService = {
    getAllCoaches,
}