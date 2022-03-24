import { useEffect, useState } from 'react';
import { getDashboard } from '../../../services/employeesService';
import styles from './Achievements.module.css';

export default function Achievement(props) {
    const [userCourses, setUserCourses] = useState([]);

    useEffect(() => {
        getDashboard().then(res => {
            setUserCourses(res.userCourses)
            // setUserCoachSessions(res.userCoachSessions)
        })
    }, [])

    console.log(userCourses);

    return(
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
                            <tr key={userCourses.coachId} className={styles.achievementsTD}>
                                <td>{userCourses.courseTitle}</td>
                                <td>{userCourses.startDate}</td>
                                <td>-</td>
                                <td>-</td>
                            </tr>
                        ))}
                </tbody>
            </table>
        </div>
    );
}