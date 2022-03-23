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
        for (let index = 0; index < res.data.length; index++) {
            const x = res.data[index];
            await axios({
                method: "GET",
                url: getTypeEvents + x.calendlyId,
                headers: {
                    Authorization: "Bearer " + calendly_token,
                    'Content-Type': 'application/json'
                }
            }).then(data => {
                console.log(data.data.collection)
                data.data.collection.forEach((element, index) => {
                    _data.push({
                        "id": x.id,
                        "fullName": x.fullName,
                        "companyLogoUrl": calendly_token.companyLogoUrl,
                        'calendlyId': element.calendlyId,
                        "feedabcked": x.feedabcked,
                        "imageUrl": x.imageUrl,

                        "duration": element.duration,
                        'active': element.active,
                        'calendlyName': element.name,
                    });
                });
            })
        }
    })
    return _data;
}

//todo get calendly data

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

