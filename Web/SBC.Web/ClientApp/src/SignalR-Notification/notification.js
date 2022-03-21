import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

import { TokenManagement } from '../helpers';

const Notification = () => {
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const email = localStorage?.userData?.split(',')[1]?.split(':')[1]?.replace('"', "")?.replace('"', "");

  useEffect(() => {
    const a = async () => {
      if (email) {
        await joinRoom(email);
      }
    }

    a();
  }, []);

  const sendNotification = async (message) => {
    await connection.invoke("SendNotifyMessage", message)
      .then(console.log(message))
      .catch(err => console.log(err))
  }

  const joinRoom = async (email) => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:44319/Notification")
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();

      connection.on("Notify", message => {
        setMessages(prevMessages => [...prevMessages, message])
      })

      await connection
        .start()
        .then(() => console.log('Connection started!'))
        .catch(err => console.log('Error while establishing connection :('));

      await connection.invoke("JoinGroupAsync", email)
        .then(() => console.log("Joined room."))
        .catch(() => console.log("Couldn't join room!"))
        setConnection(connection);
    } catch (e) {
      console.log(e);
    }
  }

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
      {email &&
        <div>
          <h1>TESTTEST</h1>
          <button onClick={async () => await sendNotification("The Client has joined the Group")}>Send</button>
          {messages.map((message, index) => (
            <div key={index}>
              <p>{message}</p>
            </div>
          ))}
        </div>}
    </>
  )
}

export default Notification;