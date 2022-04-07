import styles from './Homepage.module.css'
import { Link } from "react-router-dom";
import React from "react";

export default function Main() {
    return (
        <section className={styles.container}>
            <div className={styles.leftHalf}>
                <h2 className={styles.hOne}>Do you want to level up the knowledge of your team?</h2>
                <p className={styles.pOne}>Upskill gives everyone the opportunity to grow professionally and develop into a specialist in every field. We inspire your people to master their skills and become the best version of themselves. Through our unique, personalised, user-friendly experience, your business is ready to reach new heights.</p>
                <Link to="/signUp" ><button className={styles.getStartedBtn}>Get Started</button></Link>
                <div className={styles.divOne}>
                    <img src="/assets/images/Path 6.png" alt="image" className={styles.path6} />
                    <img src="/assets/images/Group 9.png" alt="image" className={styles.image9} />
                </div>
                <p className={styles.pDemo}>Request a Demo</p>
                <p className={styles.pRequestDemo}>Don’t find what you are looking for? We would be more than happy to help you and assist you in everything you need! Let us know about your personal requirements by filling our request form:</p>
                <form className={styles.inputForm}>
                    <div>
                        <input className={styles.inputBase} required="required" placeholder='Name*'></input>
                        <input className={styles.inputOne} required="required" placeholder='Company Name*'></input>
                    </div>
                    <div>
                        <input className={styles.inputBase} required="required" placeholder='Email Address*'></input>
                        <input className={styles.inputOne} required="required" placeholder='Phone number*'></input>
                    </div>
                    <input type="submit" value="Submit" className={styles.submitBtn} />
                </form>
            </div>
            <div className={styles.rightHalf}>

                <div className={styles.picDivOne}>
                    <img src="/assets/images/Path 5.svg" alt="image" className={styles.path5} />
                    <img src="/assets/images/Group 7.png" alt="image" className={styles.image7} />
                </div>
                <div className={styles.textDiv}>
                    <h2 className={styles.hTwo}>What <span className={styles.upskillblue}>UpSkill</span> does?</h2>
                    <p className={styles.pTwo}>We help businesses as well as individuals learn new skills and gain knowledge on various topics while exploring different sources and getting certified. If you need personal time with a specialist, don’t hesitate to book your slot with one of our top coaches.</p>
                </div>
                <div className={styles.buttonsDiv}>
                    <Link to="/replacement-page" ><button className={styles.exploreCoursesBtn}>Explore Courses</button></Link>
                    <Link to="/replacement-page" ><button className={styles.findCoachesBtn}>Find Coaches</button></Link>
                </div>
                <div className={styles.picDiv}>
                    <img src="/assets/images/Path 7.png" className={styles.path7} />
                    <img src="/assets/images/Group 53.svg" className={styles.group53} />
                </div>

            </div>
        </section>
    )
}
