import { useEffect, useState } from "react"
import { employeeService } from "../../../services/employee-service";

import style from "./EmployeeDashboard.module.css";

import DashboardCoachCard from "./DashboardCoachCard.js";
import DashboardCourseCard from "./DashboardCourseCard.js";

export default function EmployeeDashboard() {
    const [userCourses, setUserCourses] = useState([]);
    const [userCoachSessions, setUserCoachSessions] = useState([]);

    useEffect(() => {
        employeeService
            .getDashboard()
            .then(res => {
                setUserCourses(res.userCourses)
                setUserCoachSessions(res.userCoachSessions)
            })
    }, [])

    return (
        <div className={style.container}>
            <div className={style.buttonContainer}>
            </div>
            <div className={style.cardscontainer}>
                {userCoachSessions.length > 0
                    ? userCoachSessions.map(x => <DashboardCoachCard key={x.coachId} coach={x} />)
                    : <h3>No coaches yet</h3>}
                {userCourses.length > 0
                    ? userCourses.map(x => <DashboardCourseCard key={x.courseTitle} course={x} />)
                    : <h3>No courses yet</h3>}
            </div>
        </div>
    )
}