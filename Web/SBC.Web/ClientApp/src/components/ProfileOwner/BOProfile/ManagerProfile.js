import Modal from 'react-modal';
import { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";

import { OwnerService } from '../../../services';
import { TokenManagement } from '../../../helpers';

import EditProfile from '../../Fragments/EditProfile';
import SideBar from '../../Fragments/Sidebar';

import OwnerDashboard from '../Dashboard/OwnerDashboard';
import ActiveCoaches from '../ActiveCoaches/ActiveCoaches';
import ActiveCourses from '../ActiveCourses/ActiveCourses';
import OwnerEmployees from '../OwnerEmployees/OwnerEmployees';
import Invoice from '../Invoice/Invoice';

export default function ManagerProfile() {
    const [modalIsOpen, setModalIsOpen] = useState(false);

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
        <div style=
            {{
            'flex-direction': 'row',
            margin: '0px',
            padding: '0px',
            }}>
            <SideBar showModal={openModal} />
            <Routes>
                <Route index element={<OwnerDashboard />} />
                <Route path="dashboard" element={<OwnerDashboard />} />
                <Route path="activeCoaches" element={<ActiveCoaches />} />
                <Route path="activeCourses" element={<ActiveCourses />} />
                <Route path="OwnerEmployees" element={<OwnerEmployees />} />
                <Route path="invoice" element={<Invoice />} />
            </Routes>

            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
                ariaHideApp={false}
            >
                <EditProfile closeModal={closeModal} />
            </Modal>
        </div>
    )
}