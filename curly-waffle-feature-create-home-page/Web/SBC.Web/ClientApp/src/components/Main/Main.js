import css from './Main.module.css'
import { Link } from "react-router-dom";
import React from "react";


export default function Main() {
    return (
        <section className={css.about}>
            <div className={css.aboutTitle}>
                <h2 className={css.h1}>Do u want to level
                    up the knowedge
                    of your team ? </h2>
                <p className={css.p1}>Upskill gives everyone the opportunity to grow professionally
                    and develop into a specialist in every field. We inspire your
                    people to master their skills and become the best version of themselves.
                    Through our unique, personalised, user-friendly experience, your business is ready to reach new heights.</p>
                <button className={css.getStartedBtn}>
                    <Link to="/get-started" className={css.getStartedLink}>Get Started</Link>
                </button>
                <div className={css.div1}>
                    <img src="/Group 9.jpg" alt="image" />
                </div>
                <p className={css.pDemo}>Request a Demo</p>
                <form>
                    <div>
                        <input className={css.input} placeholder='Name*'></input>
                        <input className={css.input1} placeholder='Company Name*'></input>
                    </div>
                    <div>
                        <input className={css.input} placeholder='Email Address*'></input>
                        <input className={css.input1} placeholder='Phone number*'></input>
                    </div>
                    <input type="submit" value="Submit" className={css.SubmitBtn} />
                </form>

            </div>
            <div className={css.aboutPages}>
                <div >
                    <div>
                        <img src="/Group 7.jpg" alt="image" className={css.image7} />
                    </div>
                    <div>
                        <h2 className={css.h2}>What UpSkill Does ? </h2>
                        <p className={css.p2}>We help businesses as well as individuals learn
                            new skills and gain knowledge on various topics
                            while exploring different sources and getting certified.
                            If you need personal time with a specialist, don’t hesitate
                            to book your slot with one of our top coaches.</p>
                    </div>
                    <div>
                        <button className={css.exploreCoursesBtn}>
                            <Link to="/explore-courses" className={css.exploreCoursesLink}>Explore Courses</Link>
                        </button>
                        <button className={css.findCoachesBtn}>
                            <Link to="/find-coaches" className={css.findCoachesLink}>Find Coaches</Link>
                        </button>
                    </div>
                    <div className={css.picDiv}>
                        <img src="/Path 7.jpg" className={css.path7} />
                        <img src="/Group 53.svg" className={css.Group53}/>
                    </div>
                </div>
            </div>
        </section>
    )
}