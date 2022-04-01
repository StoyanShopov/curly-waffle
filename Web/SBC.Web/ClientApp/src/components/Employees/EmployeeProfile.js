import { Route, Routes } from "react-router-dom";

import Sidebar from '../Fragments/Sidebar';

import EmployeeDashboard from './Dashboard/EmployeeDashboard';
import EmployeeCourses from './Courses/EmployeeCourses';
import EmployeeCoaches from './Coaches/EmployeeCoaches';
import Achievements from './Achievements/Achievements';

import css from './EmployeeProfile.module.css'

export default function EmployeeProfile(props) {

   return (
        <div className={css.mainContent}>
            <Sidebar modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }}
                auth={{ "user": props.auth.user, "role": props.auth.role }}
                editUser={() => props.editUser()} />
            <div style={{ left: '24%', width: "75%", position: "relative" }}>
                <Routes>
                    <Route index element={<EmployeeDashboard />} />
                    <Route path="employee/dashboard" element={<EmployeeDashboard />} />
                    <Route path="employee/courses" element={<EmployeeCourses modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }}  />} />
                    <Route path="employee/coaches" element={<EmployeeCoaches  modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }} />} />
                    <Route path="employee/achievements" element={<Achievements />} />
                </Routes>
            </div>
        </div>
    );
}