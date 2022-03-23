import axios from 'axios';

const token = localStorage.getItem('token');

const getAllCourses = async () => {
    return await axios.get("https://localhost:44319/" + "api/EmployeesCourses", {
        headers: {
            "Content-Type": "application/json;charset=UTF-8",
            Authorization: `Bearer ${localStorage.getItem('token')}`,
        }
    })
}

const getById = async (courseId) => {
    return await axios
        .get(`https://localhost:44319/api/EmployeesCourses/${courseId}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

export const courseService = {
    getAllCourses,
    getById
}