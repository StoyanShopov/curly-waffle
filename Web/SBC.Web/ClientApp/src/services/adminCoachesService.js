import axios from 'axios';
import { baseUrl } from '../constants';

export const createCoach = async (data) => {
    try {
        const resp = await axios.post(baseUrl + "Administration/Coaches", data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
        return resp;
    } catch (error) {}
}

export const updateCoach = async (data) => {
    try {
        const resp = await axios.put(baseUrl + `Administration/Coaches/${data.id}`, data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
        return resp;
    } catch (error) { }
}

export const getAllCoaches = async () =>{
        return await axios.get(baseUrl + "Administration/Coaches", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        })
}

export const deleteCoachById = async (coachId) =>{
    const resp = await axios.delete(baseUrl + `Administration/Coaches/${coachId}` , {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`,
        }
    }).then((resp) => {
    })
    return resp;
}
export const getLanguages = async () =>{
    return await axios.get(baseUrl + 'api/Languages');
}

export const getCategories = async () =>{
    return await axios.get(baseUrl + 'api/Categories');
}

export const getCompanyEmailById = async(id) => {
    const resp = await axios.get(baseUrl + `api/Companies/${id}`)
    return resp.data;
}