import axios from 'axios';
import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants';


const getAllCoaches = async () => {
    return await axios({
        method: "GET",
        url: baseUrl + "api/employees/coaches",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    })
}

const bookCoach = async (coachId) => {
    return await axios({
        method: "POST",
        url: baseUrl + "api/employees/coaches/book-coach/" + coachId,
        data: {},
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    })
}

const leftFeedback = async (_data) => {
    return await axios({
        method: "POST",
        url: baseUrl + "api/employees/coaches/left-feadback",
        data: _data,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    })
}
export const EmployeeService = {
    getAllCoaches,
    bookCoach,
    leftFeedback
}

