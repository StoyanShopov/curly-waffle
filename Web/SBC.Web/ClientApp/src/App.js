import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import AdminProfile from './components/AdminProfile';
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import OwnerDashboard from "./components/ProfileOwner/OwnerDashboard";
import Signup from "./components/SignUpAsBusinessOwner/Signup";

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
                    <Route path='/super-admin/*' element={<AdminProfile />} />
                    <Route path="/SignUp" element={<Signup />} />
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;