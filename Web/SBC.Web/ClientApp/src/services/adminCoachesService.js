import axios from 'axios';
import { TokenManagement, authHeader, instance } from '../helpers';
import jwt from 'jwt-decode';
import { baseUrl } from '../constants';

export const createCoach = async( 
    firstName,
    lastName,
    price,
    description,
    calendlyUrl,
    company,
    file
) =>{
    let token = localStorage.getItem("token");
    let formData = new FormData();
    
    formData.append("File" , file)
    formData.append("FirstName" , firstName)
    formData.append("LastName" , lastName)
    formData.append("Price" , price)
    formData.append("Company", company)
    formData.append("CalendlyURL" , calendlyUrl)
    formData.append("Description" , description)

    try {
        const resp = await axios.post(baseUrl + "Admin/Coaches", formData, {
          headers: { Authorization: `Bearer ${token}` },
        });
        return resp;
      } catch (err) {}
}