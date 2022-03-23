import axios from "axios";

const token = localStorage.getItem('token');

const getAll = async (courseId, skip) => {
    return await axios
        .get(`https://localhost:44319/api/EmployeeLecture/${courseId}?skip=${skip}`, {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            }
        });
}

export const lectureService = {
     getAll,
}
