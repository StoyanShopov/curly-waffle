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
        <div className={style.deleteWindow}>
        <div className={style.topDiv}>
            <button className={style.closeDelete} onClick={() => { props.closeModal() }}>&times;</button>
            <p className={style.textQuestion}>Are you sure you want to delete this lecture?</p>
        </div>
        <div className={style.bottomDiv}>
            <div className={style.buttonDiv}>
                <button className={style.btnCancel} type="button" onClick={() => { props.closeModal() }} id="cancelBtn">Cancel</button>
                <button className={style.btnDelete} type="submit" onClick={onDeleteHandler}>Delete</button>
            </div>
        </div>
    </div>
    )
}
