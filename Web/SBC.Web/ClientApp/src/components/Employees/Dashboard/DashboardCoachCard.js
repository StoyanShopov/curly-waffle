import React, { useState, useCallback, useEffect } from 'react';
import Modal from 'react-modal';

import styles from './DashboardCoachCard.module.css';

import { getCategoriesByCoachId } from '../../../services/categoryService';

import Booking from '../../Fragments/Modals/Booking';

export default function DashboardCoachCard(props) {
    const [showModal, setShowModal] = useState(false);
    const [categories, setCategories] = useState([]);
    const [child, setChild] = useState();

    const coachId = props.coach.coachId;

    useEffect(() => {
        getCategoriesByCoachId(coachId)
            .then(response => {
                setCategories(response.data);
            });
    }, [coachId]);

    function getRandomInt(max) {
        return Math.floor(Math.random() * max);
    }

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);
       

    function openModal(child) {
        setChild(child)
        setShowModal(true);
    }

     const onBook = async (coachId) => {
         openModal(<Booking url={props.coach.scheduling_url}
             openModal={openModal}
             handleClose={handleClose}
             coachId={coachId}
             entity={{
                 coachId: coachId,
                 eType: "Coach",
                 eName: props.coach.fullName,
                 eCompanyName: props.coach.companyName,
                 eCoachImgUrl: props.coach.imageUrl,
                 eCategoryName: props.coach.calendlyName,
                 eDescription: props.coach.description,
                 eVideoUrl: props.coach.videoUrl,
                 eDuration: `${props.coach.duration} minutes discussion`,
                 eResource: `${23} downloadable resources`,
             }}
         />);
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
                         <button className={styles.removeButton} onClick={() => onBook(coachId)}>Book</button> 
                    </div>
                </div>
            </div>
            <Modal
                style={{
                    content: {
                        top: '58%',
                        left: '50%',
                        right: 'auto',
                        width: '65%',
                        height: '79%',
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
            </Modal>
        </>
    )
}
