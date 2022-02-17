import axios from 'axios';
import { baseUrl } from '../constants';
import { getLocalAccessToken, getLocalRefreshToken, setUser } from '../helpers/token';

export const createCoach = async (data) => {
    try {
        const resp = await axios.post(baseUrl + "api/Coaches", data, {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
        }).then((coach) => {
            console.log(coach)
        });
        return resp;
    } catch (error) { }
}

export const uploadImage = async (file) => 
{ 
    const formData = new FormData(); 
    formData.append('file', file); 
    let response = await axios({ 
        method: 'POST', 
        url: baseUrl + "api/Blobs/upload", 
        data: formData, 
        headers: { 'Content-Type': 'multipart/form-data', } }); 
        return response.data.photoUrl; 
    }

// export const getCoach = async () => {
//     let coach = {
//         id: 2,
//         firstName: "Ivan",
//         lastName: "Ivanski",
//         description: "ivaneca",
//         price: 110,
//         calendlyUrl: "https://calendly.com/1",
//         file: "fakepath/url",
//         company: "companyTest"
//     }

//     return coach;
// }