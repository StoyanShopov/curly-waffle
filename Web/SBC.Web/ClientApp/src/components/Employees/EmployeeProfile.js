import Modal from 'react-modal';
import { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import { TokenManagement } from '../../helpers';
import { GetUser } from '../../hooks/setUser';

import Sidebar from '../Fragments/Sidebar';
import EditProfile from '../Fragments/EditProfile';

import EmployeeDashboard from './Dashboard/EmployeeDashboard';
import EmployeeCourses from './Courses/EmployeeCourses';
import EmployeeCoaches from './Coaches/EmployeeCoaches';
import Achievements from './Achievements/Achievements';

import Revenue from '../super-admin/Revenue';

import css from './EmployeeProfile.module.css'

export default function EmployeeProfile(props) {

    const [modalIsOpen, setModalIsOpen] = useState(false);

    const [userData, setUserData] = useState({ fullName: '', email: '', company: '' });

    let userRole = TokenManagement.getUserRole();
    useEffect(() => {
        userRole = TokenManagement.getUserRole();
        GetUser(setUserData);
    }, [])

    let subtitle = {
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
        <div className={css.mainContent}>
            <Sidebar showModal={openModal} userData={userData} userRole={userRole} />
            <div style={{ left: '24%', width: "75%", position: "relative" }}>
                <Routes>
                    <Route index element={<EmployeeDashboard />} />
                    <Route path="employee/dashboard" element={<EmployeeDashboard />} />
                    <Route path="employee/courses" element={<EmployeeCourses />} />
                    <Route path="employee/coaches" element={<EmployeeCoaches />} />
                    <Route path="employee/achievements" element={<Achievements />} />
                </Routes>
            </div>
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
    );
}