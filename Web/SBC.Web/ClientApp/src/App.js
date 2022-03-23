import { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";

import { store, TokenManagement } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import AdminProfile from './components/super-admin/AdminProfile';
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses"
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";
import OwnerDashboard from "./components/ProfileOwner/Dashboard/OwnerDashboard";
import CreateCoach from "./components/Coaches/CreateCoach";
import EditCoach from "./components/Coaches/EditCoach";
import Coaches from "./components/Coaches/Coaches";
import DeleteCoach from "./components/Coaches/DeleteCoach";

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import OwnerEmployees from "./components/ProfileOwner/OwnerEmployees/OwnerEmployees";
import Invoice from "./components/ProfileOwner/Invoice/Invoice";
import ActiveCoaches from "./components/ProfileOwner/ActiveCoaches/ActiveCoaches";
import ActiveCourses from "./components/ProfileOwner/ActiveCourses/ActiveCourses";
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";
import ManagerProfile from "./components/ProfileOwner/BOProfile/ManagerProfile";
import EmployeeCourseDetails from "./components/Employees/Courses/EmployeeCourseDetails";

import "./App.css";
import EmployeeProfile from './components/Employees/EmployeeProfile';


function App() {
    const [_user, _setUser] = useState(TokenManagement.getUserData());
    const [_role, _setRole] = useState(TokenManagement.getUserRole());

    const setUser = () => {
        _setUser(TokenManagement.getUserData());
        _setRole(TokenManagement.getUserRole());
    }

    return (
        <Provider store={store}>
            <Layout auth={{ "user": _user, "role": _role }}>
                <Routes>
                    <Route path="/" element={<Homepage />} />
                    <Route path="/login" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    <Route path="/signUp" element={<Signup />} />
                    {hasRole(_role, ['Administrator']) && <Route path='/profile/*' element={<AdminProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/profile/*' element={<ManagerProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Employee']) && <Route path='/profile/*' element={<EmployeeProfile editUser={() => setUser()} />} />}

                    {hasRole(_role, ['Owner']) && <Route path='/owner/coaches/coachCatalog' element={<CoachCatalog />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/owner/courses/courseCatalog' element={<CourseCatalog />} />}

                    <Route path="/api/EmployeesCourses/details/:id" element={<EmployeeCourseDetails />} />

                    {/* <Route path="/profileOwner" element={<OwnerDashboard />} /> */}
                    <Route path="/admin/courses" element={<AllCourses />} />
                    <Route path="/admin/courses/details/:id" element={<CourseDetails />} />

                    <Route path="/admin/coaches" element={<Coaches />} />
                    <Route path="/admin/coaches/create" element={<CreateCoach />} />
                    <Route path="/admin/coaches/edit" element={<EditCoach />} />
                    <Route path="/admin/coaches/delete" element={<DeleteCoach />} />
                </Routes>
            </Layout>
        </Provider>
    );
}
const hasRole = (userRole, roles) =>
    userRole == roles;
export default App;
