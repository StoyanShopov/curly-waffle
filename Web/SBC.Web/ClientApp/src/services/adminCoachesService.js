import axios from 'axios';
import { baseUrl } from '../constants';
import { getLocalAccessToken } from '../helpers/token';

export const createCoach = async(
    firstName,
    lastName,
    price,
    description,
    calendlyUrl,
    company,
    file
) =>{
    let token = getLocalAccessToken();
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
      } catch (error) {}
}
export const getCoach = async()=>{
    let coach = {
        id:2,
        firstName: "Ivan",
        lastName: "Ivanski",
        description: "ivaneca",
        price: 110,
        calendlyUrl: "https://calendly.com/1",
        file: "fakepath/url",
        company: "companyTest"
    }

    return coach;
}