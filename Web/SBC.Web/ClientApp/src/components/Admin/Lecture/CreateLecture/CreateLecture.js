import style from "./CreateLecture.module.css";

import { lectureService } from "../../../../services/lecture.service.js";

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
                    props.setLectures(prevSkip => [response.data, ...prevSkip]);
                }
            })
            .finally(() => {
                props.setSkipPlusOne();
            })
    }

    return (
        <section className={style.container}>
            <p className={style.p}>Add Lecture</p>
            <button className={style.btnClose} onClick={() => { props.closeModal() }}>&times;</button>
            <form onSubmit={onLectureCreate} method="POST">
                <div>
                    <input className={style.input} required="required" name="Name" placeholder="Name*"></input>
                    <input className={style.input} required="required" name="Description" placeholder="Description*"></input>
                    <div className={style.btnContainer}>
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" value="Add" className={style.btnSubmit} />
                    </div>
                </div>
            </form>
        </section>
    )
}
