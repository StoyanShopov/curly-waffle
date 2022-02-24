import React from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./Footer.module.css";

const Footer = () => {

    return (
        <footer>
            <div className={styles.footerContainer}>
                <div className={styles.footerMain}>
                    {/* <img src="assets/images/Path 8.svg" />*/}
                    <div className={styles.trapezoid}>
                        <ul>
                            <li><h1 className={styles.logoHeader}>upskill</h1></li>
                            <li>  <img src="assets/images/Group 5.svg" className={styles.logo} /></li>
                            <li><p className={styles.logoText}>Upskill gives everyone the opportunity to grow professionally and develop into a specialist in every field.</p></li>
                            <li><Link to="/get-started"><button className={styles.buttonGetStarted}>Get Started</button></Link></li>
                        </ul>
                        <ul>
                            <li> <Link to="/company"><h3 className={styles.company}>Company</h3></Link></li>
                            <li><Link to="/about-us"><h3 className={styles.aboutUs}>About us</h3></Link></li>
                            <li><Link to="/contact-us"><h3 className={styles.contactUs}>Contact Us</h3></Link></li>
                            <li><Link to="/privacy-policy"><h3 className={styles.privacyPolicy}>Privacy Policy</h3></Link></li>
                        </ul>
                        <ul>
                            <li><Link to="/services"><h3 className={styles.services}>Services</h3></Link></li>
                            <li><Link to="/courses"><h3 className={styles.courses}>Courses</h3></Link></li>
                            <li><Link to="/coaches"><h3 className={styles.coaches}>Coaches</h3></Link></li>
                            <li><Link to="/requests"><h3 className={styles.requests}>Requests</h3></Link></li>
                        </ul>
                        <ul>
                            <li>  <Link to="/"><img src="assets/images/Group 12.svg" className={styles.facebookLogo} /></Link></li>
                            <li>  <Link to="/"><img src="assets/images/Group 13.svg" className={styles.instagramLogo} /></Link> </li>
                            <li>  <Link to="/"><img src="assets/images/Group 14.svg" className={styles.linkedInLogo} /></Link></li>
                        </ul>
                        <div>
                            <p className={styles.textOnBottom}>&copy; UpSkill {(new Date().getFullYear())}</p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    )
}

export default Footer;
