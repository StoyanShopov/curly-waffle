import React from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./Footer.module.css";

const Footer = () => {

    return (
        <footer>
            <div className={styles.footerContainer}>
                <div>
                    <div className={styles.trapezoid}>
                        <div className={styles.flex}>
                            <ul className={styles.firstColumn}>
                                <li className={styles.logoHeaderRow}>
                                    <img src="assets/images/Group 5.svg" className={styles.logo} />
                                    <h1 className={styles.logoHeader}>upskill</h1>
                                </li>
                                <li><p className={styles.logoText}>Upskill gives everyone the opportunity to grow professionally and develop into a specialist in every field.</p></li>
                                <li><Link to="/get-started"><button className={styles.buttonGetStarted}>Get Started</button></Link></li>
                            </ul>
                            <ul className={styles.secondColumn}>
                                <li><Link to="/company"><p className={styles.company}>Company</p></Link></li>
                                <li><Link to="/about-us"><p className={styles.aboutUs}>About us</p></Link></li>
                                <li><Link to="/contact-us"><p className={styles.contactUs}>Contact Us</p></Link></li>
                                <li><Link to="/privacy-policy"><p className={styles.privacyPolicy}>Privacy Policy</p></Link></li>
                            </ul>
                            <ul className={styles.thirdColumn}>
                                <li><Link to="/services"><p className={styles.services}>Services</p></Link></li>
                                <li><Link to="/courses"><p className={styles.courses}>Courses</p></Link></li>
                                <li><Link to="/coaches"><p className={styles.coaches}>Coaches</p></Link></li>
                                <li><Link to="/requests"><p className={styles.requests}>Requests</p></Link></li>
                            </ul>
                            <ul className={styles.fourthColumn}>
                                <li><Link to="/"><img src="assets/images/Group 12.svg" className={styles.facebookLogo} /></Link></li>
                                <li><Link to="/"><img src="assets/images/Group 13.svg" className={styles.instagramLogo} /></Link> </li>
                                <li><Link to="/"><img src="assets/images/Group 14.svg" className={styles.linkedInLogo} /></Link></li>
                            </ul>
                        </div>
                        <div className={styles.bottom}>
                            <p className={styles.textOnBottom}>&copy; UpSkill {(new Date().getFullYear())}</p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    )
}

export default Footer;
