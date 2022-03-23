import React, { useState, useCallback, useEffect } from 'react';
import Modal from 'react-modal';

import styles from './DashboardCoachCard.module.css';

import { getCategoriesByCoachId } from '../../../services/categoryService';

import ModalRemoveCourse from '../../ProfileOwner/Modals/ModalRemoveCourse';

export default function DashboardCoachCard(props) {
    const [showModal, setShowModal] = useState(false);
    const [categories, setCategories] = useState([]);

    const coachId = props.coach.coachId;

    useEffect(() => {
        getCategoriesByCoachId(coachId)
            .then(response => {
                console.log(response.data[0].name);
                setCategories(response.data);
            });
    }, [coachId]);

    function getRandomInt(max) {
        return Math.floor(Math.random() * max);
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
                    <img className={styles.cardpic} src={props.coach.coachImageUrl} alt="" />
                </div>
                <div>
                    <div className={styles.name}>
                        <span>{categories.length > 0 ?
                        categories[getRandomInt(categories.length)].name : ""}</span>
                        <span>{props.coach.coachFirstName} {props.coach.coachLastName}</span>
                    </div>
                    <div className={styles.price}>
                        <span>{props.coach.coachPricePerSession}&#8364; per session</span>
                        <span className={styles.imgContainer}><img src={props.coach.coachCompanyLogoUrl} alt="" /></span>
                    </div>
                    <div className={styles.button}>
                        <button className={styles.bookButton} onClick={() => openModal()}>Book</button>
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
                <ModalRemoveCourse handleClose={handleClose} item="coach" />
            </Modal>
        </>
    )
}
