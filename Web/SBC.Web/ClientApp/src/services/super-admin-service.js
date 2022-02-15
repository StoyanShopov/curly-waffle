let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzOTg1MTIzNC1mYjcyLTQ0NTItOGQ5Zi01ZWU5ZjllOTdjOTgiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsIm5iZiI6MTY0NDk0OTM4NSwiZXhwIjoxNjQ1MjA4NTg1LCJpYXQiOjE2NDQ5NDkzODV9.Lirq6bX7ooEyqWGsAf56Hr_FehGvgZh4GUtGgYgozus";
const BaseUrl = "https://localhost:44319/";

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