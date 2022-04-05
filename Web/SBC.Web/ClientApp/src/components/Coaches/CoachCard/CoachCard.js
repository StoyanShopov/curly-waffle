import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Modal from 'react-modal';

import styles from "./CoachCard.module.css";

import { companyService } from "../../../services/company-service";

import DeleteCoach from "../DeleteCoach/DeleteCoach";
import EditCoach from "../EditCoach/EditCoach";

const CoachCard = (props) => {
    const [coach, setCoach] = useState(props.coach)
    const [coaches, setCoaches] = useState(props.coaches)
    const [companyUrl, setCompanyUrl] = useState();

    useEffect(() => {
        if (coach.companyId !== null) {
            companyService.getEmailById(coach.companyId).then(res => {
                setCompanyUrl(res['logoUrl']);
            })
        }

        setCoach(coach)
        setCoaches(coaches)
    }, [props.coach, props.coaches])

    const coachCategoriesAsArrayOfIds = coach.categories.map(x => x.categoryId)
    const coachCategories = props.categories.filter(x => coachCategoriesAsArrayOfIds.includes(x.value))

    function getRandomInt(max) {
        return Math.floor(Math.random() * max);
    }

    return (
        <div className={styles.card}>
            <div className={styles.upper}>
                <div className={styles.pencil}>
                    <Link
                        className={styles.pencilcardpic}
                        to=""
                        onClick={() => {
                            props.openModal(
                                props.editModalStyle,
                                <EditCoach
                                    closeModal={props.closeModal}
                                    coach={coach}
                                    id={coach.id}
                                    coaches={coaches}
                                    setCoach={setCoach}
                                    setCoaches={setCoaches}
                                    languages={props.languages}
                                    categories={props.categories}
                                />
                            );
                        }}
                    >
                        <img src="/assets/images/Group 87.svg" alt="edit" />
                    </Link>
                </div>
                <img className={styles.cardpic} src={coach.imageUrl} alt="" />
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span className={styles.bold}>{coachCategories.length > 0 ?
                        coachCategories[getRandomInt(coachCategories.length)].label : ""}</span>
                    <span className={styles.names}>
                        {coach.firstName} {coach.lastName}
                    </span>
                </div>
                <div className={styles.price}>
                    <span className={styles.pricePerPerson}>
                        {coach.pricePerSession}€ per person
                    </span>
                    <span>
                        <img
                            className={styles.company}
                            src={companyUrl}
                            alt="Unemployed"
                        />
                    </span>
                </div>
                <div className={styles.buttondiv}>
                    <button
                        className={styles.button}
                        onClick={() => {
                            props.openModal(
                                props.deleteModalStyle,
                                <DeleteCoach
                                    closeModal={props.closeModal}
                                    id={coach.id}
                                    coaches={props.coaches}
                                    setCoaches={props.setCoaches}
                                />
                            );
                        }}
                    >
                        Delete
                    </button>
                </div>
            </div>
            <Modal
                style={props.subtitle}
                isOpen={props.modalIsOpen}
                onAfterOpen={props.afterOpenModal}
                onRequestClose={props.closeModal}
                ariaHideApp={false}
            >
                {props.child}
            </Modal>
        </div>
    );
};
export default CoachCard;
