import React, { useState } from "react";
import { Link } from 'react-router-dom';

import style from './CardCourse.module.css';

import EditCourse from "../Edit/EditModal.js";

import DeleteModal from "../Delete/DeleteModal.js";

const CardCourse = (props) => {
    const [course, setCourse] = useState(props.course);

    const setCourseDemo = (param) => {
        setCourse(param);
    }

    return (
        <div className={style.card}>
            <div className={style.imageCourse}>
                <img className={style.cardImage} src="./Rectangle 1221.png" alt="" />
                <Link to={`/details/${course.id}`}><h2 className={style.courseName}>Course name</h2></Link>
                <button className={style.pencil} onClick={() => { props.openModal(<EditCourse closeModal={props.closeModal} courseId={course.id} setCourse={setCourseDemo} />) }}>
                    <img src="./Group 81.svg" alt="" />
                </button>
            </div>
            <div className={style.infoCourse}>
                <p className={style.cardName}>{course.title}</p>
                <p className={style.cardCoach}>{course.coachFirstName} {course.coachLastName}</p>
                <p className={style.cardPrice}>{course.pricePerPerson.toFixed(2)}&#8364; per person</p>
                <p className={style.cardCompany}>{course.coachCompanyName}</p>
                <div className={style.cardButtonDiv}>
                    <button className={style.cardDeleteBtn} type="submit" onClick={() => { props.openModal(<DeleteModal closeModal={props.closeModal} courseId={course.id} setCourses={props.setCourses} courses={props.courses} />) }}>Delete</button>
                </div>
            </div>
        </div>

    )
}
export default CardCourse;
