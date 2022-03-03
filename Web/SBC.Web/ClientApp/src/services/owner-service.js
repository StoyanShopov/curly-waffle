import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';


// from BusinessOwnerProfileController:

const GetOwnerData = async () => {
    let response = await axios({
        method: 'get',
        url: baseUrl + "manager/BusinessOwnerProfile",
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

const EditOwner = async (_data) => {
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

const GetCoachesCatalog = async (companyId) => {
    const response = await axios.get(baseUrl + 'manager/Coaches', companyId,
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

const GetCoursesCatalog = async (companyId) => {
    const response = await axios.get(baseUrl + 'manager/Courses', companyId,
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

const CompanyGetEmployees = async (skip) => {
    const response = await axios.get(baseUrl + 'manager/Company/employees?skip=' + skip, {
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

const CompanyRemoveEmployee = async (employeeId) => {
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

const CompanyGetActiveCoaches = async (employeeId) => {
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

const CompanySetCoachToActive = async (_data) => {
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

const CompanyRemoveCoachFromActive = async (_data) => {
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

const CompanyGetActiveCourses = async (companyId) => {
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

const CompanySetCourseToActive = async (_data) => {
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

const CompanyRemoveCourseFromActive = async (_data) => {
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
    GetOwnerData,
    GetOwnerDashboard,
    GetCoachesCatalog,
    GetCoursesCatalog,
    EditOwner,
    GetOwnerDashboard,
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