import axios from "axios";

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'administration/lectures';
const token = localStorage.getItem('token');

const getAll = async (courseId, skip) => {
    return await axios
        .get(`${apiUrl}/All/${courseId}?skip=${skip}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

const getById = async (lectureId) => {
    return await axios
        .get(`${apiUrl}/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

const create = async (lectureData) => {
    return await axios
        .post(`${apiUrl}`, lectureData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const update = async (lectureId, lectureData) => {
    return await axios
        .put(`${apiUrl}/${lectureId}`, lectureData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const deleteLecture = async (lectureId) => {
    return await axios
        .delete(`${apiUrl}/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

export const lectureService = {
    getAll,
    getById,
    create,
    update,
    deleteLecture,
}