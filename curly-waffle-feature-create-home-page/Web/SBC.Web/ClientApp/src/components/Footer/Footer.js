
import React from "react"

import FooterFigure from "../../assets/Path 8.png";
import FooterLOGO from "../../assets/Group 5.png";
import FacebookImg from "../../assets/Group 12.png";
import InstagramImg from "../../assets/Group 13.png";
import LinkedInImg from "../../assets/Group 14.png"

import './Footer.css';

function FooterMenu() {
    return (

      <footer className="FooterMain">
        
      <img src={FooterFigure}/>
      <ul>
          <li><h1 className="LogoHeader">upskill</h1></li>
          <li>  <img src={FooterLOGO} className="Logo"/></li>
          <li><p className="LogoText">Upskill gives everyone the opportunity to grow professionally and develop into a specialist in every field.</p></li>
          <li><button className="ButtonGetStarted">Get Started</button></li>
      </ul>
      <ul>
          <li><h3 className="Company">Company</h3></li>
          <li><h3 className="AboutUs">About us</h3></li>
          <li><h3 className="ContactUs">Contact Us</h3></li>
          <li><h3 className="PrivacyPolicy">Privacy Policy</h3></li>
      </ul>
      <ul>
          <li><h3 className="Services">Services</h3></li>
          <li><h3 className="Courses">Courses</h3></li>
          <li><h3 className="Coaches">Coaches</h3></li>
          <li><h3 className="Requests">Requests</h3></li>
        
      </ul>
      <ul>
      <li>  <img src={FacebookImg} className="FacebookLogo"/></li>
      <li>  <img src={InstagramImg} className="InstagramLogo"/></li>
      <li>  <img src={LinkedInImg} className="LinkedInLogo"/></li>
         
        
      </ul>
      

      <p className="TextOnBottom">&copy; UpSkill {(new Date().getFullYear())}</p>
     
      </footer>
      

		);
}

export default FooterMenu;