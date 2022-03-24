import axios from 'axios';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/categories';

export const getCategoriesByCoachId = async (coachId) => {
    return await axios
        .get(`${apiUrl}/${coachId}`);
}