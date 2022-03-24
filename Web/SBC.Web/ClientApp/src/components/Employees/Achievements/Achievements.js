import { useEffect, useState } from 'react';

import styles from './Achievements.module.css';
import { format } from "date-fns";

import { getDashboard } from '../../../services/employeesService';
export default function Achievement(props) {
    const [userCourses, setUserCourses] = useState([]);
    const [userCoachSessions, setUserCoachSessions] = useState([])

    useEffect(() => {
        getDashboard().then(res => {
            setUserCourses(res.userCourses)
            setUserCoachSessions(res.userCoachSessions)
        })
    }, [])

    return (
        <div>
            <div className={styles.achievementsContent}>
                <table className={styles.tableRevenue}>
                    <thead style={{ background: "#296CFB" }}>
                        <tr className={styles.achievementsTHeadRow}>
                            <th>Course</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>Grade</th>
                        </tr>
                    </thead>
                    <tbody className={styles.achievementsTbody}>
                    {/* {userCourses.length > 0 ? console.log(format(new Date(userCourses[0].startDate), "MMMM do, yyyy H:mma")) : ' '} */}
                        {userCourses && userCourses.map(userCourses => (
                            <tr key={userCourses.courseId} className={styles.achievementsTD}>
                                <td>{userCourses.courseTitle}</td>
                                <td>{format(new Date(userCourses.startDate), "dd.mm.yyyy")}</td>
                                <td>-</td>
                                <td>-</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            <div className={styles.achievementsContent}>
                <table className={styles.tableRevenue}>
                    <thead style={{ background: "#16D696" }}>
                        <tr className={styles.achievementsTHeadRow}>
                            <th>Coach</th>
                            <th>First Session</th>
                            <th>Last Session</th>
                            <th>Sessions</th>
                        </tr>
                    </thead>
                    <tbody className={styles.achievementsTbody}>
                        {userCoachSessions && userCoachSessions.map(userCoachSessions => (
                            <tr key={userCoachSessions.coachId} className={styles.achievementsTD}>
                                <td>{`${userCoachSessions.coachFirstName} ${userCoachSessions.coachLastName}`}</td>
                                <td>{format(new Date(userCoachSessions.date), "dd.mm.yyyy")}</td>
                                <td>-</td>
                                <td>-</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

        </div>
    );
}