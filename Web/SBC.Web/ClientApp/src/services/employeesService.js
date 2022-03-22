import { baseUrl } from '../constants';
import axios from 'axios';

export const getDashboard = async () =>{
    try{
        const resp = await axios.get(baseUrl + "api/Dashboard" ,{
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`
            }
        });
        return resp.data;
    }catch (error){ }
}