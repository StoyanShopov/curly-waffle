import React, { useState } from "react";
import CardCourse from '../CardCourse/CardCourse.js';
import CreateModal from '../Create/CreateModal.js';
import style from './AllCourses.module.css';

const AllCourses = () => {
    const [createModal, setCreateModal] = useState(false);

    return (
        <div>
            <section className={style.topSection}>
                <div className={style.leftSide}>
                    <h2 className={style.headerCourses}>Courses</h2>
                    <p className={style.textPage}>Upskill’s goal is to inspire you to master your technical and personal skills and give you the opportunity to gain knowledge from top specialists in various fields.</p>
                </div>
                <div className={style.rightSide}>
                    <img src="./Group 23.png" alt="" className={style.book}/>
                    <img src="./Path 3449.png" alt="" className={style.backgroundClr}/>
                </div>
            </section>
            <section className={style.cardsSection}>
                <CardCourse />
                <CardCourse />
                <CardCourse />
                <CardCourse />
                <CardCourse />
                <div className={style.buttonDiv}>
                    <button className={style.addBtn} onClick={() => { setCreateModal(true); }}><img src="./Group 78.svg" alt="" /></button>
                    {createModal && <CreateModal setCreateModal={setCreateModal} />}
                </div>
            </section >
        </div >
    )
}

export default AllCourses;