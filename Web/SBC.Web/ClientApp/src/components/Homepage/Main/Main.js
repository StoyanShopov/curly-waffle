import css from './Main.module.css'
import { Link } from "react-router-dom";
import React from "react";


export default function Main() {
    return (
        <section className={css.container}>
            <div className={css.leftHalf}>
                <h2 className={css.hOne}>Do u want to levelup the knowedgeof your team ? </h2>
                <p className={css.pOne}>Upskill gives everyone the opportunity to grow professionally
                    and develop into a specialist in every field. We inspire your
                    people to master their skills and become the best version of themselves.
                    Through our unique, personalised, user-friendly experience, your business is ready to reach new heights.</p>               
                    <Link to="/get-started" ><button className={css.getStartedBtn}>Get Started</button></Link>             
                <div className={css.divOne}>
                    <img src="assets/images/Group 9.jpg" alt="image" />
                </div>
                <p className={css.pDemo}>Request a Demo</p>
                <form>
                    <div>
                        <input className={css.inputBase} placeholder='Name*'></input>
                        <input className={css.inputOne} placeholder='Company Name*'></input>
                    </div>
                    <div>
                        <input className={css.inputBase} placeholder='Email Address*'></input>
                        <input className={css.inputOne} placeholder='Phone number*'></input>
                    </div>
                    <input type="submit" value="Submit" className={css.submitBtn} />
                </form>
            </div>
            <div className={css.rightHalf}>
                <div >
                    <div>
                        <img src="assets/images/Group 7.jpg" alt="image" className={css.image7} />
                    </div>
                    <div>
                        <h2 className={css.hTwo}>What UpSkill Does ? </h2>
                        <p className={css.pTwo}>We help businesses as well as individuals learn
                            new skills and gain knowledge on various topics
                            while exploring different sources and getting certified.
                            If you need personal time with a specialist, don’t hesitate
                            to book your slot with one of our top coaches.</p>
                    </div>
                    <div>             
                         <Link to="/explore-courses" ><button className={css.exploreCoursesBtn}>Explore Courses</button></Link>                       
                         <Link to="/find-coaches" ><button className={css.findCoachesBtn}>Find Coaches</button></Link>                      
                    </div>
                    <div className={css.picDiv}>
                        <img src="assets/images/Path 7.jpg" className={css.path7} />
                        <img src="assets/images/Group 53.svg" className={css.Group53}/>
                    </div>
                </div>
            </div>
        </section>
    )
}