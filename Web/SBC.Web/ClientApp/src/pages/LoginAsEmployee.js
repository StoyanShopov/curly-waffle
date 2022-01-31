import React from "react";
import styles from "./LoginAsEmployee.module.css";
import arrow from "./../images/Group 5.svg";
import backgnd from "./../images/Path 9.svg";
import woman from "./../images/Group 17.svg";

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
            <div>
              <input
                type="text"
                className={styles.input}
                name="name"
                required="required"
                id="name"
              />
            </div>
            <div>
              <input
                type="text"
                className={styles.input}
                placeholder={"Password"}
              />
            </div>
            <div >
              <input type="checkbox" name=""  />
              <label htmlFor="">Запомни ме</label>
              <a href="/">{link}</a>
            </div>
            <div>
              <input type="button" value="Login" />
              <input type="button" value="SignUp" />
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
