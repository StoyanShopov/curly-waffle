import axios from 'axios';
import { TokenManagement } from '../helpers';
import { baseUrl, calendly_token, getTypeEvents, scheduled_events } from '../constants';

const getDashboard = async () => {
    try {
        const resp = await axios.get(baseUrl + "api/Dashboard", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`
            }
        });
        return resp.data;
    } catch (error) { }
}

const getAllLectures = async (courseId, skip) => {
    return await axios
        .get(`${baseUrl}api/lectures/All/${courseId}?skip=${skip}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

const getCourseById = async (courseId) => {
    return await axios
        .get(`${baseUrl}api/courses/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
}

const getLectureById = async (lectureId) => {
    return await axios
        .get(`${baseUrl}api/lectures/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

const getAllResources = async (lectureId) => {
    return await axios
        .get(`${baseUrl}api/resources/All/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

const getAllCoaches = async () => {
    let _data = [];
    await axios({
        method: "GET",
        url: baseUrl + "employees/coaches",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        }
    }).then(async (res) => {
        _data = await getAllEventTypes(res)
    }
    )
    return _data;
}
const getAllEventTypes = async (res) => {
    let _data = [];
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
                    "companyLogoUrl": x.companyLogoUrl,
                    'calendlyId': x.calendlyId,
                    "feedbacked": x.feedbacked,
                    "imageUrl": x.imageUrl,

                    "isBooked": element.uri,

                    "scheduling_url": element.scheduling_url,
                    "duration": element.duration,
                    'active': element.active,
                    'calendlyName': element.name,
                });
            });
        })
    }
    let newdata = await getCalendlyEvents(_data);
    return newdata;
}
const getCalendlyEvents = async (data) => {
    let _data = [];
    await axios({
        method: "GET",
        url: scheduled_events(TokenManagement.getUserData().email),
        headers: {
            Authorization: "Bearer " + calendly_token,
            'Content-Type': 'application/json'
        }
    }).then(res => {
        console.log(data)
        _data = res.data.collection;
        console.log(_data)
        data.map(x => {
            if (_data.some(y => {
                console.log(x.feedbacked)
                return y.event_type === x.isBooked && !x.feedbacked
            }
            )) {
                x.feedbacked = false;
            }
            return x;
        })
    })

    return data;
}
const bookCoach = async (coachId) => {
    return await axios({
        method: "POST",
        url: baseUrl + "employees/coaches/book-coach/" + coachId,
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
        url: baseUrl + "employees/coaches/left-feadback",
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
    leftFeedback,
    getCalendlyEvents
}

export const employeeService = {
    getDashboard,
    getAllLectures,
    getCourseById,
    getLectureById,
    getAllResources,
}