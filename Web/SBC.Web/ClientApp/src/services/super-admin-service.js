import axios from 'axios';
import { TokenManagement } from '../helpers';

import { baseUrl } from '../constants/GlobalConstants';

const dashboardIndex = async (cancelToken) => {

    let response = await axios(baseUrl + "Administrator/Dashboard", {
        cancelToken: cancelToken,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        },
    });
    return response.data;
}

export const AdminService = {
    dashboardIndex
}