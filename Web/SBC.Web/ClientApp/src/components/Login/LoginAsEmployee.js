import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import styles from "./LoginAsEmployee.module.css";
import { userActions } from '../../actions/index';

export default function LoginAsEmployee() {

  //reset login status
  //this.props.dispatch(userActions.logout())

  //handle login
    const onLogin = () => {
      e.preventDefault();

      let formData =new FormData(e.currentTarget);

      console.log(formData);
    }

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
          <form action="" onSubmit={onLogin} method="POST">
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
                          <input type="submit" value="Login" />
                          <Link to="/register">SignUp</Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
