import React from "react";
import { NavLink } from 'react-router-dom';
import styles from "./RegisterAsOwner.module.css";

export default function RegisterAsOwner(prop) {
    return (
        <div className={styles.container}>
            <div className={styles.left}>
                <img src="assets/images/Path 9.svg" alt="" className={styles.backgnd} />
                <img src="assets/images/Group 51.svg" alt="" className={styles.manWithCase} />
            </div>
            <div className={styles.right}>
                <div className={styles.formContainer}>
                    <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    <form action="" className={styles.inputformsContainer}>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="fullName"
                                required="required"
                                placeholder="Full Name"
                            />
                            <span className={styles.starfullname}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="email"
                                required="required"
                                placeholder="Email Address"
                            />
                            <span className={styles.staremail}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="companyName"
                                required="required"
                                placeholder="Company Name"
                            />
                            <span className={styles.starcompanyname}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="companyEemail"
                                required="required"
                                placeholder="Company Email Address"
                            />
                            <span className={styles.starcompanyemail}>*</span>
                        </div>
                        <div className={styles.inputcontainer}>
                            <input
                                type="text"
                                className={styles.inputuser}
                                name="password"
                                required="required"
                                placeholder={"Password"}
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
