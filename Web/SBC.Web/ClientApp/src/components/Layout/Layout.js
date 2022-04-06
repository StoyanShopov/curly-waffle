import React, { Component } from 'react';
import NavBar from './NavBar/NavBar';
import Footer from './Footer/Footer';

export function Layout(props) {

    return (
        <>
            <NavBar auth={props.auth} connection={props.connection} notifications={props.notifications} setNotifications={props.setNotifications}/>
            <main style={{ top: "6rem", position: "relative" }}>
                {props.children}
            </main>
            <Footer />
        </>
    );
}
