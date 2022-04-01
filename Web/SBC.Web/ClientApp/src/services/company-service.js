import axios from 'axios';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/companies';

const getEmailById = async(id) => {
    const resp = await axios.get(`${apiUrl}/${id}`)
    return resp.data;
}

export const companyService = {
    getEmailById
}