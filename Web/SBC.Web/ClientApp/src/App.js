import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import AdminProfile from './components/super-admin/AdminProfile';
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses"
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import OwnerDashboard from "./components/ProfileOwner/Dashboard/OwnerDashboard";
import OwnerEmployees from "./components/ProfileOwner/OwnerEmployees/OwnerEmployees";
import Invoice from "./components/ProfileOwner/Invoice/Invoice";
import ActiveCoaches from "./components/ProfileOwner/ActiveCoaches/ActiveCoaches";
import ActiveCourses from "./components/ProfileOwner/ActiveCourses/ActiveCourses";
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";

import "./App.css";


function App() {
   


    return (
        <Provider store={store}>
            <Layout>
                <Routes>
                    <Route path="/" element={<Homepage />} />
                    <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    <Route path="/profileOwner" element={<OwnerDashboard />} />
                    <Route path="/courses" element={<AllCourses />} />
                    <Route path="/details/:id" element={<CourseDetails />} />
                    <Route path='/super-admin/*' element={<AdminProfile />} />
                    <Route path="/signUp" element={<Signup />} />
                    <Route path="/ownerEmployees" element={<OwnerEmployees />} />
                    <Route path="/ownerInvoice" element={<Invoice />} />
                    <Route path="/activeCoaches" element={<ActiveCoaches />} />
                    <Route path="/activeCourses" element={<ActiveCourses />} />
                    <Route path="/courseCatalog" element={<CourseCatalog />} />
                    <Route path="/coachCatalog" element={<CoachCatalog />} />
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;