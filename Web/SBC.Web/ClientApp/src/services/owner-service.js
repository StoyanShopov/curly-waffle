import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';


// from BusinessOwnerProfileController:

export const GetOwnerData = async (userId) => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "manager/BusinessOwnerProfile",
        data: userId,
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

export const EditOwner = async (_data) => {
    let response = await axios({
        method: 'PUT',
        url: baseUrl + "manager/BusinessOwnerProfile",
        data: _data,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        },
    });

    if (response.status !== 200) {
        throw new Error(response.Error);
    }
    return response;
}

// from CoachesController:

export const GetCoachesCatalog = async (companyId) => {
    const response = await axios.get(baseUrl + 'manager/Coaches/coachCatalog', companyId,
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

// from CoursesController:

export const GetCoursesCatalog = async (companyId) => {
    const response = await axios.get(baseUrl + 'manager/Courses/coursesCatalog', companyId,
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

// from CompanyController:

export const CompanyGetEmployees = async (managerId, skip, cancelTokenSource) => {
    const response = await axios.get(baseUrl + 'manager/Company/employees?skip=' + skip, {
        cancelToken: cancelTokenSource.token,
        data: managerId,
        headers: {
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
        },
    });

    if (response.status !== 200) {
        throw new Error(response.Error)
    }

    return response.data;
}

export const CompanyAddEmployee = async (model) => {
    const response = await axios.post(baseUrl + 'manager/Company/addEmployee', model,
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

export const CompanyRemoveEmployee = async (employeeId) => {
    const response = await axios.delete(baseUrl + 'manager/Company/removeEmployee', employeeId,
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

export const CompanyGetActiveCoaches = async (employeeId) => {
    const response = await axios.get(baseUrl + 'manager/Company/activeCoaches', employeeId,
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

export const CompanySetCoachToActive = async (_data) => {
    const response = await axios.post(baseUrl + 'manager/Company/addCoach', _data,
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

export const CompanyRemoveCoachFromActive = async (_data) => {
    const response = await axios.delete(baseUrl + 'manager/Company/removeCoach', _data,
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

export const CompanyGetActiveCourses = async (companyId) => {
    const response = await axios.get(baseUrl + 'manager/Company/activeCourses', companyId,
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

export const CompanySetCourseToActive = async (_data) => {
    const response = await axios.post(baseUrl + 'manager/Company/addCourse', _data,
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

export const CompanyRemoveCourseFromActive = async (_data) => {
    const response = await axios.delete(baseUrl + 'manager/Company/removeCourse', _data,
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

export const GetOwnerDashboard = async (companyId) => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "manager/Dashboard",
        data: companyId,
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
