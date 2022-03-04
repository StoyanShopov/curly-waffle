import axios from "axios";

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'administration/courses';
const token = localStorage.getItem('token');

const getAll = async () => {
    return await axios
        .get(`${apiUrl}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

const getById = async (courseId) => {
    return await axios
        .get(`${apiUrl}/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const create = async (courseData) => {
    return await axios
        .post(`${apiUrl}`, courseData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const update = async (courseId, courseData) => {
    return await axios
        .put(`${apiUrl}/${courseId}`, courseData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const deleteCourse = async (courseId) => {
    return await axios
        .delete(`${apiUrl}/${courseId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            }
        });
}

export const courseService = {
    getAll,
    getById,
    create,
    update,
    deleteCourse,
}
