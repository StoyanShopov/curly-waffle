import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import OwnerDashboard from "./components/ProfileOwner/OwnerDashboard";
import CreateCoach from "./components/Coaches/CreateCoach";
import EditCoach from "./components/Coaches/EditCoach";
import Coaches from "./components/Coaches/Coaches";
import DeleteCoach from "./components/Coaches/DeleteCoach";



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
                    <Route path="/coaches/create" element={<CreateCoach />}/>
                    <Route path="/coaches/edit" element={<EditCoach />}/>
                    <Route path="/coaches/delete" element={<DeleteCoach />}/>
                    <Route path="/coaches" element={<Coaches />}/>
                </Routes>
            </Layout>
        </Provider>
    );
}

export default App;
