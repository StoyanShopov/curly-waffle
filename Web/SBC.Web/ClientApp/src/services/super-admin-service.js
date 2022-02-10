let token = '';
const options=(data)=>{
    return {
    method: 'PUT',
    headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`
    },
    body: JSON.stringify(data)
}};
export const DashboardIndex = async () => {

    // todo get token

    let response = await fetch("https://localhost:44319/Administration/Dashboard",
        { headers: { Authorization: `Bearer ${token}` }, })
    const data = await response.json();

    return data;
}

export const EditAdmin = async (data) => {
    console.log(data)
    console.log(options(data))
    let response = await fetch("https://localhost:44319/Administration/Profile/Edit", options(data))
    console.log(response)
    const _data = await response.json();
    console.log(_data)
    return _data;
}