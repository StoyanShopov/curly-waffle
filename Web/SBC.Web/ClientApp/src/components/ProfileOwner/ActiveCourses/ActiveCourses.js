import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";

import ManagerCourseCard from '../../Fragments/ManagerCourseCard';
import { ownerService } from '../../../services';
import styles from "./ActiveCourses.module.css";

export default function ActiveCourses() {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        ownerService.companyGetActiveCourses()
            .then(res => {
                setCourses(res.data);
            })
    }, []);

    return (
        <div className={styles.container}>
            <div className={styles.buttonContainer}>
                <Link to="/owner/courses/courseCatalog" ><button className={styles.manageButton}>Manage</button></Link>
            </div>
            <div className={styles.cardscontainer}>
                {courses.length > 0
                    ? courses.map(x => <ManagerCourseCard key={x.id} course={x} courses={courses} setCourses={setCourses} isProfile={true} />)
                    : <h3>No courses yet</h3>
                }
            </div>
        </div>
    );
}
