import React, { useState, useCallback } from 'react';
import Modal from 'react-modal';
import { useNavigate } from 'react-router-dom';
import {v4 as uuid} from 'uuid';

import ModalRemoveCourse from '../ProfileOwner/Modals/ModalRemoveCourse';
import { OwnerService } from '../../services';
import { notificationService } from '../../services/notification-service';

import styles from './ManagerCoachCard.module.css';

export default function ManagerCoachCard(props) {
    const [showModal, setShowModal] = useState(false);
    const email = localStorage?.userData?.split(',')[1]?.split(':')[1]?.replace('"', "")?.replace('"', "");

    const coachId = props.coach.id;
    let navigate = useNavigate();

    Modal.setAppElement('body');

    const onDelete = () => {
        OwnerService.CompanyRemoveCoachFromActive(props.coach.id)
            .then(res => {
                console.log('Successful delete');//
                setShowModal(false);
            })
            .finally(() => {
                if (props.isProfile) {
                    OwnerService.CompanyGetActiveCoaches()
                        .then(res => {
                            props.setCoaches(res.data)
                        });
                }
                else {
                    navigate('/profile/owner/coaches');
                }
            });
    }

    const onSet = () => {
        OwnerService.CompanySetCoachToActive(props.coach.id)
            .then(res => {
                if (res.status) {
                    const uniqueGroupKey = uuid();

                    const sendNotificationFunc = async () => {
                      let message = "Coach '" + props.coach.fullName + "' was added!";

                      await notificationService.addNotification(uniqueGroupKey, email, message)
                      await props.sendNotification(uniqueGroupKey, message)

                      navigate('/profile/owner/coaches')
                    }
                    
                    sendNotificationFunc();
                }
                else {
                    /*console.log(error)//*/
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
                //todo use child
                <ModalRemoveCourse handleClose={handleClose} item="coach" delete={onDelete} />
            </Modal>
        </>
    )
}
