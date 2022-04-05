import axios from 'axios';

import { baseUrl } from '../constants/GlobalConstants';
import { TokenManagement } from '../helpers';

const token = TokenManagement.getLocalAccessToken();

const uploadFile = async (file) => {
    const formData = new FormData();
    formData.append('file', file);

    let response = await axios({
        method: 'POST',
        url: baseUrl + "api/Blobs",
        data: formData,
        headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${token}`,
        }
    });

    return response.data;
}

const deleteFile = async (blobName) => {
    return await axios({
        method: 'DELETE',
        url: baseUrl + `api/Blobs/${blobName}`,
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });
}

export const blobService = {
    uploadFile,
    deleteFile,
}