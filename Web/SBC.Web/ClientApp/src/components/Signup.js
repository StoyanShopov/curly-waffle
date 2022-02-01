import React from "react"
import { Link } from "react-router-dom";


import SignupFigure from "../assets/Path9.png";
import Man from "../assets/Group52.png";
import css from "./Signup.css";
import Logo from "../assets/Group5.png"
function Signup() {
    return (
        <section> <div className="picDiv">
        <img src={SignupFigure} className="signupFigure" />
        <img src={Man} className="Man"/>
    </div>
    <div className="ButtonAndText">
    <ul>
        <li className="Logo"><img src={Logo}/></li>
        <Link to="/Signup"><li className="Button"><button>SignUp as Business Owner</button></li></Link>
        <li className="TextOnBottom"><p className="have">Already have an account?</p> <Link to="/Login"><p className="login">LogIn here.</p></Link></li>
    </ul>
    </div></section>
       
    );
}

export default Signup;