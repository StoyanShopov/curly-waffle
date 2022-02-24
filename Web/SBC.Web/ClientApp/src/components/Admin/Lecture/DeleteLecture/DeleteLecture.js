import style from "./DeleteLecture.module.css";

import { lectureService } from "../../../../services/lecture.service";

export default function DeleteLecture(props) {
    const lectureId = props.lecture.id;
    const lectures = props.lectures.filter(x => x.id !== lectureId);

    const onDeleteHandler = (e) => {
        e.preventDefault();

        lectureService
            .deleteLecture(lectureId)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                }
            })
            .finally(() => {
                props.setLectures(lectures);
            })
    }

    return (
        <section className={style.section}>
            <div className={style.topDiv}>
                <button className={style.btnClose} onClick={() => { props.closeModal() }}>X</button>
                <p className={style.p}>Are you sure you want to remove this lecture?</p>
            </div>
            <div className={style.bottomDiv}>
                <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                <button className={style.btnRemove} onClick={onDeleteHandler}>Delete</button>
            </div>
        </section>
    )
}
