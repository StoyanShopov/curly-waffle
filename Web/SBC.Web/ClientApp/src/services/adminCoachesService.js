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

export const getAllCoaches = async () =>{
        return await axios.get(baseUrl + "api/Coach/Coaches", {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            }
        })
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