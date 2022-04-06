import css from './Homepage.module.css'
import { Link } from "react-router-dom";
import React from "react";

export default function Main() {
    return (
        <section className={css.container}>
            <div className={css.leftHalf}>
                <h2 className={css.hOne}>Do you want to level up the knowledge of your team?</h2>
                <p className={css.pOne}>Upskill gives everyone the opportunity to grow professionally and develop into a specialist in every field. We inspire your people to master their skills and become the best version of themselves. Through our unique, personalised, user-friendly experience, your business is ready to reach new heights.</p>
                <Link to="/signUp" ><button className={css.getStartedBtn}>Get Started</button></Link>
                <div className={css.divOne}>
                    <img src="/assets/images/Path 6.png" alt="image" className={css.path6} />
                    <img src="/assets/images/Group 9.png" alt="image" className={css.image9} />
                </div>
                <p className={css.pDemo}>Request a Demo</p>
                <p className={css.pRequestDemo}>Don’t find what you are looking for? We would be more than happy to help you and assist you in everything you need! Let us know about your personal requirements by filling our request form:</p>
                <form className={css.inputForm}>
                    <div>
                        <input className={css.inputBase} required="required" placeholder='Name*'></input>
                        <input className={css.inputOne} required="required" placeholder='Company Name*'></input>
                    </div>
                    <div>
                        <input className={css.inputBase} required="required" placeholder='Email Address*'></input>
                        <input className={css.inputOne} required="required" placeholder='Phone number*'></input>
                    </div>
                    <input type="submit" value="Submit" className={css.submitBtn} />
                </form>
            </div>
            <div className={css.rightHalf}>

                <div className={css.picDivOne}>
                    <img src="/assets/images/Path 5.svg" alt="image" className={css.path5} />
                    <img src="/assets/images/Group 7.png" alt="image" className={css.image7} />
                </div>
                <div className={css.textDiv}>
                    <h2 className={css.hTwo}>What UpSkill does?</h2>
                    <p className={css.pTwo}>We help businesses as well as individuals learn new skills and gain knowledge on various topics while exploring different sources and getting certified. If you need personal time with a specialist, don’t hesitate to book your slot with one of our top coaches.</p>
                </div>
                <div className={css.buttonsDiv}>
                    <Link to="/explore-courses" ><button className={css.exploreCoursesBtn}>Explore Courses</button></Link>
                    <Link to="/find-coaches" ><button className={css.findCoachesBtn}>Find Coaches</button></Link>
                </div>
                <div className={css.picDiv}>
                    <img src="/assets/images/Path 7.png" className={css.path7} />
                    <img src="/assets/images/Group 53.svg" className={css.group53} />
                </div>

            </div>
        </section>
    )
}
