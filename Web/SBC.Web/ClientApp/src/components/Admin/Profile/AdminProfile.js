import { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import Modal from 'react-modal';

import { GetUser } from '../../../hooks/setUser';
import { TokenManagement } from '../../../helpers';

import Clients from '../../Admin/Clients/Clinets';
import Dashboard from '../../Admin/Dashboard/Dashboard';
import EditProfile from '../../Fragments/EditProfile';
import Revenue from '../Revenue/Revenue';
import SideBar from '../../Fragments/Sidebar';

import css from './AdminProfile.module.css'

export default function AdminProfile(props) {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [userData, setUserData] = useState({ fullName: '', email: '', company: '' });
  const [userRole, setUSerRole] = useState(TokenManagement.getUserRole())

  useEffect(() => {
    setUSerRole(TokenManagement.getUserRole());
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
      <SideBar showModal={openModal} userData={userData} userRole={userRole} />
      <Routes>
        <Route index element={<Dashboard />} />
        <Route path="admin/dashboard" element={<Dashboard />} />
        <Route path="admin/clients" element={<Clients />} />
        <Route path="admin/revenue" element={<Revenue />} />
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
