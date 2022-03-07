import React, { Component } from 'react';
import NavBar from './NavBar';
import Footer from './Footer';

export function Layout(props) /*extends Component*/ {

    return (
        <>
            <NavBar auth={props.auth}/>
            <main style={{ top: "6rem", position: "relative" }}>
                {props.children}
            </main>
            <Footer />
        </>
    );
}
