import React, { useState, useCallback } from 'react';
import Modal from 'react-modal';
import { useNavigate } from 'react-router-dom';

import ModalRemoveCourse from '../ProfileOwner/Modals/ModalRemoveCourse';
import { OwnerService } from '../../services';

import styles from './ManagerCourseCard.module.css';

export default function ManagerCourseCard(props) {
    const [showModal, setShowModal] = useState(false);

    const courseId = props.course.id;    
    console.log(courseId, props);   
    let navigate = useNavigate();

    Modal.setAppElement('body');

    const onDelete = () => {
        OwnerService.CompanyRemoveCourseFromActive(courseId)
            .then(res => {
                console.log('Successful delete');//
                setShowModal(false);
            })
            .finally(() => {
                if (props.isProfile) {
                    OwnerService.CompanyGetActiveCourses()
                        .then(res => {
                            props.setCourses(res.data);
                        });
                }
                console.log(courseId, props);
                navigate('/profile/courses');
            });
    }

    const onSet = () => {
        OwnerService.CompanySetCourseToActive(props.course.id)
            .then(res => {
                if (res.status) {
                    console.log('Successful set', res)//
                    navigate('/profile/courses');
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
                    <img className={styles.cardpic} src="/assets/images/Rectangle 1221.png" alt="" />
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
