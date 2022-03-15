import * as signalR from "@microsoft/signalr";
import React, { useState, useEffect } from 'react';

const App = () => {

    const hubConnection = new signalR.HubConnectionBuilder().withUrl("/notification")
        .build();

    hubConnection.start();

    let list = new Array();

    const Messages = (messageProps) => {

       const [date, setDate] = useState();

       useEffect(() => {
           messageProps.HubConnection.on("sendToReact", message => {
               list.push(message);
               setDate(new Date());
           })
       },
           []);

       return <>{list.map((message, index) => <p key={`message${index}`}>{message}</p>)}</>
    }
    return <h1>TESTESTEST</h1>
}

export default App;