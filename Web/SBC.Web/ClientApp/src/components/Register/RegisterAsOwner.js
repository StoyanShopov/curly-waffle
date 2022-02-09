import React from "react";
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
                    <div className={styles.arrowContainer}>
                        <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    </div>
                    <form action="">
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
                        <div>
                            <div className={styles.btncontainer}>
                                <input type="button" value="SignUp" />
                            </div>
                            <br />
                            <div className={styles.checkcontainer}>
                                < div>
                                    <a href="/Login">
                                        <p>Already have an account?
                                        </p>
                                    </a>
                                </div>
                                < div className={styles.loginhere}>
                                    <a href="/Login">
                                        <b>Login here</b>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}
