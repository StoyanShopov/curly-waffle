import React from "react";
import styles from "../Coaches/Coaches.module.css";
import Modal from 'react-modal';
import DeleteCoach from "./DeleteCoach";
import { useState } from "react";
import { Link } from "react-router-dom";
import EditCoach from "./EditCoach";
import CoachCard from "./CoachCard";

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
    content:{
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

  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [child, setChild] = useState();
  const [subtitle, setSubtitle] = useState();

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

        <CoachCard openModal={openModal} closeModal={closeModal} deleteModalStyle={deleteModalStyle} />
        <div className={styles.card}>
          <div className={styles.upper}>
            <div className={styles.pencil}>
              <Link to="" onClick={() => openModal((deleteModalStyle), <EditCoach closeModal={closeModal} />)}>
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
              <button onClick={() => openModal((deleteModalStyle), <DeleteCoach closeModal={closeModal} />)}>Delete</button>
            </div>
          </div>
        </div>

        <div className={styles.card}>
          <div className={styles.upper}>
            <img
              className={styles.cardpic}
              src="assets/images/Mask Group 3.png"
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
              <button>Delete</button>
            </div>
          </div>
        </div>
        <div className={styles.card}>
          <div className={styles.upper}>
            <img
              className={styles.cardpic}
              src="assets/images/Mask Group 9.png"
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
              <button>Delete</button>
            </div>
          </div>
        </div>
        <div className={styles.card}>
          <div className={styles.upper}>
            <img
              className={styles.cardpic}
              src="assets/images/Mask Group 9.png"
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
              <button>Delete</button>
            </div>
          </div>
        </div>
        <div className={styles.card}>
          <div className={styles.upper}>
            <img
              className={styles.cardpic}
              src="assets/images/Mask Group 9.png"
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
              <button>Delete</button>
            </div>
          </div>
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


