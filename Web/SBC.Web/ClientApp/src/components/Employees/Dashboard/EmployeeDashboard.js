import { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import { getDashboard } from "../../../services/employeesService";
import ManagerCoachCard from "../../Fragments/ManagerCoachCard";


export default function EmployeeDashboard(props) {
    
    const [dashboard , setDashboard] = useState([]);
    const [userCourses, setUserCourses] = useState([]);
    const [userCoachSessions, setUserCoachSessions] = useState([]);

    useEffect(() => {
        getDashboard().then(res=> {
            setDashboard(res)
            setUserCourses(res.userCourses)
            setUserCoachSessions(res.userCoachSessions)
        })
    }, [])

    console.log(userCoachSessions);

    return (
        <div>
            <div>
                {userCoachSessions.length > 0
                    ? userCoachSessions.map(x => <ManagerCoachCard key={x.coachId} coach={x} />)
                    : <h3>No coaches yet</h3>}
            </div>
        </div>
    )
}