import { Route, Routes } from "react-router-dom";

import SideBar from '../../Fragments/Sidebar';

import OwnerDashboard from '../Dashboard/OwnerDashboard';
import ActiveCoaches from '../ActiveCoaches/ActiveCoaches';
import ActiveCourses from '../ActiveCourses/ActiveCourses';
import OwnerEmployees from '../OwnerEmployees/OwnerEmployees';
import Invoice from '../Invoice/Invoice';


export default function ManagerProfile(props) {
    return (
        <div style=
            {{
                flexDirection: 'row',
                margin: '0px',
                padding: '0px',
            }}>
            <SideBar modal={{ "openModal": props.modal.openModal, "handleClose": props.modal.handleClose }}
                auth={{ "user": props.auth.user, "role": props.auth.role }}
                editUser={() => props.editUser()} />
            <Routes>
                <Route index element={<OwnerDashboard />} />
                <Route path="owner/dashboard" element={<OwnerDashboard />} />
                <Route path="owner/coaches" element={<ActiveCoaches />} />
                <Route path="owner/courses" element={<ActiveCourses />} />
                <Route path="owner/employees" element={<OwnerEmployees />} />
                <Route path="owner/invoice" element={<Invoice />} />
            </Routes>
        </div>
    )
}
