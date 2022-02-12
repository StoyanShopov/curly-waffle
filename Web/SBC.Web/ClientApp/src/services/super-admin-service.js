let token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJiY2ZhZDc5Ny05MWE0LTRjNDMtYTg5ZS1jOTk2M2EzYmFkYTIiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsIm5iZiI6MTY0NDY4MzAxNywiZXhwIjoxNjQ0OTQyMjE3LCJpYXQiOjE2NDQ2ODMwMTd9.3r8LwDXQ6ByGRARJ5AQdnI5927rSxI8Nx-NTyHjZlSQ';

const options = (data) => {
    return {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(data)
    }
};
export const DashboardIndex = async () => {

    // todo get token

    let response = await fetch("https://localhost:5001/Administration/Dashboard",
        { headers: { Authorization: `Bearer ${token}` }, })
    const data = await response.json();

    return data;
}

export const EditAdmin = async (data) => {
    console.log(data)
    let response = await fetch("https://localhost:5001/Administration/Profile/Edit", {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(data)
    })
    console.log(response)
    const _data = await response.json();
    console.log(_data)
    return _data;
}

export const uploadImage = async (file) => {
    console.log(file)
    let response = await fetch("https://localhost:5001/api/Blobs/upload", {
        method: 'POST',
        headers: {
            'Content-Type': 'multipart/form-data',
            //Authorization: `Bearer ${token}`
        },
        body: file
    })
    console.log(response)
    const _data = await response.json();
    console.log(_data)
    return _data;
}