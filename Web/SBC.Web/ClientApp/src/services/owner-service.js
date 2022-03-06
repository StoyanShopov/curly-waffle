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

const GetCoachesCatalog = async () => {
    const response = await axios.get(baseUrl + 'manager/Coaches', 
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

const GetCoursesCatalog = async () => {
    const response = await axios.get(baseUrl + 'manager/Courses',
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

const CompanyGetEmployees = async (skip, cancelTokenSource) => {
    const response = await axios.get(baseUrl + 'manager/Company/employees?skip=' + skip, {
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
    const response = await axios.delete(baseUrl + `manager/Company/removeEmployee?employeeId=${employeeId}`,
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
    const response = await axios.get(baseUrl + 'manager/Company/activeCoaches',
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
    const response = await axios.post(baseUrl + `manager/Company/addCoach?coachId=${coachId}`,
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
    const response = await axios.delete(baseUrl + `manager/Company/removeCoach?coachId=${coachId}`,
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
    const response = await axios.get(baseUrl + 'manager/Company/activeCourses',
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
    const response = await axios.post(baseUrl + `manager/Company/addCourse?courseId=${courseId}`,
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
    const response = await axios.delete(baseUrl + `manager/Company/removeCourse?courseId=${courseId}`,
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