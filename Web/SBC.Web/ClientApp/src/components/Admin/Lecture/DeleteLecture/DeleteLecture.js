import css from "./DeleteLecture.module.css"
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
        <section className={css.section}>
            <div className={css.topDiv}>
                <button className={css.btnClose} onClick = {() => {props.closeModal()}}>X</button>
                <p className={css.p}>Are you sure you want to remove this lecture?</p>
            </div>
            <div className={css.bottomDiv}>
            <button className={css.btnCancel} onClick = {() => {props.closeModal()}}>Cancel</button>
            <button className={css.btnRemove} onClick = {onDeleteHandler}>Remove</button>
            </div>
        </section>
    )
}
