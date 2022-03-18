import React, { useEffect, useState } from "react";

import styles from "../Coaches/Coaches.module.css";

import { getAllCoaches, getCategories, getLanguages } from "../../services/adminCoachesService"

import CoachCard from "./CoachCard";
import CreateCoach from "./CreateCoach";
import Modal from 'react-modal';

const Coaches = () => {

    const deleteModalStyle = {
        content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            width: '36%',
            height: '260px',
            bottom: 'auto',
            marginTop: '-5%',
            marginRight: '-50%',
            transform: 'translate(-50%, -25%)',
            padding: '0px',
        },
        color: '#f00'
    }

    const editModalStyle = {
        content: {
            top: '70%',
            left: '50%',
            right: 'auto',
            width: '38%',
            height: '98%',
            bottom: 'auto',
            marginTop: '-5%',
            marginRight: '-50%',
            transform: 'translate(-60%, -50%)',
            padding: '0px',
        },
        color: '#f00'
    }

    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [child, setChild] = useState();
    const [subtitle, setSubtitle] = useState();
    const [coaches, setCoaches] = useState([])
    const [languages, setLanguages] = useState([])
    const [categories, setCategories] = useState([])

    function openModal(style, child) {
        setSubtitle(style);
        setChild(child)
        setModalIsOpen(true);
    }

    function afterOpenModal() {
        subtitle.color = '#f00';
    }

    function closeModal() {
        setModalIsOpen(false);
    }

    useEffect(() => {
        getAllCoaches().then(res => {
            setCoaches(res.data)
        })

        getCategories().then(res => {
            setCategories(res.data.map(x => ({
                value: x.id,
                label: x.name
            })))
        })

        getLanguages().then(res => {
            setLanguages(res.data.map(x => ({
                value: x.id,
                label: x.name
            })))
        })
    }, []);

    return (
        <div className={styles.container}>
            <div className={styles.headcontainer}>
                <div className={styles.textcontainer}>
                    <div></div>
                    <div className={styles.innertext}>
                        <h1>Coaches</h1>
                        <h2>Testing CI/CD ...</h2>
                        <p>
                            Upskill’s goal is to inspire you to master your technical and
                            personal skills and give you the opportunity to gain knowledge
                            from top specialists in various fields.
                        </p>
                    </div>
                </div>
                <div className={styles.imagecontainer}>
                    <img
                        src="assets/images/Path 3449.svg"
                        alt=""
                        className={styles.background}
                    />
                    <img src="assets/images/Group 47.svg" alt="" className={styles.guy} />
                </div>
            </div>
            <div className={styles.cardscontainer}>
                {coaches.map(x => <CoachCard
                    key={x.id}
                    coach={x}
                    openModal={openModal}
                    closeModal={closeModal}
                    deleteModalStyle={deleteModalStyle}
                    editModalStyle={editModalStyle}
                    coaches={coaches}
                    setCoaches={setCoaches}
                    languages={languages}
                    categories={categories} />)}
                <div className={styles.pluscontainer}>
                    <img
                        src="assets/images/Group 79.svg"
                        alt=""
                        className={styles.plus}
                        onClick={() => {
                            openModal(editModalStyle, <CreateCoach
                                closeModal={closeModal}
                                coaches={coaches}
                                setCoaches={setCoaches} />);
                        }}
                    />
                </div>
            </div>
            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
                ariaHideApp={false}
            >
                {child}
            </Modal>
        </div>
    );
};

export default Coaches;
