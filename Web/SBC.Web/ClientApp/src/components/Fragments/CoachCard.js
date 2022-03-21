import React, { useState, useCallback } from 'react';
import Modal from 'react-modal';
import { useNavigate } from 'react-router-dom';

import { EmployeeService } from '../../services/employee-service';

import styles from './ManagerCoachCard.module.css';

export default function ManagerCoachCard(props) {
    const [showModal, setShowModal] = useState(false);
    const [child, setChild] = useState({});

    const coachId = props.coach.id;
    let navigate = useNavigate();

    Modal.setAppElement('body');

    const onBook = () => {
        console.log("Book");
        //todo make comp for Modal Book
        openModal();
        return;
        // OwnerService.CompanyRemoveCoachFromActive(props.coach.id)
        //     .then(res => {
        //         console.log('Successful delete');//
        //         setShowModal(false);
        //     })
        //     .finally(() => {
        //         if (props.isProfile) {
        //             OwnerService.CompanyGetActiveCoaches()
        //                 .then(res => {
        //                     props.setCoaches(res.data)
        //                 });
        //         }
        //         else {
        //             navigate('/profile/owner/coaches');
        //         }
        //     });
    }

    const onLeftFeedBack = () => {
        console.log("Feedback");
        //todo make comp for Feedback Book
        openModal();
        return;
        // OwnerService.CompanySetCoachToActive(props.coach.id)
        //     .then(res => {
        //         if (res.status) {
        //             console.log('Successful set', res);//
        //             navigate('/profile/owner/coaches');//
        //         }
        //         else {
        //             /*console.log(error)//*/
        //         }
        //     });
    }

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    function openModal(child) {
        setChild(child)
        setShowModal(true);
    }

    return (
        <>
            <div className={styles.card}>
                <div className={styles.upper}>
                    <img className={styles.cardpic} src={props.coach.imageUrl} alt="" />
                </div>
                <div>
                    <div className={styles.name}>
                        <span>{props.coach.categoryByDefault}</span>
                        <span>{props.coach.fullName}</span>
                    </div>
                    <div className={styles.price}>
                        <span>{props.coach.pricePerSession}&#8364; per session</span>
                        <span className={styles.imgContainer}><img src={props.coach.companyLogoUrl} /></span>
                    </div>
                    <div className={styles.button}>
                        {props.coach.isActive
                            ? <button className={styles.removeButton} onClick={() => onBook()}>Book</button>
                            : <button className={styles.removeButton} onClick={() => onLeftFeedBack()}>Feedback</button>
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
                {child}
                {/* <ModalRemoveCourse handleClose={handleClose} item="coach" delete={onDelete} /> */}
            </Modal>
        </>
    )
}
