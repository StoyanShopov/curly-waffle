import styles from "./CoachCard.module.css";
import React, { useEffect, useState } from "react";
import DeleteCoach from "./DeleteCoach";
import { Link } from "react-router-dom";
import EditCoach from "./EditCoach";
import Modal from 'react-modal';

const CoachCard = (props) => {
    const [coach, setCoach] = useState(props.coach)
    const [coaches, setCoaches] = useState(props.coaches)

    useEffect(() => {
      setCoach(coach)
      setCoaches(coaches)
    },[props.coach,props.coaches])
    
      return (
        <div className={styles.card}>
          <div className={styles.upper}>
            <div className={styles.pencil}>
              <Link
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
                <img src="assets/images/Group 87.svg" alt="edit" />
              </Link>
            </div>
            <img className={styles.cardpic} src={coach.imageUrl} alt="" />
          </div>
          <div className={styles.down}>
            <div className={styles.name}>
              <span className={styles.bold}>{"company"}</span>
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
                  src={"logo"}
                  alt="Company logo"
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