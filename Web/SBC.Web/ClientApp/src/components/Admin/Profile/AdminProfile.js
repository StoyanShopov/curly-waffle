import { Route, Routes } from "react-router-dom";

import Sidebar from "../../Fragments/Sidebar";
import Dashboard from "../Dashboard/Dashboard";
import Revenue from "../Revenue/Revenue";
import Client from "../Client/Clinets";

import css from './AdminProfile.module.css'

export default function AdminProfile(props) {

  return (
    <div className={css.mainContent}>
      <Sidebar
        modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }}
        auth={{ "user": props.auth.user, "role": props.auth.role }}
        editUser={() => props.editUser()} />
      <Routes>
        <Route index element={<Dashboard />} />
        <Route path="admin/dashboard" element={<Dashboard />} />
        <Route path="admin/clients" element={<Client  modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }} />} />
        <Route path="admin/revenue" element={<Revenue />} />
      </Routes>
    </div>
  )
}
