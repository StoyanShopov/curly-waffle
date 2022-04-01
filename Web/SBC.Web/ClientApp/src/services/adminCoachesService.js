import axios from 'axios';
import { baseUrl } from '../constants';
const apiUrl=baseUrl+"Administrator/Coaches"
export const createCoach = async (data) => {
    try {
        const resp = await axios.post(apiUrl , data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
        return resp;
    } catch (error) {}
}

export const updateCoach = async (data) => {
    try {
        const resp = await axios.put(apiUrl + `/${data.id}`, data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        });
        return resp;
    } catch (error) { }
}

export const getAllCoaches = async () =>{
        return await axios.get(apiUrl, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        })
}

export const deleteCoachById = async (coachId) =>{
    const resp = await axios.delete(apiUrl+`/${coachId}` , {
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