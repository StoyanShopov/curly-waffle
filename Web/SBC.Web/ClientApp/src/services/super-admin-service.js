import { baseUrl } from '../constants/GlobalConstants';
import axios from 'axios';
import { TokenManagement } from '../helpers';

//hard code token
const token = ("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5ZWZjNDg2OS04OTU0LTQwZTctOGVmMS02YTgxNTVlOTQzMjciLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsInJvbGUiOiJBZG1pbmlzdHJhdG9yIiwibmJmIjoxNjQ1MDc1NTU5LCJleHAiOjE2NDUzMzQ3NTksImlhdCI6MTY0NTA3NTU1OX0.fbtOKbI1pE-6BVVrtULtnijqg2Z1qlkKor1FtVuz7HQ");

export const DashboardIndex = async () => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "Administration/Dashboards",
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
        url: baseUrl + "Administration/Profiles",
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
        url: baseUrl + "Administration/Profiles",
        data: _data,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
    });
}

export const uploadImage = async (file) => {
    console.log(file);
    const formData = new FormData();
    formData.append('file', file);

    let response = await axios({
        method: 'POST',
        url: baseUrl + "api/Blobs",
        data: formData,
        headers: {
            'Content-Type': 'multipart/form-data',
        }
    });

    // fetch(baseUrl + "api/Blobs", {
    //     method: 'POST',
    //     body: formData
    // })

    return response.data;
}