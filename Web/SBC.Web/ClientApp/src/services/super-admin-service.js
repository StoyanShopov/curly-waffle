import axios from 'axios';
import { TokenManagement } from '../helpers';

import { baseUrl } from '../constants/GlobalConstants';

const dashboardIndex = async (cancelToken) => {

    let response = await axios(baseUrl + "Administration/Dashboard", {
        cancelToken: cancelToken,
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
        },
    });
    return response.data;
}

// export const GetAdminData = async () => {
//     let response = await axios({
//         method: 'get',
//         url: baseUrl + "Administration/Profile",
//         headers: {
//             'Content-Type': 'application/json',
//             Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
//         }
//     });
//     TokenManagement.setUserData(JSON.stringify(response.data));
//     return response.data;
// }

// export const EditAdmin = async (_data) => {
//     return await axios({
//         method: 'PUT',
//         url: baseUrl + "Administration/Profile",
//         data: _data,
//         headers: {
//             'Content-Type': 'application/json',
//             Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`
//         },
//     });
// }
export const AdminService = {
    dashboardIndex
}