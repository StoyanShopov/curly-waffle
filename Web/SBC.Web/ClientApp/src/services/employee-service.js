import { baseUrl } from '../constants';
import axios from 'axios';

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

export const employeeService = {
    getDashboard,
    getAllLectures,
    getCourseById,
    getLectureById,
    getAllResources,
}