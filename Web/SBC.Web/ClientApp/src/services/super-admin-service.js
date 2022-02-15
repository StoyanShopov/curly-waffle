let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJiY2ZhZDc5Ny05MWE0LTRjNDMtYTg5ZS1jOTk2M2EzYmFkYTIiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsIm5iZiI6MTY0NDc1Mjc2NSwiZXhwIjoxNjQ1MDExOTY1LCJpYXQiOjE2NDQ3NTI3NjV9.XeAMOnsMRUTPCWCjuX0slnmFoBIr6jHnsBn7ho-zFFg";
const BaseUrl = "https://localhost:5001/";

export const DashboardIndex = async () => {
    let response = await fetch(BaseUrl + "Administration/Dashboard",
        { headers: { Authorization: `Bearer ${token}` }, })
    const data = await response.json();

    return data;
}
export const GetAdminData = async () => {
    let response = await fetch(BaseUrl + "Administration/Profile/GetUser",
        { headers: { Authorization: `Bearer ${token}` }, })
    const data = await response.json();
    console.log("admin: ")
    console.log(data)
    return data;
}

export const EditAdmin = async (data) => {
    console.log(data);
   return await fetch(BaseUrl + "Administration/Profile/Edit", {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(data)
    })
}

export const uploadImage = async (file) => {
    console.log(file);
    const formData = new FormData();
    formData.append('file', file);

    let response = await fetch(BaseUrl + "api/Blobs/upload", {
        method: 'POST',
        body: formData
    })

    return response;
}