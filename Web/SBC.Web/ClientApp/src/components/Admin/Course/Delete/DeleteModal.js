import React from 'react';

import style from "./DeleteModal.module.css";

import { courseService } from '../../../../services/course.service';

const DeleteModal = (props) => {
    const courseId = props.courseId;
    const courses = props.courses.filter(x => x.id !== courseId);

    const onDeleteHandler = (e) => {
        e.preventDefault();

        courseService
            .deleteCourse(courseId)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                }
            })
            .finally(() => {
                props.setCourses(courses);
            })
    }

    return (
        <div className={style.modalBackground}>
            <div className={style.deleteWindow}>
                <div className={style.topDiv}>
                    <button className={style.closeDelete} onClick={() => { props.closeModal() }}>&times;</button>
                    <p className={style.textQuestion}>Are you sure you want to delete this course?</p>
                </div>
                <div className={style.bottomDiv}>
                    <div className={style.buttonDiv}>
                        <button className={style.btnCancel} type="button" onClick={() => { props.closeModal() }} id="cancelBtn">Cancel</button>
                        <button className={style.btnDelete} type="submit" onClick={onDeleteHandler}>Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default DeleteModal;
