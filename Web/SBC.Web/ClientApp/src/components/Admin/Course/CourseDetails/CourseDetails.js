import css from "./CourseDetails.module.css";

export default function CourseDetails() {
    return (
        <section className={css.container}>
            <div className={css.leftPart}>
                <h1 className={css.marketingHeading}>MARKETING</h1>
                <div>
                    <img src="/Rectangle 1396.svg" alt="" />
                </div>
                <div className={css.controllsDiv}>
                    <img src="Polygon 5.svg" className={css.play} alt="" />
                    <img src="iconmonstr-audio-21.svg" className={css.audio} alt="" />
                    <img src="023016 - 024623.svg" className={css.time} alt="" />
                    <img src="iconmonstr-gear-1.svg" className={css.options} alt="" />
                    <img src="iconmonstr-fullscreen-2.svg" className={css.fullScreen} alt="" />
                </div>
                <h2 className={css.descriptionHeading}>Lecture Description</h2>
                <p className={css.pDescription}>This course emphasizes the fundamental language skills of reading, writing, speaking, listening, thinking, viewing and presenting.</p>
                <h2 className={css.instructorHeading}>Instructor</h2>
                <section className={css.lectorSection}>
                    <div>
                        <div className={css.lectorPic}></div>
                    </div>
                    <div>
                        <p className={css.pCreatedBy}>Created by Jim Wilber</p>
                        <img src="image 30.png" className={css.google} alt="" />
                    </div>
                </section>
                <p className={css.pInstructor}>Charles Du led the design of NASA’s first iPhone app (10+ million downloads, 2+ million hits per day, NASA’s Software of the Year Award) and co-founded the Airbnb for cars. He is an award-winning product manager, UX designer, lecturer, and international keynote speaker.</p>
            </div>
            <div className={css.rightPart}>
                <h1 className={css.lecturesHeading}>Lectures</h1>
                <ul className={css.ulLectures}>
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                    <li className={css.liName}>1. Introduction</li>
                    <img src="Line 396.png" className={css.google} alt="" />
                </ul>
                <button className={css.btnViewMore}>View More</button>
            </div>
        </section>
    )
}