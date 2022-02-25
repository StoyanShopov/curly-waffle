import axios from 'axios';
import { baseUrl } from '../constants';

export const createCoach = async (data) => {
    try {
        const resp = await axios.post(baseUrl + "api/Coaches", data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        }).then((coach) => {
            console.log(coach)
        });
        return resp;
    } catch (error) { }
}

export const updateCoach = async (data) => {
    try {
        const resp = await axios.put(baseUrl + `api/Coaches/${data.coachId}`, data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        }).then((resp) => {
            console.log(resp)
        });
        return resp;
    } catch (error) { }
}

export const getAllCoaches = async () =>{
        return await axios.get(baseUrl + "api/Coaches", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        })
}

export const deleteCoachById = async (coachId) =>{
    const resp = await axios.delete(baseUrl + `api/Coaches/${coachId}` , {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`,
        }
    }).then((resp) => {
        console.log(resp);
    })
    return resp;
}

export const getLanguages = async () =>{
    return await axios.get(baseUrl + 'api/Languages/GetAllLanguagesAsync');
}

export const getCategories = async () =>{
    return await axios.get(baseUrl + 'api/Categories/GetAllCategoriesAsync');
}

export const uploadImage = async (file) => {
    const formData = new FormData();
    formData.append('file', file);
    let response = await axios({
        method: 'POST',
        url: baseUrl + "api/Blobs/upload",
        data: formData,
        headers: { 'Content-Type': 'multipart/form-data', }
    });
    return response.data.photoUrl;
}