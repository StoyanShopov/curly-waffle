import React from "react"
import { Link } from "react-router-dom";

import css from "./Signup.module.css";

function Signup() {
    return (

        <section className={css.container}> <div className={css.picDiv}>
            <img src="/assets/images/Path9.png" className={css.signupFigure} />
            <img src="assets/images/Group52.png" className={css.Man} />
        </div>
            <div className={css.ButtonAndText}>
                <ul className={css.ulForSignup}>
                    <li className={css.Logo}><img src="/assets/images/Group5.png" /></li>
                    <Link to="/Signup"><li><button className={css.ButtonForSignUp}>SignUp as Business Owner</button></li></Link>
                    <li className={css.TextOnBottom}><p className={css.have}>Already have an account?</p> <Link to="/Login"><p className={css.login}>LogIn here.</p></Link></li>
                </ul>
            </div>
        </section>
    );
}

export default Signup;
