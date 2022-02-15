import React from "react"
import { Link } from "react-router-dom";

import Logo from "../assets/Group5.png"
import SignupFigure from "../assets/Path9.png";
import Man from "../assets/Group52.png";

import css from "./Signup.module.css";

function Signup() {
    return (
        <section> <div className={css.picDiv}>
        <img src={SignupFigure} className={css.signupFigure} />
        <img src={Man} className={css.Man}/>
    </div>
    <div className={css.ButtonAndText}>
    <ul>
        <li className={css.Logo}><img src={Logo}/></li>
        <Link to="/Signup"><li className={css.Button}><button>SignUp as Business Owner</button></li></Link>
        <li className={css.TextOnBotto}><p className={css.have}>Already have an account?</p> <Link to="/Login"><p className={css.login}>LogIn here.</p></Link></li>
    </ul>
    </div></section>
       
    );
}

export default Signup;