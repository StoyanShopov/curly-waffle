//import styles from './ManagerCourseCard.module.css';
//import styles from '../../Fragments/ManagerCourseCard.module.css';
import styles from './EmployeeCourseCard.module.css'
export default function ManagerCourseCard(props) {
    return (
        <>
            <div className={styles.card}>
                <div className={styles.cardpicContainer}>
                    <img className={styles.cardpic} src={props.course.pictureUrl} alt="" />
                    <div className={styles.centered}>{props.course.title}</div>
                </div>
                <div className={styles.down}>
                    <div className={styles.name}>
                        <span>{props.course.categoryName}</span>
                        <span>{props.course.coachFullName}</span>
                    </div>
                    <div className={styles.price}>
                        <span>{props.course.lecturesCount} lectures</span>
                        <span className={styles.imgContainer}><img src={props.course.companyLogoUrl} /></span>
                    </div>
                    <div className={styles.button}>
                        {
                        props.course.isEnrolled
                            ?<button className={styles.practiceButton} onClick={() => openModal()}>Practice</button>
                            :<button className={styles.removeButton} onClick={() => openModal()}>Enroll</button>}

                    </div>
                </div>
            </div>
            {/* <Modal
                style={{
                    content: {
                        top: '50%',
                        left: '50%',
                        right: 'auto',
                        width: '30%',
                        height: '40%',
                        bottom: 'auto',
                        transform: 'translate(-50%, -50%)',
                        padding: '0px',
                    }
                }}
                isOpen={showModal}
                onRequestClose={handleClose}
                contentLabel="Example Modal"
            >
                <ModalRemoveCourse handleClose={handleClose} item="course" delete={onDelete} />
            </Modal> */}
        </>
    )
}
