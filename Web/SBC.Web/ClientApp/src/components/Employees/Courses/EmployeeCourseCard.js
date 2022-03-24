import styles from './EmployeeCourseCard.module.css'
import Modal from "react-modal/lib/components/Modal";

import React, { useState, useEffect } from "react";
import CourseModal from '../Courses/EmplyeeCourseModal.js'
import { Link } from 'react-router-dom';

export default function EmployeeCourseCard(props) {

    const [modalIsOpen, setModalIsOpen] = useState(false);

    let subtitle = {
        content: {
            top: '55%',
            left: '50%',
            right: 'auto',
            width: '44%',
            height: '500px',
            bottom: 'auto',
            marginTop: '-5%',
            marginRight: '-50%',
            transform: 'translate(-50%, -40%)',
            padding: '0px',
        },
        color: '#f00'
    };

    function openModal() {
        setModalIsOpen(true);
    }

    function afterOpenModal() {
        subtitle.color = '#f00';
    }

    function closeModal() {
        setModalIsOpen(false);
    }

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
                            ?<Link to={`/courses/details/${props.course.id}`}><button className={styles.practiceButton}>Continue</button></Link>
                            :<button className={styles.removeButton} onClick={() => openModal() }>Enroll</button>}

                    </div>
                </div>
            </div>

            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
            >
                <CourseModal  />
            </Modal>
        </>
    )
}
