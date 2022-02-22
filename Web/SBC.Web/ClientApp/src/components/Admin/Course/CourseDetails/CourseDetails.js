import { useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { courseService } from "../../../../services/course.service.js";
import { lectureService } from "../../../../services/lecture.service.js";
import Modal from "react-modal/lib/components/Modal";
import css from "./CourseDetails.module.css";
import CreateLecture from "../../Lecture/CreateLecture/CreateLecture"
import LectureCard from "../../Lecture/LectureCard/LectureCard.js";

export default function CourseDetails() {
    const { id } = useParams();
    const [course, setCourse] = useState({});
    const [lectures, setLectures] = useState([]);

    useEffect(() => {
        lectureService.getAll(id)
            .then(lectureResult => {
                setLectures(lectureResult.data);
            });
    }, []);

    const [modalIsOpen, setIsOpen] = React.useState(false);
    const [childModal, setChildModal] = useState(null);

    let subtitle = {
        content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            width: '44%',
            height: '500px',
            bottom: 'auto',
            marginTop: '-5%',
            marginRight: '-50%',
            transform: 'translate(-50%, -20%)',
            padding: '0px',
        },
        color: '#f00'
    };

    function openModal(childElement) {
        setChildModal(childElement);
        setIsOpen(true);
    }

    function afterOpenModal() {
        subtitle.color = '#f00';
    }

    function closeModal() {
        setIsOpen(false);
    }

    useEffect(() => {
        courseService.getById(id)
            .then(course => {
                setCourse(course.data);
            })
    }, [id]);

    return (
        <div className={css.background}>
            <section className={css.container}>
                <div className={css.leftPart}>
                    <h1 className={css.marketingHeading}>{course.title}</h1>
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
                    <div className={css.lectureList} >
                        <button className={css.btnAddLecture} onClick={() => { openModal(<CreateLecture id={id} closeModal={closeModal} setLectures={setLectures} lectures={lectures} />) }}>Add Lecture</button>
                        <h1 className={css.lecturesHeading}>Lectures</h1>
                        <ul className={css.ulLectures}>
                            {lectures.length > 0 && lectures.map((x, i) => <LectureCard key={x._id} openModal={openModal} closeModal={closeModal} setLectures={setLectures} lectures={lectures} lecture={x} index={i} />)}
                            <img src="Line 396.png" className={css.google} alt="" />
                        </ul>
                        <button className={css.btnViewMore}>View More</button>
                    </div>
                    <Modal
                        style={subtitle}
                        isOpen={modalIsOpen}
                        onAfterOpen={afterOpenModal}
                        onRequestClose={closeModal}
                        ariaHideApp={false}
                    >
                        {childModal}
                    </Modal>
                </div>
            </section>
        </div>
    )
}