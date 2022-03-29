import axios from 'axios';
import { TokenManagement } from '../helpers';
import { baseUrl, calendly_token, getTypeEvents, scheduled_events } from '../constants';

const token = TokenManagement.getLocalAccessToken();

const getDashboard = async () => {
    try {
        const resp = await axios.get(baseUrl + "employees/Dashboard", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`
            }
        });
        return resp.data;
    } catch (error) { }
}

const getAllLectures = async (courseId, skip) => {
    return await axios
        .get(`${baseUrl}employees/lectures/All/${courseId}?skip=${skip}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

const getCourseById = async (courseId) => {
    return await axios
        .get(`${baseUrl}employees/courses/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
}

const getLectureById = async (lectureId) => {
    return await axios
        .get(`${baseUrl}employees/lectures/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

const getAllResources = async (lectureId) => {
    return await axios
        .get(`${baseUrl}employees/resources/All/${lectureId}`, {
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
           // console.log(res)
            data.data.collection.forEach((element, index) => {
                _data.push({
                    "id": x.id,
                    "fullName": x.fullName,
                    "companyLogoUrl": x.companyLogoUrl,
                    'calendlyId': x.calendlyId,
                    "feedbacked": x.feedbacked,
                    "imageUrl": x.imageUrl,
                    "videoUrl": x.videoUrl,
                    "description": x.description,
                    "companyName": x.companyName,

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
    //    console.log(data)
        _data = res.data.collection;
      //  console.log(_data)
        data.map(x => {
            if (_data.some(y => {
       //         console.log(x.feedbacked)
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
    console.log(coachId)
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

const getAllCourses = async () => {
    return await axios.get(`${baseUrl}employees/Courses`, {
        headers: {
            "Content-Type": "application/json;charset=UTF-8",
            Authorization: `Bearer ${localStorage.getItem('token')}`,
        }
    })
}

const getById = async (courseId) => {
    return await axios
        .get(`${baseUrl}employees/Courses/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const getModalDetailsById = async (courseId) => {
    return await axios
        .get(`${baseUrl}employees/Courses/modalDetails/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const enrollUser = async (courseId) => {
    return await axios
        .post(`${baseUrl}employees/Courses/${courseId}`, {}, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

export const employeeService = {
    getDashboard,
    getAllLectures,
    getCourseById,
    getLectureById,
    getAllResources,
    getAllCoaches,
    bookCoach,
    leftFeedback,
    getCalendlyEvents,
    getAllCourses,
    getById,
    getModalDetailsById,
    enrollUser,
}
