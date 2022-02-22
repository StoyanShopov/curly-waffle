import React, { useEffect } from "react";
import styles from "../Coaches/Coaches.module.css";
import Modal from 'react-modal';
import DeleteCoach from "./DeleteCoach";
import { useState } from "react";
import { Link } from "react-router-dom";
import EditCoach from "./EditCoach";
import CoachCard from "./CoachCard";
import { getAllCoaches } from "../../services/adminCoachesService"

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
      height: '520px',
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
  }, []);

  return (
    <div className={styles.container}>
      <div className={styles.headcontainer}>
        <div className={styles.textcontainer}>
          <div></div>
          <div className={styles.innertext}>
            <h1>Coaches</h1>
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
          setCoaches={setCoaches} />)}
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


