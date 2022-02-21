import styles from "./CoachCard.module.css";
import React from "react";
import DeleteCoach from "./DeleteCoach";
import { Link } from "react-router-dom";
import EditCoach from "./EditCoach";
import Modal from 'react-modal';

const CoachCard = (props) => {
    return (
        <div className={styles.card}>
            <div className={styles.upper}>
                <div className={styles.pencil}>
                    <Link to="" onClick={() => {props.openModal((props.deleteModalStyle), <EditCoach closeModal={props.closeModal()} />) }}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 25 25">
                            <path id="iconmonstr-pencil-2" d="M19.075,2.946l2.981,2.98L6.4,21.585l-3.732.752L3.417,18.6,19.075,2.946Zm0-2.946L1.5,17.576,0,25l7.424-1.5L25,5.926,19.075,0Z" />
                        </svg>
                    </Link>
                </div>
                <img
                    className={styles.cardpic}
                    src="assets/images/Mask Group 2.png"
                    alt=""
                />
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>Management</span>
                    <span>Timmy Ramsey</span>
                </div>
                <div className={styles.price}>
                    <span>80e per person</span>
                    <span>Google</span>
                </div>
                <div className={styles.button}>
                    <button onClick={() => { props.openModal(props.deleteModalStyle, <DeleteCoach closeModal={props.closeModal} />) }}>Delete</button>
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
    )
}
export default CoachCard