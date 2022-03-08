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

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";
import ManagerProfile from "./components/ProfileOwner/BOProfile/ManagerProfile";

import "./App.css";


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
                    <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    {hasRole(_role, ['Administrator']) && <Route path='/profile/*' element={<AdminProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/profile/*' element={<ManagerProfile editUser={() => setUser()} />} />}
                    <Route path="/" element={<Homepage />} />
                    <Route path="/signUp" element={<Signup />} />
                    <Route path="/coachCatalog" element={<CoachCatalog />} />
                    <Route path="/courseCatalog" element={<CourseCatalog />} />
                    <Route path="/courses" element={<AllCourses />} />
                    <Route path="/details/:id" element={<CourseDetails />} />
                </Routes>
            </Layout>
        </Provider>
    );
}
const hasRole = (userRole, roles) =>
    userRole == roles;
//roles.some(role => user.roles.includes(role));
export default App;