import React, { useRef, useState } from "react";
import { NavLink, useNavigate } from 'react-router-dom';

import styles from "./RegisterAsOwner.module.css";

import { useDispatch } from 'react-redux';
import { userActions } from '../../actions/index';
import { GetAdminData } from "../../services/super-admin-service";


const RegisterAsOwner = (prop) => {

    const form = useRef();
    const navigate = useNavigate();

    const [fullName, setFullName] = useState('');
    const [companyName, setCompanyName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const dispatch = useDispatch();

    const onChangeFullName = (e) => {
        const fullName = e.target.value;
        setFullName(fullName);
    };

    const onChangeCompanyName = (e) => {
        const companyName = e.target.value;
        setCompanyName(companyName);
    };

    const onChangeEmail = (e) => {
        const email = e.target.value;
        setEmail(email);
    };

    const onChangePassword = (e) => {
        const password = e.target.value;
        setPassword(password);
    };

    const onChangeConfirmPassword = (e) => {
        const confirmPassword = e.target.value;
        setConfirmPassword(confirmPassword);
    };

    const onRegister = async (e) => {
        e.preventDefault();

        await dispatch(userActions.register(fullName, companyName, email, password, confirmPassword));

        await GetAdminData().then(data => {
            //            console.log(data)
        });
        window.location.href = "/";
        // navigate('/');
    }

    return (
        <div className={styles.container}>
            <div className={styles.left}>
                <img src="assets/images/Path 9.svg" alt="" className={styles.backgnd} />
                <img src="assets/images/Group 51.svg" alt="" className={styles.manWithCase} />
            </div>
            <div className={styles.right}>
                <div className={styles.formContainer}>
                    <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    <form onSubmit={onRegister} ref={form} className={styles.inputformsContainer}>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="fullName"
                                required="required"
                                placeholder="Full Name"
                                value={fullName}
                                onChange={onChangeFullName}
                            />
                            <span className={styles.starfullname}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="companyName"
                                required="required"
                                placeholder="Company Name"
                                value={companyName}
                                onChange={onChangeCompanyName}
                            />
                            <span className={styles.starcompanyname}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="email"
                                required="required"
                                placeholder="Email Address"
                                value={email}
                                onChange={onChangeEmail}
                            />
                            <span className={styles.staremail}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="password"
                                required="required"
                                placeholder={"Password"}
                                value={password}
                                onChange={onChangePassword}
                            />
                            <span className={styles.starpassword}>*</span>
                            <img src="assets/images/Eye.svg" className={styles.eye}></img>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="confirmPassword"
                                required="required"
                                placeholder={"Confirm Password"}
                                value={confirmPassword}
                                onChange={onChangeConfirmPassword}
                            />
                            <span className={styles.starconfirmpassword}>*</span>
                            <img src="assets/images/Eye.svg" className={styles.eye}></img>
                        </div>
                        <div className={styles.btncontainer}>
                            <input type="submit" value="SignUp" />
                        </div>
                        <div className={styles.checkcontainer}>
                            <p className={styles.alreadyHave}>
                                Already have an account?
                            </p>
                            <NavLink to="/login" className={styles.loginhere}>
                                Login here
                            </NavLink>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default RegisterAsOwner;
