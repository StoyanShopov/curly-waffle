let token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJiY2ZhZDc5Ny05MWE0LTRjNDMtYTg5ZS1jOTk2M2EzYmFkYTIiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQHRlc3QudGVzdCIsIm5iZiI6MTY0NDY3MDMzMywiZXhwIjoxNjQ0OTI5NTMyLCJpYXQiOjE2NDQ2NzAzMzN9.V6slczoXX9L1hLqvhP-LlwSIHx1Vspyc66Zg5Q7e_zQ';

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
    //console.log(options(data))
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