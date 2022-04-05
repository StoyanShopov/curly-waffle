import axios from 'axios';
import { baseUrl } from '../constants';
import { TokenManagement } from '../helpers';

const token = TokenManagement.getLocalAccessToken()

const create = async (data) => {
    try {
        const resp = await axios.post(baseUrl + "Administration/Coaches", data, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
        return resp;
    } catch (error) {}
}

const update = async (data) => {
    try {
        const resp = await axios.put(baseUrl + `Administration/Coaches/${data.id}`, data, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
        return resp;
    } catch (error) { }
}

const getAll = async () =>{
        return await axios.get(baseUrl + "Administration/Coaches", {
            headers: {
                Authorization: `Bearer ${token}`,
            }
        })
}

const deleteCoach = async (coachId) =>{
    const resp = await axios.delete(baseUrl + `Administration/Coaches/${coachId}` , {
        headers: {
            Authorization: `Bearer ${token}`,
        }
    }).then((resp) => {
    })
    return resp;
}

export const coachService = {
    create,
    update,
    deleteCoach,
    getAll,
}
