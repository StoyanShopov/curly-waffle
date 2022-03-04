import axios from "axios";

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'administration/resources';
const token = localStorage.getItem('token');

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

const uploadFile = async (file) => {
    const formData = new FormData();
    formData.append('file', file);
console.log(formData);
    let response = await axios({
        method: 'POST',
        url: baseUrl + "api/Blobs",
        data: formData,
        headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${token}`,
        }
    });

    return response.data;
}

const deleteFile = async (blobName) => {
    let response = await axios({
        method: 'DELETE',
        url: baseUrl + `api/Blobs/${blobName}`,
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });

    return response;
}

export const resourceService = {
    getAll,
    getById,
    create,
    update,
    deleteResource,
    uploadFile,
    deleteFile,
}
