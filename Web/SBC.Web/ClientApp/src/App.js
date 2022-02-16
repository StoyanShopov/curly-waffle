import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import OwnerDashboard from "./components/ProfileOwner/OwnerDashboard";
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses";
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";

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
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;
