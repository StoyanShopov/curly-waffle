export const DashboardIndex = async () => {

    // todo get token
    let token = '';

    let response = await fetch("https://localhost:44319/Administration/Dashboard/index",
        { headers: { Authorization: `Bearer ${token}` }, })
    const data = await response.json();

    return data;
}

