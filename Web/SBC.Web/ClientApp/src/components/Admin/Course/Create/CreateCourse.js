import React, { useEffect, useState } from "react";
import style from './CreateCourse.module.css';

import { courseService } from "../../../../services/course-service.js";

const CreateCourse = (props) => {

    const onCourseCreate = (e) => {
        e.preventDefault();

        let courseData = Object.fromEntries(new FormData(e.currentTarget));

        courseService
            .create(courseData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setCourses([...props.courses, response.data]);
                }
            })
    }

    return (
        <section className={style.createPage}>
            <h2 className={style.headingCourse}>Create course</h2>
            <button className={style.closeCreate} onClick={() => { props.closeModal() }}>&times;</button>

            <form id="create-form" onSubmit={onCourseCreate} method="POST">
                <div>
                    <input type="text" className={style.inputContainer} required="required" name="title" placeholder="Title*" />
                    <textarea type="text" className={style.inputContainer} required="required" name="description" placeholder="Description*" ></textarea>
                    <input type="number" className={style.inputContainer} required="required" name="pricePerPerson" placeholder="Price*" />
                    <input type="text" className={style.inputContainer} required="required" name="pictureUrl" placeholder="PictureUrl*" />
                    <input type="text" className={style.inputContainer} required="required" name="videoUrl" placeholder="VideoUrl*" />

                    <select className={style.selectContainer} name="coachId" id="coachId" defaultValue={props.coaches[0].id}>
                        {props.coaches.map(x => <option key={x.id} value={x.id}>{x.firstName + ' ' + x.lastName}</option>)}
                    </select>

                    <select className={style.selectContainer} name="categoryId" defaultValue={props.categories[0].id}>
                        {props.categories.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                    </select>

                    <select className={style.selectContainer} name="languageId" defaultValue={props.languages[0].id}>
                        {props.languages.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                    </select>

                    <div className={style.buttonContainer}>
                        <input type="button" className={style.btnCancel} value="Cancel" onClick={() => { props.closeModal() }} />
                        <input type="submit" className={style.btnSubmit} value="Submit" />
                    </div>
                </div>
            </form>
        </section >
    )
}

export default CreateCourse;
