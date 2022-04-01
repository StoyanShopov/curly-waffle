import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';

import styles from './EmployeeCourseCard.module.css'

import Modal from "react-modal/lib/components/Modal";
import BookingModal from '../../Fragments/Modals/Booking.js'
import { employeeService } from "../../../services/employee-service.js";

export default function EmployeeCourseCard(props) {

    // const [modalIsOpen, setModalIsOpen] = useState(false);
    const courseModalDetails = props.courseModalDetails;
    const [isEnroled, setIsEnrolled] = useState(props.course.isEnrolled)



    // function openModal() {
    //     setModalIsOpen(true);
    // }

    // function afterOpenModal() {
    //     subtitle.color = '#f00';
    // }

    // function closeModal() {
    //     setModalIsOpen(false);
    // }

    function onSetCoursemodalDetails() {
        employeeService.getModalDetailsById(props.course.id)
            .then(response => {
                console.log(response)
                props.setCourseModalDetails(response.data)
                props.openModal(
                    <BookingModal key={1}
                        isMode={"course"}
                        url=""
                        onEnrollUser={onEnrollUser}
                        openModal={props.openModal}
                        handleClose={props.handleClose}
                        entity={{
                            coachId: courseModalDetails.id,
                            courseId: props.course.id,
                            eType: "Course",
                            eName: response.data.coachName,
                            eCompanyName: response.data.companyName,
                            eCoachImgUrl: response.data.coachPictureUrl,
                            eCategoryName: response.data.companyCategoryName,
                            eDescription: response.data.description,
                            eVideoUrl: response.data.videoUrl,
                            eDuration: `${response.data.videosDuration} hours on-demand video`,
                            eResource: `${response.data.lecturesCount} lectures`,
                        }} />,
                        subtitle
                )
            })
    }

    function onEnrollUser() {
        employeeService.enrollUser(props.course.id)
            .then(response => {
                console.log(response)
                setIsEnrolled(response.data)
            })
            props.handleClose();
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
                                ? <Link to={`/courses/details/${props.course.id}`}><button className={styles.removeButton}>Continue</button></Link>
                                : <button className={styles.removeButton} onClick={() => onSetCoursemodalDetails()}>Enroll</button>}

                    </div>
                </div>
            </div>
        </>
    )
}
let subtitle = {
    content: {
        top: '58%',
        left: '50%',
        right: 'auto',
        width: '65%',
        height: '79%',
        bottom: 'auto',
        transform: 'translate(-50%, -50%)',
        padding: '0px',
    },
    color: '#f00'
};