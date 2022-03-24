import { useEffect, useState } from 'react';
import { getDashboard } from '../../../services/employeesService';
import styles from './Achievements.module.css';

export default function Achievement(props) {
    const [userCourses, setUserCourses] = useState([]);
    const [userCoachSessions, setUserCoachSessions] = useState([])

    useEffect(() => {
        getDashboard().then(res => {
            setUserCourses(res.userCourses)
            setUserCoachSessions(res.userCoachSessions)
        })
    }, [])

    console.log(userCoachSessions);

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
                        {userCourses && userCourses.map(userCourses => (
                            <tr key={userCourses.courseId} className={styles.achievementsTD}>
                                <td>{userCourses.courseTitle}</td>
                                <td>{userCourses.startDate}</td>
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
                                <td>{userCoachSessions.date}</td>
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