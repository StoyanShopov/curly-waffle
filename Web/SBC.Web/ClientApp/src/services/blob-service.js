import { baseUrl } from '../constants/GlobalConstants';
import axios from 'axios';

export const uploadImage = async (file) => {
    //console.log(file);
    const formData = new FormData();
    formData.append('file', file);

    let response = await axios({
        method: 'POST',
        url: baseUrl + "api/Blobs",
        data: formData,
        headers: {
            'Content-Type': 'multipart/form-data',
        }
    });

    return response.data;
}