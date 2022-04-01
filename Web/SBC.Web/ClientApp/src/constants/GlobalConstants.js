// export const baseUrl = 'https://upskills.azurewebsites.net/';

// TODO: change to azure URL before dev merge
export const baseUrl = 'https://localhost:44319/';

export const calendly_token = "eyJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL2F1dGguY2FsZW5kbHkuY29tIiwiaWF0IjoxNjQ4MjI2Njk2LCJqdGkiOiJkMjkyNDZjYi0wZDZiLTRkYzgtYjFiOC1jYzhlYTVkMmJjMmQiLCJ1c2VyX3V1aWQiOiJkY2QyZTE3OS1hNGY1LTRmNjctOTU0Ny1iMWNlNDAwMGJhZWMifQ.JaNQ7ssEfXdKeXbram5zvI7hCHtqkdAxtpX11U_I0k4";

//get user
// const orgId = "3b91d81f-2042-4964-a5ce-e1c43314347b";
export const userId = "dcd2e179-a4f5-4f67-9547-b1ce4000baec";
export const linkUsrById = "https://api.calendly.com/users/dcd2e179-a4f5-4f67-9547-b1ce4000baec";

//active type events by user creator
export const getTypeEvents = "https://api.calendly.com/event_types?active=true&user=https%3A%2F%2Fapi.calendly.com%2Fusers%2F";

//get event by id
export const getTypeEventById = "https://api.calendly.com/event_types/93be18fb-f981-4a4c-80e3-88cbd861a606";

//schedule events (booked) by user 
export const scheduled_events = (userEmail)=>"https://api.calendly.com/scheduled_events?user=" + linkUsrById + "&invitee_email="+ userEmail+"&status=active";
