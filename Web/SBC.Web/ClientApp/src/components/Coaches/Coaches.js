import React from "react";
import styles from "../Coaches/Coaches.module.css";
import Modal from 'react-modal';
import DeleteCoach from "./DeleteCoach";
import { useState } from "react";

const Coaches = () => {

  const [modalIsOpen, setModalIsOpen] = useState(false);

  let subtitle = {
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
  };

  function openModal() {
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
        <div className={styles.card}>
          <div className={styles.upper}>
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
              <button onClick={() => openModal()}>Delete</button>
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
        <DeleteCoach closeModal={closeModal}/>
      </Modal>
    </div>
  );
};

export default Coaches;
