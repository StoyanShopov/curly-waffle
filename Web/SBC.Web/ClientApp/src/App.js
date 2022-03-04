import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";

import { store, TokenManagement } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import AdminProfile from './components/super-admin/AdminProfile';
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import OwnerDashboard from "./components/ProfileOwner/Dashboard/OwnerDashboard";
import OwnerEmployees from "./components/ProfileOwner/OwnerEmployees/OwnerEmployees";
import Invoice from "./components/ProfileOwner/Invoice/Invoice";
import ActiveCoaches from "./components/ProfileOwner/ActiveCoaches/ActiveCoaches";
import ActiveCourses from "./components/ProfileOwner/ActiveCourses/ActiveCourses";
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";
import ManagerProfile from "./components/ProfileOwner/BOProfile/ManagerProfile";

import "./App.css";


function App() {
    const userRole = TokenManagement.getUserRole();


    return (
        <Provider store={store}>
            <Layout>
                <Routes>
                    <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    {hasRole(userRole, ['Administrator']) && <Route path='/profile/*' element={<AdminProfile />} />}
                    {hasRole(userRole, ['Owner']) && <Route path='/profile/*' element={<ManagerProfile />} />}
                    <Route path="/" element={<Homepage />} />
                    <Route path="/signUp" element={<Signup />} />
                    <Route path="/coachCatalog" element={<CoachCatalog />} />
                    <Route path="/courseCatalog" element={<CourseCatalog />} />
                </Routes>
            </Layout>
        </Provider>
    );
}
const hasRole = (userRole, roles) =>
    userRole == roles;
//roles.some(role => user.roles.includes(role));
export default App;