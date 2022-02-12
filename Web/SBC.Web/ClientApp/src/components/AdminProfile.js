import { Route, Routes } from "react-router-dom";
import Dashboard from './super-admin/Dashboard';
import Revenue from './super-admin/Revenue';
import Clients from './super-admin/Clinets';
import NavigationBar from './super-admin/NavigationBar';
import EditProfile from './super-admin/EditProfile';
import css from './AdminProfile.module.css'
import Modal from 'react-modal';
import React from 'react';

export default function AdminProfile() {

  let subtitle = {
    content: {
      top: '50%',
      left: '50%',
      right: 'auto',
      width: '45%',
      bottom: 'auto',
      marginTop: '-10%',
      marginRight: '-50%',
      transform: 'translate(-50%, -50%)'
    },
    color:'#f00'
  };
const [modalIsOpen, setIsOpen] = React.useState(false);


function openModal() {
  setIsOpen(true);
}

function afterOpenModal() {
  subtitle.color = '#f00';
}

function closeModal() {
  setIsOpen(false);
}

return (
  <div className={css.mainContent}>
    <NavigationBar showModal={openModal} />
    <Routes>
      <Route index element={<Dashboard />} />
      <Route path="dashboard" element={<Dashboard />} />
      <Route path="clients" element={<Clients />} />
      <Route path="revenue" element={<Revenue />} />
    </Routes>


    <Modal
      style={subtitle }
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
