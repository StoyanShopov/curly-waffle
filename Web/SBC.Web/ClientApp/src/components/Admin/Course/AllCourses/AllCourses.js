import React, { useState, useEffect } from "react";
import Modal from "react-modal/lib/components/Modal";

import style from './AllCourses.module.css';

import { courseService } from "../../../../services/course.service.js";

import CardCourse from '../CardCourse/CardCourse.js';
import CreateCourse from '../Create/CreateCourse.js';

const AllCourses = () => {
    const [modalIsOpen, setIsOpen] = useState(false);
    const [childModal, setChildModal] = useState(null);
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        courseService.getAll()
            .then(response => {
                setCourses(response.data);
            });
    }, []);

    let subtitle = {
        content: {
            top: '32%',
            left: '50%',
            right: 'auto',
            width: 'auto',
            height: 'auto',
            bottom: '-15%',
            marginTop: '0%',
            marginRight: '0%',
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

    return (
        <div className={style.container}>
            <section className={style.topSection}>
                <div className={style.leftSide}>
                    <h2 className={style.headerCourses}>Courses</h2>
                    <p className={style.textPage}>Upskill’s goal is to inspire you to master your technical and personal skills and give you the opportunity to gain knowledge from top specialists in various fields.</p>
                </div>
                <div className={style.rightSide}>
                    <img src="./Group 23.png" alt="" className={style.book} />
                    <img src="./Path 3449.png" alt="" className={style.backgroundClr} />
                </div>
            </section>
            <section className={style.cardsSection}>
                {courses.length > 0 && courses.map(x => <CardCourse key={x.id}
                    course={x}
                    openModal={openModal}
                    closeModal={closeModal}
                    setCourses={setCourses}
                    courses={courses} />)}
                <div className={style.buttonDiv}>
                    <button className={style.addBtn} onClick={() => {
                        openModal(<CreateCourse
                            closeModal={closeModal}
                            courses={courses}
                            setCourses={setCourses} />)
                    }}>
                        <img src="./Group 78.svg" alt="" />
                    </button>
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
            </section >
        </div >
    )
}
export default AllCourses;
