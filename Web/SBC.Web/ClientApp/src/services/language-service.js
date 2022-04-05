import axios from 'axios';
import { baseUrl } from '../constants';

const apiUrl = baseUrl + 'api/languages';

const getAll = async () =>{
    return await axios.get(apiUrl);
}

export const languageService = {
    getAll,
}
