import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

const token = TokenManagement.getLocalAccessToken();

const getOwnerDashboard = async () => {
    return await axios
        .get(baseUrl + "manager/Dashboard", {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`
            }
        });
}

const getCoachesCatalog = async (skip, cancelTokenSource) => {
    return await axios
        .get(baseUrl + 'manager/Coaches?skip=' + skip, {
            cancelToken: cancelTokenSource.token,
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const getCoursesCatalog = async (skip, cancelTokenSource) => {
    return await axios
        .get(baseUrl + 'manager/Courses?skip=' + skip, {
            cancelToken: cancelTokenSource.token,
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyGetEmployees = async (skip, cancelTokenSource) => {
    return await (await axios
        .get(baseUrl + 'manager/Companies/employees?skip=' + skip, {
            cancelToken: cancelTokenSource.token,
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        })).data;
}

const companyAddEmployee = async (model) => {
    return await axios
        .post(baseUrl + 'manager/Companies/addEmployee', model, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyRemoveEmployee = async (employeeId) => {
    return await axios
        .delete(baseUrl + `manager/Companies/removeEmployee?employeeId=${employeeId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyGetActiveCoaches = async () => {
    return await axios
        .get(baseUrl + 'manager/Companies/activeCoaches', {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const companySetCoachToActive = async (coachId) => {
    return await axios
        .get(baseUrl + `manager/Companies/addCoach?coachId=${coachId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyRemoveCoachFromActive = async (coachId) => {
    return await axios
        .delete(baseUrl + `manager/Companies/removeCoach?coachId=${coachId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyGetActiveCourses = async () => {
    return await axios
        .get(baseUrl + 'manager/Companies/activeCourses', {
            headers: {
                "Content-Type": "application/json;charset=UTF-8",
                Authorization: `Bearer ${token}`,
            },
        });
}

const companySetCourseToActive = async (courseId) => {
    return await axios
        .get(baseUrl + `manager/Companies/addCourse?courseId=${courseId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

const companyRemoveCourseFromActive = async (courseId) => {
    return await axios
        .delete(baseUrl + `manager/Companies/removeCourse?courseId=${courseId}`, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
}

export const ownerService = {
    getOwnerDashboard,
    getCoachesCatalog,
    getCoursesCatalog,
    companyGetEmployees,
    companyAddEmployee,
    companyRemoveEmployee,
    companyGetActiveCoaches,
    companySetCoachToActive,
    companyRemoveCoachFromActive,
    companyGetActiveCourses,
    companySetCourseToActive,
    companyRemoveCourseFromActive,
}
