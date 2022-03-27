import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';

import styles from './EmployeeCourseCard.module.css'

import Modal from "react-modal/lib/components/Modal";
import BookingModal from'../../Fragments/Modals/Booking.js'
import { courseService } from "../../../services/employeeCourseService";

export default function EmployeeCourseCard(props) {

    const [modalIsOpen, setModalIsOpen] = useState(false);
    const courseModalDetails = props.courseModalDetails;
    const [isEnroled, setIsEnrolled] = useState(props.course.isEnrolled)

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

    function onSetCoursemodalDetails (){
        courseService.getModalDetailsById(props.course.id)
        .then(response => {
            console.log(response)
            props.setCourseModalDetails(response.data)
            openModal()
        })
    }

    function onEnrollUser (){
        courseService.enrollUser(props.course.id)
        .then(response => {
            setIsEnrolled(response.data)
        })
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
                        isEnroled
                            ?<Link to={`/courses/details/${props.course.id}`}><button className={styles.practiceButton}>Continue</button></Link>
                            :<button className={styles.removeButton} onClick={() => onSetCoursemodalDetails() }>Enroll</button>}

                    </div>
                </div>
            </div>

            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
            >
                <BookingModal  key={1}
            isMode={"course"}
            url=""
            onEnrollUser = {onEnrollUser}
            openModal={openModal}
            handleClose={closeModal}
            entity={{
                coachId: courseModalDetails.id,
                courseId: props.course.id,
                eType: "Course",
                eName: courseModalDetails.coachName,
                eCompanyName: courseModalDetails.companyName,
                eCoachImgUrl: courseModalDetails.coachPictureUrl,
                eCategoryName: courseModalDetails.companyCategoryName,
                eDescription: courseModalDetails.description,
                eVideoUrl: courseModalDetails.videoUrl,
                eDuration: `${courseModalDetails.videosDuration} minutes discussion`,
                eResource: `${courseModalDetails.lecturesCount} downloadable resources`,}}/>
            </Modal>
        </>
    )
}
