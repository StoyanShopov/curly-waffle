import { useCallback, useEffect, useState } from "react"
import Modal from "react-modal/lib/components/Modal";
import { employeeService } from "../../../services/employee-service";
import CoachCard from "../../Fragments/CoachCard";

import style from "./EmployeeDashboard.module.css";

import DashboardCourseCard from "./DashboardCourseCard.js";
import axios from "axios";

export default function EmployeeDashboard() {
    const [userCourses, setUserCourses] = useState([]);
    const [userCoachSessions, setUserCoachSessions] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [child, setChild] = useState();

    Modal.setAppElement('body');

    const getAll = async () => await axios.all([employeeService
        .getDashboard(), employeeService.getAllCoaches("booked")]).then(res => {
            setUserCourses(res[0].userCourses)
            setUserCoachSessions(res[1])
        });

    useEffect(() => {
        getAll()
    }, [])

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    function openModal(child) {
        setChild(child)
        setShowModal(true);
    }
   
    return (
        <div className={style.container}>
            <div className={style.cardscontainer}>

                {
                    userCoachSessions
                ?
                    userCoachSessions.length > 0
                        ? userCoachSessions.map((x, index) => { return <CoachCard key={index} coach={x} openModal={openModal} handleClose={handleClose} /> })
                            : <h3>No coaches yet</h3>
                        : <h3>Not yet ........</h3>
                }

                {userCourses.length > 0
                    ? userCourses.map(x => <DashboardCourseCard key={x.courseTitle} course={x} />)
                    : <h3>No courses yet</h3>

                }
            </div>
            <Modal
                style={{
                    content: {
                        top: '58%',
                        left: '50%',
                        right: 'auto',
                        width: '65%',
                        height: '79%',
                        bottom: 'auto',
                        transform: 'translate(-50%, -50%)',
                        padding: '0px',
                    }
                }}
                isOpen={showModal}
                onRequestClose={handleClose}
                contentLabel="Example Modal"
            >
                {child}
            </Modal>
        </div>
    )
}