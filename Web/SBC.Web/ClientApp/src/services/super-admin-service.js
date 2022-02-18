import { baseUrl } from '../constants/GlobalConstants';
import axios from 'axios';
import { TokenManagement } from '../helpers';

//hard code token
const token = ("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJiY2ZhZDc5Ny05MWE0LTRjNDMtYTg5ZS1jOTk2M2EzYmFkYTIiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDk0ODkxLCJleHAiOjE2NDUzNTQwOTEsImlhdCI6MTY0NTA5NDg5MX0.Ii-hGc-PGhbh5n3Jl4hsMxu8yqj6L0yrs5eBJaoIJ2U");

export const DashboardIndex = async () => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "Administration/Dashboard",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
    return response.data;
}

export const GetAdminData = async () => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "Administration/Profile",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });

    return response.data;
}

export const EditAdmin = async (_data) => {
    console.log(_data);
    return await axios({
        method: 'PUT',
        url: baseUrl + "Administration/Profile",
        data: _data,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
    });
}
