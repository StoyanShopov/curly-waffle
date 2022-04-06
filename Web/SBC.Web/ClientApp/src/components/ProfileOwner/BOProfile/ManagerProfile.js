import Modal from 'react-modal';
import { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";

import { GetUser } from '../../../hooks/setUser';
import { TokenManagement } from '../../../helpers';

import EditProfile from '../../Fragments/EditProfile/EditProfile';
import SideBar from '../../Fragments/Sidebar/Sidebar';

import OwnerDashboard from '../Dashboard/OwnerDashboard';
import ActiveCoaches from '../ActiveCoaches/ActiveCoaches';
import ActiveCourses from '../ActiveCourses/ActiveCourses';
import OwnerEmployees from '../OwnerEmployees/OwnerEmployees';
import Invoice from '../Invoice/Invoice';


export default function ManagerProfile(props) {
    const [modalIsOpen, setModalIsOpen] = useState(false);

    const [userData, setUserData] = useState({ fullName: '', email: '', company: '' });

    let userRole = TokenManagement.getUserRole();
    useEffect(() => {
        userRole = TokenManagement.getUserRole();
        console.log(props.editUser())//

        GetUser(setUserData);
    }, [])

    function openModal() {
        setModalIsOpen(true);
    }

    function afterOpenModal() {
        subtitle.color = '#f00';
    }

    function closeModal() {
        setModalIsOpen(false);
    }

    return (
        <div style=
            {{
                flexDirection: 'row',
                margin: '0px',
                padding: '0px',
            }}>
            <SideBar showModal={openModal} userData={userData} userRole={userRole} />
            <Routes>
                <Route index element={<OwnerDashboard />} />
                <Route path="owner/dashboard" element={<OwnerDashboard />} />
                <Route path="owner/coaches" element={<ActiveCoaches />} />
                <Route path="owner/courses" element={<ActiveCourses />} />
                <Route path="owner/employees" element={<OwnerEmployees />} />
                <Route path="owner/invoice" element={<Invoice />} />
            </Routes>

            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
                ariaHideApp={false}
            >
                <EditProfile closeModal={closeModal} getUserData={() => GetUser(setUserData)} editUser={() => props.editUser()} />
            </Modal>
        </div>
    )
}

const subtitle = {
    content: {
        top: '55%',
        left: '50%',
        right: 'auto',
        width: '44%',
        height: '500px',
        bottom: 'auto',
        marginTop: '-5%',
        marginRight: '-50%',
        transform: 'translate(-50%, -40%)',
        padding: '0px',
    },
    color: '#f00'
};
