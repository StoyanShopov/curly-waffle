import { baseUrl } from '../constants';
import axios from 'axios';

export const getDashboard = async () => {
    try {
        const resp = await axios.get(baseUrl + "api/Dashboard", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`
            }
        });
        return resp.data;
    } catch (error) { }
}

export const getAllLectures = async (courseId, skip) => {
    return await axios
        .get(`${baseUrl}employees/lectures/All/${courseId}?skip=${skip}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

export const getCourseById = async (courseId) => {
    return await axios
        .get(`${baseUrl}employees/courses/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
}

export const getLectureById = async (lectureId) => {
    return await axios
        .get(`${baseUrl}employees/lectures/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}

export const getAllResources = async (lectureId) => {
    return await axios
        .get(`${baseUrl}employees/resources/All/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        });
}
