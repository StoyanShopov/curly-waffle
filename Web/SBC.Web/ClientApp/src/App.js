import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";
import Home from "./components/Home";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import OwnerDashboard from "./components/ProfileOwner/OwnerDashboard";



import "./App.css";

function App() {
    return (
        <Provider store={store}>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    <Route path="/profileOwner" element={<OwnerDashboard />} />
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;
