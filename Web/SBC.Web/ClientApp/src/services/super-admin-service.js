let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5ZWZjNDg2OS04OTU0LTQwZTctOGVmMS02YTgxNTVlOTQzMjciLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsIm5iZiI6MTY0NDcwMDI1NywiZXhwIjoxNjQ0OTU5NDU3LCJpYXQiOjE2NDQ3MDAyNTd9.7U9ROzumEAoYlpfjxwlQGIu5NgEEsl0zCtnrE9bkXsU";
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
    console.log("form:"+data)
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
    console.log("file:"+file)
    const formData = new FormData();
    formData.append('file', file);

    return await fetch(BaseUrl + "api/Blobs/upload", {
        method: 'POST',
        body: formData
    })
}