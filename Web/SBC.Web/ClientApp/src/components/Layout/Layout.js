import React from 'react';
import Modal from 'react-modal';

import NavBar from './NavBar';
import Footer from './Footer';

export function Layout(props) {
    Modal.setAppElement('body');
    return (
        <>
            <NavBar auth={props.auth} connection={props.connection} notifications={props.notifications} setNotifications={props.setNotifications} />
            <main style={{ top: "6rem", position: "relative" }}>
                {props.children}
            </main>
            <Modal
                style={props.modal.style}
                isOpen={props.modal.showModal}
                onAfterOpen={props.modal.afterOpenModal}
                onRequestClose={props.modal.handleClose}
            >
                {props.modal.child}
            </Modal>
            <Footer />
        </>
    );
}
