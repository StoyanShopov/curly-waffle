import axios from "axios";

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/resource';

const getAll = async (lectureId) => {
    return await axios
        .get(`${apiUrl}/All/${lectureId}`);
}

const getById = async (resourceId) => {
    return await axios
        .get(`${apiUrl}/${resourceId}`);
}

const create = async (resourceData ) => {
    return await axios
        .post(`${apiUrl}`, resourceData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

const update = async (resourceId, resourceData) => {
    return await axios
        .put(`${apiUrl}/${resourceId}`, resourceData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

const deleteResource = async (resourceId) => {
    return await axios
        .delete(`${apiUrl}/${resourceId}`, {
            headers: {
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
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