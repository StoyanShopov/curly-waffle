import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses"
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import OwnerDashboard from "./components/ProfileOwner/Dashboard/OwnerDashboard";
import OwnerEmployees from "./components/ProfileOwner/OwnerEmployees/OwnerEmployees";

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
                    <Route path="/signUp" element={<Signup />} />
                    <Route path="/ownerEmployees" element={<OwnerEmployees />} />
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;
