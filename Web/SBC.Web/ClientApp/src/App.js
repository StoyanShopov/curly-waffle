import { useState, useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";
import { baseUrl } from "../src/constants/GlobalConstants"
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

import { store, TokenManagement } from "./helpers";
import { Layout } from "./components/Layout/Layout";

import AdminProfile from './components/super-admin/AdminProfile';
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import Homepage from "./components/Homepage/Homepage"
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses"
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";
import CreateCoach from "./components/Coaches/CreateCoach";
import EditCoach from "./components/Coaches/EditCoach";
import Coaches from "./components/Coaches/Coaches";
import DeleteCoach from "./components/Coaches/DeleteCoach";

import Signup from "./components/SignUpAsBusinessOwner/Signup";
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";
import ManagerProfile from "./components/ProfileOwner/BOProfile/ManagerProfile";

import "./App.css";
import EmployeeProfile from './components/Employees/EmployeeProfile';

function App() {
    const [connection, setConnection] = useState([]);
    const [notifications, setNotifications] = useState([]);
    const email = localStorage?.userData?.split(',')[1]?.split(':')[1]?.replace('"', "")?.replace('"', "");

    useEffect(() => {
        const connect = async () => {
            if (email) {
                await joinRoom(email);
            }
        }

        connect();
    }, []);

    const joinRoom = async (email) => {
        try {
            const connection = new HubConnectionBuilder()
                .withUrl(`${baseUrl}Notification`)
                .configureLogging(LogLevel.Information)
                .withAutomaticReconnect()
                .build();

            connection.on("Notify", notification => {
                setNotifications(prevNotifications => [...prevNotifications, notification])
            })

            await connection
                .start()
                .then(() => console.log('Connection started!'))
                .catch(err => console.log('Error while establishing connection :('));

            await connection.invoke("JoinGroupAsync", email)
                .then(() => console.log("Joined room."))
                .catch(() => console.log("Couldn't join room!"))
            setConnection(connection);
        } catch (e) {
            console.log(e);
        }
    }

    const sendNotification = async (uniqueGroupKey, message) => {
        await connection.invoke("SendNotifyMessage", { uniqueGroupKey, message })
            .then(console.log(message))
            .catch(err => console.log(err))
    }

    const [_user, _setUser] = useState(TokenManagement.getUserData());
    const [_role, _setRole] = useState(TokenManagement.getUserRole());

    const setUser = () => {
        _setUser(TokenManagement.getUserData());
        _setRole(TokenManagement.getUserRole());
    }

    return (
        <Provider store={store}>
            <Layout auth={{ "user": _user, "role": _role }} connection={connection} notifications={notifications} setNotifications={setNotifications}>
                <Routes>
                    <Route path="/" element={<Homepage />} />
                    <Route path="/login" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    <Route path="/signUp" element={<Signup />} />
                    {hasRole(_role, ['Administrator']) && <Route path='/profile/*' element={<AdminProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/profile/*' element={<ManagerProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Employee']) && <Route path='/profile/*' element={<EmployeeProfile editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/owner/coaches/coachCatalog' element={<CoachCatalog connection={connection} sendNotification={sendNotification} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/owner/courses/courseCatalog' element={<CourseCatalog connection={connection} sendNotification={sendNotification} />} />}
                    <Route path="/admin/courses" element={<AllCourses />} />
                    <Route path="/admin/courses/details/:id" element={<CourseDetails />} />
                    {hasRole(_role, ['Owner']) && <Route path='/owner/coaches/coachCatalog' element={<CoachCatalog />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/owner/courses/courseCatalog' element={<CourseCatalog />} />}
                    {hasRole(_role, ['Employee']) && <Route path='/courses/details/:id' element={<CourseDetails role={_role} />} />}
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
