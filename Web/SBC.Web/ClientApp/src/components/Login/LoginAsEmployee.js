import React, { useEffect, useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";

import { userActions } from "../../actions/index";

import styles from "./LoginAsEmployee.module.css";
import { GetAdminData } from "../../services/super-admin-service";

const LoginAsEmployee = (props) => {
  const form = useRef();
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

    const dispatch = useDispatch();

    const onChangeEmail = (e) => {
        const email = e.target.value;
        setEmail(email);
    };

    const onChangePassword = (e) => {
        const password = e.target.value;
        setPassword(password);
    };

    const onLogin = async (e) => {
        e.preventDefault();

        await dispatch(userActions.login(email, password));
        await GetAdminData();

        navigate('/');
    };

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
            <img
              src="assets/images/Group 5.svg"
              className={styles.arrow}
              alt=""
            />
          </div>
          <h1>Welcome back!</h1>
          <h5>Please login to your account</h5>
          <form onSubmit={onLogin} ref={form}>
            <div className={styles.inputcontainer}>
              <label htmlFor="email"></label>
              <input
                type="text"
                className={`${styles.input} ${styles.inputuser}`}
                name="email"
                required="required"
                id="name"
                placeholder="Email Address"
                value={email}
                onChange={onChangeEmail}
              />
            </div>
            <div>
              <label htmlFor="password"></label>
              <input
                type="password"
                name="password"
                className={`${styles.input} ${styles.inputpass}`}
                placeholder="Password"
                required="required"
                value={password}
                onChange={onChangePassword}
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
};

export default LoginAsEmployee;
