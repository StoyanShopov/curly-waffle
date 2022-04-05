import axios from 'axios';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/categories';

const getAll = async () =>{
    return await axios.get(apiUrl);
}

const getByCoachId = async (coachId) => {
    return await axios
        .get(`${apiUrl}/${coachId}`);
}

export const categoryService ={
    getAll,
    getByCoachId
}
