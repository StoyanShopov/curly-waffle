import React, { Component } from 'react';
import NavBar from './NavBar';
import Footer from './Footer';


export function Layout(props) /*extends Component*/ {
    
    
        return (
            <>
                <NavBar />
                <main style={{ top: "160px", position: "relative" }}>
                    {props.children}
                </main>
                <Footer />
            </>
        );
    
}
