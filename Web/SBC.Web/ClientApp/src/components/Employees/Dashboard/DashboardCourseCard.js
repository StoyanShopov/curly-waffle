import { Link } from 'react-router-dom';
import styles from './DashboardCourseCard.module.css';

export default function DashboardCourseCard(props) {
    const courseId = props.course.courseId;
    const course = props.course;

    return (
        <div className={styles.card}>
            <div className={styles.cardpicContainer}>
                <img className={styles.cardpic} src={course.coursePictureUrl} alt="" />
                <Link to={`/courses/details/${courseId}`}><div className={styles.centered}>{course.courseTitle}</div></Link>
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>{course.courseTitle}</span>
                    <span>{course.courseCoachFirstName} {course.courseCoachLastName}</span>
                </div>
                <div className={styles.price}>
                    <span>{course.courseLectures.length} lectures</span>
                    <span className={styles.imgContainer}><img src={course.companyLogoUrl} alt="" /></span>
                </div>
                <div className={styles.button}>
                    <Link to={`/courses/details/${courseId}`} ><button className={styles.continueButton}>Continue</button></Link>
                </div>
            </div>
        </div>
    )
}
