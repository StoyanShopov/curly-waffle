import axios from "axios";

import { baseUrl } from '../constants';
import { TokenManagement } from "../helpers";

const apiUrl = baseUrl + 'administration/resources';
const token = TokenManagement.getLocalAccessToken();

const getAll = async (lectureId) => {
    return await axios
        .get(`${apiUrl}/All/${lectureId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

const getById = async (resourceId) => {
    return await axios
        .get(`${apiUrl}/${resourceId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

const create = async (resourceData) => {
    return await axios
        .post(`${apiUrl}`, resourceData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const update = async (resourceId, resourceData) => {
    return await axios
        .put(`${apiUrl}/${resourceId}`, resourceData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const deleteResource = async (resourceId) => {
    return await axios
        .delete(`${apiUrl}/${resourceId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            }
        });
}

export const resourceService = {
    getAll,
    getById,
    create,
    update,
    deleteResource,
}
