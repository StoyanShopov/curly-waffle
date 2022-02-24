import { useState, useEffect } from 'react';

import style from './EditModal.module.css';

import { courseService } from "../../../../services/course.service.js";

const EditCourse = (props) => {
    const courseId = props.courseId;
    const [course, setCourse] = useState({});
 
    useEffect(() => {
        courseService.getById(courseId)
            .then(course => {
                setCourse(course.data);
                console.log(this.course)
            })
            
    }, []);

    const onCourseEdit = (e) => {
        e.preventDefault();

        let courseData = Object.fromEntries(new FormData(e.currentTarget));

        courseService
            .update(courseId, courseData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setCourse(response.data);
                }           
            });
    }

    return (
        <section className={style.editPage}>
            <h2 className={style.headingCourse}>Edit course</h2>
            <button className={style.closeCreate} onClick={() => { props.closeModal() }}>&times;</button>

            <form id="create-form" onSubmit={onCourseEdit} method="POST">
                <div>
                    <input type="text" className={style.inputContainer} required="required" name="title" defaultValue={course.title} placeholder="Title" />
                    <textarea type="text" className={style.inputContainer} required="required" name="description" defaultValue={course.description} placeholder="Description" ></textarea>
                    <input type="number" className={style.inputContainer} required="required" name="pricePerPerson" defaultValue={course.pricePerPerson} placeholder="Price" />
                    <input type="text" className={style.inputContainer} required="required" name="pictureUrl" defaultValue={course.pictureUrl} placeholder="PictureUrl" />
                    <input type="text" className={style.inputContainer} required="required" name="videoUrl" defaultValue={course.videoUrl} placeholder="VideoUrl" />

                    <select className={style.selectContainer} name="coachId" defaultValue="1">
                        <option value="1">Emil</option>
                        <option value="2">Maria</option>
                        <option value="3">Ivan Ivanov</option>
                    </select>

                    <select className={style.selectContainer} name="categoryId" defaultValue="1">
                        <option value="1">Marketing</option>
                        <option value="2">Design</option>
                        <option value="3">Art</option>
                    </select>

                    <select className={style.selectContainer} name="languageId" defaultValue="1">
                        <option value="1">Spanish</option>
                        <option value="2">German</option>
                        <option value="3">English</option>
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
export default EditCourse;
