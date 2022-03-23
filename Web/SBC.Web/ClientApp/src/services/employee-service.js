import axios from 'axios';
import { TokenManagement } from '../helpers';
import { baseUrl, calendly_token } from '../constants';
import { getTypeEvents } from '../components/Fragments/CoachCard';


const getAllCoaches = async () => {
    let _data = [];
    await axios({
        method: "GET",
        url: baseUrl + "api/employees/coaches",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    }).then(async (res) => {
        res.data.forEach(async (x) => {
            await axios({
                method: "GET",
                url: getTypeEvents + x.calendlyUrl,
                headers: {
                    Authorization: "Bearer " + calendly_token,
                    'Content-Type': 'application/json'
                }
            }).then(data => {
                console.log(data.data.collection)
                data.data.collection.forEach((element, index) => {
                    x.calendlyId = index;
                    _data.push(x);
                });
            })
        })
    })
    return _data;
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

