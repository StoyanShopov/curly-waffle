import axios from 'axios';
import { baseUrl } from '../constants';

const getAllCourses = async () => {
    return await axios.get("https://localhost:44319/" + "api/EmployeesCourses", {
        headers: {
            "Content-Type": "application/json;charset=UTF-8",
            Authorization: `Bearer ${localStorage.getItem('token')}`,
        }
    })
}

export const courseService = {
    getAllCourses
}