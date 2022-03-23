import { Link } from 'react-router-dom';
import styles from './DashboardCourseCard.module.css';

export default function DashboardCourseCard(props) {
    const courseId = props.course.courseId;

    return (
        <div className={styles.card}>
            <div className={styles.cardpicContainer}>
                <img className={styles.cardpic} src={props.course.coursePictureUrl} alt="" />
                <Link to={`/admin/courses/details/${courseId}`}><div className={styles.centered}>{props.course.courseTitle}</div></Link>
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>{props.course.courseTitle}</span>
                    <span>{props.course.courseCoachFirstName} {props.course.courseCoachLastName}</span>
                </div>
                <div className={styles.price}>
                    <span>{props.course.lecturesCount}</span>
                    <span className={styles.imgContainer}><img src={props.course.companyLogoUrl} alt="" /></span>
                </div>
                <div className={styles.button}>
                    <Link to={`/admin/courses/details/${courseId}`}><button className={styles.continueButton}>Continue</button></Link>
                </div>
            </div>
        </div>
    )
}
