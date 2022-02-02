import React from "react";
import styles from "./LoginAsEmployee.module.css";

export default function LoginAsEmployee(prop) {
  const link = "Забравена парола?";
  return (
    <div className={styles.container}>
      <div className={styles.left}>
        <img src="assets/images/Path 9.svg" alt="" className={styles.backgnd} />
        <img src="assets/images/Group 17.svg" alt="" className={styles.woman} />
      </div>
      <div className={styles.right}>
        <div className={styles.formContainer}>
          <div className={styles.arrowContainer}>
              <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
          </div>
          <h1>Welcome back!</h1>
          <h5>Please login to your account</h5>
          <form action="">
            <div className={styles.inputcontainer}>
              <input
                type="text"
                className={`${styles.input} ${styles.inputuser}`}
                name="name"
                required="required"
                id="name"
                placeholder="Email Address*"
              />
            </div>
            <div>
              <input
                type="text"
                className={`${styles.input} ${styles.inputpass}`}
                placeholder={"Password*"}
              />
            </div>
            <div className={styles.checkcontainer}>
              <label htmlFor="">
                <input type="checkbox" name="" />
                Запомни ме
              </label>
              <a href="/">{link}</a>
            </div>
            <div className={styles.btncontainer}>
              <input type="button" value="Login" />
              <input type="button" value="SignUp" />
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
