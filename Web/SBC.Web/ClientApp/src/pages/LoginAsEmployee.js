import React from "react";
import styles from "./LoginAsEmployee.module.css";
import arrow from "./../images/Group 5.svg";
import backgnd from "./../images/Path 9.svg";
import woman from "./../images/Group 17.svg";
import eye from "./../images/Icon - Visibility - Filled.svg";

export default function LoginAsEmployee(prop) {
  const link = "Забравена парола?";
  return (
    <div className={styles.container}>
      <div className={styles.left}>
        <img src={backgnd} alt="" className={styles.backgnd} />
        <img src={woman} alt="" className={styles.woman} />
      </div>
      <div className={styles.right}>
        <div className={styles.formContainer}>
          <div className={styles.arrowContainer}>
            <img src={arrow} className={styles.arrow} alt="" />
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
                placeholder="Email Address"
              />
              <span className={styles.testUser}>*</span>
            </div>
            <div>
              <input
                type="text"
                className={`${styles.input} ${styles.inputpass}`}
                placeholder={"Password"}
                required="required"
              />
              <span className={styles.testPass}>*</span>
            </div>
            <div className={styles.checkcontainer}>
              <label htmlFor="check">
                <input
                  type="checkbox"
                  name="check"
                  className={styles.regularcheckbox}
                />
                <span className="checkmark"></span>
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
