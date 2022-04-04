import React, { useState, useCallback } from 'react';
import Modal from 'react-modal';
import { useNavigate } from 'react-router-dom';
import {v4 as uuid} from 'uuid';

import styles from './ManagerCourseCard.module.css';

import ModalRemoveCourse from '../ProfileOwner/Modals/ModalRemoveCourse';
import { ownerService } from '../../services';
import { notificationService } from '../../services/notification-service';

export default function ManagerCourseCard(props) {
    const [showModal, setShowModal] = useState(false);
    const email = localStorage?.userData?.split(',')[1]?.split(':')[1]?.replace('"', "")?.replace('"', "");

    const courseId = props.course.id;   
    let navigate = useNavigate();

    Modal.setAppElement('body');

    const onDelete = () => {
        ownerService.companyRemoveCourseFromActive(courseId)
            .then(res => {
                console.log('Successful delete');//
                setShowModal(false);
            })
            .finally(() => {
                if (props.isProfile) {
                    ownerService.companyGetActiveCourses()
                        .then(res => {
                            props.setCourses(res.data);
                        });
                }
                else {
                    navigate('/profile/owner/courses');
                }                          
            });
    }
    
    const onSet = () => {
        ownerService.companySetCourseToActive(props.course.id)
            .then(res => {
                if (res.status) {
                    const uniqueGroupKey = uuid();

                    const sendNotificationFunc = async () => {
                      let message = "Course '" + props.course.title + "' was added!";

                      await notificationService.addNotification(uniqueGroupKey, email, message)
                      await props.sendNotification(uniqueGroupKey, message)

                      navigate('/profile/owner/courses')
                    }
                    
                    sendNotificationFunc();
                }
                else {
                    /*console.log(error);//*/
                }
            });
    }

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    function openModal() {
        setShowModal(true);
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
                        <span>{props.course.pricePerPerson}&#8364; per person</span>
                        <span className={styles.imgContainer}><img src={props.course.companyLogoUrl} /></span>
                    </div>
                    <div className={styles.button}>
                        {props.course.isActive
                            ? <button className={styles.removeButton} onClick={() => openModal()}>Remove</button>
                            : <button className={styles.removeButton} onClick={onSet}>Add</button>
                        }
                    </div>
                </div>
            </div>
            <Modal
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
            </Modal>
        </>
    )
}
