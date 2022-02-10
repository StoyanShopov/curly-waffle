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
  
  let subtitle;
  const [modalIsOpen, setIsOpen] = React.useState(false);
  

  function openModal() {
    setIsOpen(true);
    // how to pass the func to child ? open/close
    // close btn reset?close
  }

  function afterOpenModal() {
    // references are now sync'd and can be accessed.
    subtitle.style.color = '#f00';
  }

  function closeModal() {
    setIsOpen(false);
  }

  return (
    <div className={css.mainContent}>
      <NavigationBar showModal={openModal}/>
      <Routes>
        <Route index element={<Dashboard />} />
        <Route path="dashboard" element={<Dashboard />} />
        <Route path="clients" element={<Clients />} />
        <Route path="revenue" element={<Revenue />} />
      </Routes>
      <EditProfile visible={false} />

      <Modal
        isOpen={modalIsOpen}
        onAfterOpen={afterOpenModal}
        onRequestClose={closeModal}
        contentLabel="Example Modal"
      >
        <EditProfile closeModal={closeModal}/>
      </Modal>
    </div>
  )
}
