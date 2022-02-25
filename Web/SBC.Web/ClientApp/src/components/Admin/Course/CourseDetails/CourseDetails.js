import { useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";

import style from "./CourseDetails.module.css";

import { courseService } from "../../../../services/course.service.js";
import { lectureService } from "../../../../services/lecture.service.js";

import CreateLecture from "../../Lecture/CreateLecture/CreateLecture"
import LectureCard from "../../Lecture/LectureCard/LectureCard.js";

import Modal from "react-modal/lib/components/Modal";

export default function CourseDetails() {
    const { id } = useParams();
    const [course, setCourse] = useState({});
    const [lectures, setLectures] = useState([]);
    const [description, setDescription] = useState("");
    const [skip, setSkip] = useState(0)

    useEffect(() => {
        lectureService.getAll(id, skip)
            .then(lectureResult => {
                setLectures(lectureResult.data);
            });

            setSkip(prevSkip => prevSkip + 6)
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

    function SkipPlusOne(){
        setSkip(prevSkip => prevSkip + 1)
    }

    function showLectures(args){
        setLectures(prevSkip => [args, ...prevSkip] )
    }

    function onGetNextLectures(){
        lectureService.getAll(id, skip)
        .then(lectureResult => {
            setLectures(prevLectures => [...prevLectures, ...lectureResult.data] );
        });

        setSkip(prevSkip => prevSkip + 6)
    }

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
        <div className={style.background}>
            <section className={style.container}>
                <div className={style.leftPart}>
                    <h1 className={style.marketingHeading}>{course.title}</h1>
                    <div>
                        <img src="/Rectangle 1396.svg" alt="" />
                    </div>
                    <div className={style.controllsDiv}>
                        <img src="Polygon 5.svg" className={style.play} alt="" />
                        <img src="iconmonstr-audio-21.svg" className={style.audio} alt="" />
                        <img src="023016 - 024623.svg" className={style.time} alt="" />
                        <img src="iconmonstr-gear-1.svg" className={style.options} alt="" />
                        <img src="iconmonstr-fullscreen-2.svg" className={style.fullScreen} alt="" />
                    </div>
                    <h2 className={style.descriptionHeading}>Lecture Description</h2>
                    <p className={style.pDescription}>{description === "" ? "" : description}</p>
                    <h2 className={style.instructorHeading}>Instructor</h2>
                    <section className={style.lectorSection}>
                        <div>
                            <div className={style.lectorPic}></div>
                        </div>
                        <div>
                            <p className={style.pCreatedBy}>Created by {course.coachFirstName} {course.coachLastName}</p>
                            <p className={style.pCompanyName}>{course.coachCompanyName}</p>
                        </div>
                    </section>
                    <p className={style.pInstructor}>{course.coachDescription}</p>
                </div>
                <div className={style.rightPart}>
                    <div className={style.lectureList} >
                        <button className={style.btnAddLecture} onClick={() => { openModal(<CreateLecture id={id} closeModal={closeModal} setLectures={setLectures} lectures={lectures} skip = {skip} setSkipPlusOne ={SkipPlusOne}/>)}}>Add Lecture</button>
                        <h1 className={style.lecturesHeading}>Lectures</h1>
                        <ul className={style.ulLectures}>
                            {lectures.length > 0 && lectures.map((x, i) => <LectureCard key={x.id} description={description} setDescription={setDescription} openModal={openModal} closeModal={closeModal} setLectures={setLectures} lectures={lectures} lecture={x} index={i} />)}
                            <img src="Line 396.png" className={style.google} alt="" />
                        </ul>
                        <button className={style.btnViewMore} onClick={onGetNextLectures}>View More</button>
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
