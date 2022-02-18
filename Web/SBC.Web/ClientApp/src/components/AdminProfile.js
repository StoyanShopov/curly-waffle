import Modal from 'react-modal';
import { useState, useEffect } from "react";
import { Route, Routes } from "react-router-dom";

import css from './AdminProfile.module.css'
import Clients from './super-admin/Clinets';
import Dashboard from './super-admin/Dashboard';
import EditProfile from './super-admin/EditProfile';
import NavigationBar from './super-admin/NavigationBar';
import Revenue from './super-admin/Revenue';
import { GetAdminData } from '../services/super-admin-service';

export  async function GetAdmin(_setAdminData,_setIcon) {
  await GetAdminData().then(a => {
     _setAdminData(a)
     _setIcon(a.fullname.substring(0, 1))
  })
}

export default function AdminProfile() {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [adminData, setAdminData] = useState({ fullName: '',email:'', company: ''});
  const [icon, setIcon] = useState();
  
useEffect(() => {
    GetAdmin(setAdminData,setIcon);
}, [])

  let subtitle = {
    content: {
      top: '50%',
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
      <NavigationBar showModal={openModal} adminData={adminData} icon={icon} />
      <Routes>
        <Route index element={<Dashboard />} />
        <Route path="dashboard" element={<Dashboard />} />
        <Route path="clients" element={<Clients />} />
        <Route path="revenue" element={<Revenue />} />
      </Routes>

      <Modal
        style={subtitle}
        isOpen={modalIsOpen}
        onAfterOpen={afterOpenModal}
        onRequestClose={closeModal}
        ariaHideApp={false}
      >
        <EditProfile closeModal={closeModal} getAdminData={()=>GetAdmin (setAdminData,setIcon)}/>
      </Modal>
    </div>
  )
}
