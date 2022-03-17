import * as signalR from "@microsoft/signalr";
import React, { useState, useEffect } from 'react';

const App = () => {

    const hubConnection = new signalR
        .HubConnectionBuilder()
        .withUrl("https://localhost:44319/Notification")
        .build();

  hubConnection
    .start()
    .then(() => console.log('Connection started!'))
    .catch(err => console.log('Error while establishing connection :('));

  let list = [];

  const Messages = (messageProps) => {

    const [date, setDate] = useState();

    useEffect(() => {
      messageProps.HubConnection.on("sendToReact", message => {
        list.push(message);
        setDate(new Date());
      })
    }, []);

    return <>{list.map((message, index) => <p key={`message${index}`}>{message}</p>)}</>
  }

  return (
      <>
          <h1>TEST TEST </h1>
      <Messages HubConnection={hubConnection}></Messages>
    </>
  )
}

export default App;