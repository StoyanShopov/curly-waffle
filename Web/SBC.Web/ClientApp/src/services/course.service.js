import axios from "axios";
import { getLocalAccessToken } from '../helpers/token.js';

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/course';

const getAll = async () => {
    return await axios
        .get(apiUrl);
}

const getById = async (courseId) => {
    return await axios
        .get(`${apiUrl}/${courseId}`);
}

const create = async (courseData) => {
    return await axios
        .post(`${apiUrl}`, courseData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

const update = async (courseId, courseData) => {
    return await axios
        .put(`${apiUrl}/${courseId}`, courseData, {
            headers: {
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

export const courseService = {
    getAll,
    getById,
    create,
    update,
}
