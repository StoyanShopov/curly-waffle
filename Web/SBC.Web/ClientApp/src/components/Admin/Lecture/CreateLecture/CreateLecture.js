import css from "./CreateLecture.module.css"
import {lectureService} from "../../../../services/lecture.service.js";

export default function CreateLecture(props) {
    
    const onLectureCreate = (e) => {
        e.preventDefault();

        let lectureData = Object.fromEntries(new FormData(e.currentTarget));
        lectureData.courseId = props.id
        
        lectureService
            .create(lectureData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setLectures([...props.lectures, response.data]);
                }
            })
    }

    return (
        <section className={css.section}>
            <div className={css.container}>
                <form onSubmit={onLectureCreate} method="POST">
                    <div>
                        <button className={css.btnClose} onClick = {() => {props.closeModal()}}>X</button>
                        <p className={css.p}>Add Lecture</p>
                    </div>
                    <div>
                        <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                        <input className={css.imput} required = "required" name="Description" placeholder="Description*"></input>
                        <button className={css.btnCancel} onClick = {() => {props.closeModal()}}>Cancel</button>
                        <input type="submit" value="Add" className={css.btnSubmit} />
                    </div>
                </form>
            </div>
        </section>
    )
}