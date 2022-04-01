import { useState, useEffect, useCallback } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Provider } from "react-redux";

import { baseUrl } from "../src/constants/GlobalConstants"
import { store, TokenManagement } from "./helpers";
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

import { Layout } from "./components/Layout/Layout";
import Homepage from "./components/Homepage/Homepage"
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import RegisterAsOwner from "./components/Register/RegisterAsOwner";
import Signup from "./components/SignUpAsBusinessOwner/Signup";

import AdminProfile from './components/Admin/Profile/AdminProfile';
import ManagerProfile from "./components/ProfileOwner/BOProfile/ManagerProfile";
import EmployeeProfile from './components/Employees/EmployeeProfile';
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses"
import CourseCatalog from "./components/ProfileOwner/CourseCatalog/CourseCatalog";
import CourseDetails from "./components/Admin/Course/CourseDetails/CourseDetails";
import CoachCatalog from "./components/ProfileOwner/CoachCatalog/CoachCatalog";
import CreateCoach from "./components/Coaches/CreateCoach";
import EditCoach from "./components/Coaches/EditCoach";
import Coaches from "./components/Coaches/Coaches";
import DeleteCoach from "./components/Coaches/DeleteCoach";

import "./App.css";

function App() {
    const [showModal, setShowModal] = useState(false);
    const [style, setStyle] = useState(subtitle)
    const [child, setChild] = useState();
    const handleClose = useCallback(() => {
        setShowModal(false);
        setChild(null);
    }, []);
    function afterOpenModal() {
        subtitle.color = '#f00';
    }
    function openModal(_child, _style) {
        setChild(_child);
        if (_style) setStyle(_style);
        setShowModal(true);
    }

    const [connection, setConnection] = useState([]);
    const [notifications, setNotifications] = useState([]);

    const [_user, _setUser] = useState(TokenManagement.getUserData());
    const [_role, _setRole] = useState(TokenManagement.getUserRole());

    const setUser = () => {
        _setUser(TokenManagement.getUserData());
        _setRole(TokenManagement.getUserRole());
    }
    
    const email =_user?.email ;

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

    return (
        <Provider store={store}>
            <Layout
                auth={{ "user": _user, "role": _role }}
                connection={connection}
                notifications={notifications}
                setNotifications={setNotifications}
                modal={{ setShowModal, afterOpenModal, style, showModal, child,handleClose }}
            >
                <Routes>
                    <Route path="/" element={<Homepage />} />
                    <Route path="/login" element={<LoginAsEmployee />} />
                    <Route path="/registerAsOwner" element={<RegisterAsOwner />} />
                    <Route path="/signUp" element={<Signup />} />

                    {hasRole(_role, ['Administrator']) && <Route path='/profile/*' element={<AdminProfile modal={{openModal,handleClose}} auth={{"user":_user, "role":_role}} editUser={() => setUser()} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/profile/*' element={<ManagerProfile  modal={{openModal,handleClose}} auth={{"user":_user, "role":_role}} editUser={() => setUser()}/>} />}
                    {hasRole(_role, ['Employee']) && <Route path='/profile/*' element={<EmployeeProfile e modal={{openModal,handleClose}} auth={{"user":_user, "role":_role}} editUser={() => setUser()}/>} />}

                    {hasRole(_role, ['Administrator']) && <Route path="/admin/coaches" element={<Coaches />} />}
                    {hasRole(_role, ['Administrator']) && <Route path="/admin/coaches/create" element={<CreateCoach />} />}
                    {hasRole(_role, ['Administrator']) && <Route path="/admin/courses" element={<AllCourses />} />}
                    {hasRole(_role, ['Administrator']) && <Route path="/admin/courses/details/:id" element={<CourseDetails />} />}
                    {hasRole(_role, ['Administrator']) && <Route path="/admin/coaches/edit" element={<EditCoach />} />}
                    {hasRole(_role, ['Administrator']) && <Route path="/admin/coaches/delete" element={<DeleteCoach />} />}

                    {hasRole(_role, ['Owner']) && <Route path='/owner/coaches/coachCatalog' element={<CoachCatalog connection={connection} sendNotification={sendNotification} />} />}
                    {hasRole(_role, ['Owner']) && <Route path='/owner/courses/courseCatalog' element={<CourseCatalog connection={connection} sendNotification={sendNotification} />} />}

                    {hasRole(_role, ['Employee']) && <Route path='/courses/details/:id' element={<CourseDetails role={_role} />} />}
                </Routes>
            </Layout>

        </Provider>
    );
}
const hasRole = (userRole, roles) =>
    userRole == roles;
export default App;

let subtitle = {
    content: {
        top: '55%',
        left: '50%',
        right: 'auto',
        width: '44%',
        height: '500px',
        bottom: 'auto',
        marginTop: '-5%',
        marginRight: '-50%',
        transform: 'translate(-50%, -40%)',
        padding: '0px',
    },
    color: '#f00'
};
