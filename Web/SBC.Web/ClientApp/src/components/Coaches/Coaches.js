import React from "react";
import styles from "../Coaches/Coaches.module.css";

const Coaches = () => {
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
              <button>Delete</button>
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
      </div>
    </div>
  );
};

export default Coaches;
