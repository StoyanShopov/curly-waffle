import css from "./CreateLecture.module.css"
import lectureService from "../../../../services/lecture.service.js";

export default function CreateLecture({closeModal}) {

    
    const onLectureCreate = (e) => {
        e.preventDefault();

        let courseData = Object.fromEntries(new FormData(e.currentTarget));

        lectureService
            .create(courseData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setCourses([...props.courses, response.data]);
                }
            })
    }

    return (
        <section className={css.section}>
            <div className={css.container}>
                <form onSubmit={onLectureCreate} method="POST">
                    <div>
                        <button className={css.btnClose} onClick = {() => {closeModal(false)}}>X</button>
                        <p className={css.p}>Add Lecture</p>
                    </div>
                    <div>
                        <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                        <input className={css.imput} required = "required" name="Description" placeholder="Description*"></input>
                        <button className={css.btnCancel} onClick = {() => {closeModal(false)}}>Cancel</button>
                        <input type="submit" value="Add" className={css.btnSubmit} />
                    </div>
                </form>
            </div>
        </section>
    )
}