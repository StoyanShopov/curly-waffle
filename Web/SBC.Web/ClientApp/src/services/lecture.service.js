import axios from "axios";

import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/lecture';

const getAll = async (courseId) => {
    return await axios
        .get(`${apiUrl}/All/${courseId}`);
}

const getById = async (lectureId) => {
    return await axios
        .get(`${apiUrl}/${lectureId}`);
}

const create = async (lectureData) => {
    return await axios
        .post(`${apiUrl}`, lectureData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

const update = async (lectureId, lectureData) => {
    return await axios
        .put(`${apiUrl}/${lectureId}`, lectureData, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
            },
        });
}

const deleteLecture = async (lectureId) => {
    return await axios
        .delete(`${apiUrl}/${lectureId}`, {
            headers: {
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmYzVhNThjYS1mYmMzLTRjYTYtYTk1My1iNjg4YmU4NTdlN2QiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDQwNTc4LCJleHAiOjE2NDUyOTk3NzgsImlhdCI6MTY0NTA0MDU3OH0.2FcWBguW2llwBG5TeiZtOHIi5WExsovQwnQG5zfyHY8',
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