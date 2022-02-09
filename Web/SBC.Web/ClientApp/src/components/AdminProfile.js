import { Route, Routes } from "react-router-dom";
import Dashboard  from './super-admin/Dashboard';
import Revenue  from './super-admin/Revenue';
import Clients  from './super-admin/Clinets';
import NavigationBar from './super-admin/NavigationBar';
import css from './AdminProfile.module.css'

export default function AdminProfile() {

  return (
      <div className={css.mainContent}>
        <NavigationBar />
          <Routes>
            <Route index element={<Dashboard />} />
            <Route path="dashboard" element={<Dashboard />} />
            <Route path="clients" element={<Clients />} />
            <Route path="revenue" element={<Revenue />} />
          </Routes>
      </div>
  )
}