import React from "react"
import { Link } from "react-router-dom";

import styles from "./Signup.module.css";

function Signup() {
    return (

        <section className={styles.container}>
            <div className={styles.picDiv}>
                <img src="/assets/images/Path9.png" className={styles.signupFigure} />
                <img src="assets/images/Group52.png" className={styles.man} />
            </div>
            <div className={styles.buttonAndText}>
                <img src="/assets/images/Group5.png" className={styles.arrow} />
                <Link to="/register" className={styles.buttonForSignUp}>
                    SignUp as Business Owner
                </Link>
                <div className={styles.flex}>
                    <ul className={styles.textOnBottom}>
                        <li className={styles.have}>
                            Already have an account?
                        </li>
                        <Link to="/login" className={styles.login}>
                            LogIn here.
                        </Link>
                    </ul>
                </div>
            </div>
        </section>
    );
}

export default Signup;
