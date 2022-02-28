import React from "react"
import { Link } from "react-router-dom";

import css from "./Signup.module.css";

function Signup() {
    return (

        <section className={css.container}>
            <div className={css.picDiv}>
                <img src="/assets/images/Path9.png" className={css.signupFigure} />
                <img src="assets/images/Group52.png" className={css.man} />
            </div>
            <div className={css.buttonAndText}>
                <img src="/assets/images/Group5.png" className={css.arrow} />
                <Link to="/registerAsOwner" className={css.buttonForSignUp}>
                    SignUp as Business Owner
                </Link>
                <div className={css.flex}>
                    <ul className={css.textOnBottom}>
                        <li className={css.have}>
                            Already have an account?
                        </li>
                        <Link to="/loginAsEmployee" className={css.login}>
                            LogIn here.
                        </Link>
                    </ul>
                </div>
            </div>
        </section>
    );
}

export default Signup;
