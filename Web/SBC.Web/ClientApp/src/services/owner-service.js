import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

// from CoachesController:

const GetCoachesCatalog = async (skip, cancelTokenSource) => {
    const response = await axios.get(baseUrl + 'manager/Coaches?skip=' + skip,
        {
            cancelToken: cancelTokenSource.token,
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

// from CoursesController:

const GetCoursesCatalog = async (skip, cancelTokenSource) => {
    const response = await axios.get(baseUrl + 'manager/Courses?skip=' + skip,
        {
            cancelToken: cancelTokenSource.token,
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

// from CompaniesController:

const CompanyGetEmployees = async (skip, cancelTokenSource) => {
    const response = await axios.get(baseUrl + 'manager/Companies/employees?skip=' + skip,
        {
            cancelToken: cancelTokenSource.token,
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error)
    }

    return response.data;
}

const CompanyAddEmployee = async (model) => {
    const response = await axios.post(baseUrl + 'manager/Companies/addEmployee', model,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanyRemoveEmployee = async (employeeId) => {
    const response = await axios.delete(baseUrl + `manager/Companies/removeEmployee?employeeId=${employeeId}`,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanyGetActiveCoaches = async () => {
    const response = await axios.get(baseUrl + 'manager/Companies/activeCoaches',
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanySetCoachToActive = async (coachId) => { //TODO
    const response = await axios.get(baseUrl + `manager/Companies/addCoach?coachId=${coachId}`,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanyRemoveCoachFromActive = async (coachId) => { //TODO
    const response = await axios.delete(baseUrl + `manager/Companies/removeCoach?coachId=${coachId}`,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanyGetActiveCourses = async () => {
    const response = await axios.get(baseUrl + 'manager/Companies/activeCourses',
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanySetCourseToActive = async (courseId) => { //TODO
    const response = await axios.get(baseUrl + `manager/Companies/addCourse?courseId=${courseId}`,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

const CompanyRemoveCourseFromActive = async (courseId) => { //TODO
    const response = await axios.delete(baseUrl + `manager/Companies/removeCourse?courseId=${courseId}`,
        {
            headers: {
                Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
            },
        });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }

    return response;
}

// from DashboardController:

const GetOwnerDashboard = async () => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "manager/Dashboard",
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        }
    });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }
    return response;
}


export const OwnerService = {
    GetOwnerDashboard,
    GetCoachesCatalog,
    GetCoursesCatalog,
    CompanyAddEmployee,
    CompanyGetEmployees,
    CompanyRemoveEmployee,
    CompanyGetActiveCoaches,
    CompanySetCoachToActive,
    CompanyRemoveCoachFromActive,
    CompanyGetActiveCourses,
    CompanySetCourseToActive,
    CompanyRemoveCourseFromActive,
}