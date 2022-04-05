import { useEffect, useState } from "react";

import style from "./EditLecture.module.css";

import { lectureService } from "../../../../services/lecture-service";

function EditLecture(props) {
    const [lecture, setLecture] = useState({});
    const lectureId = props.lectureId;

    useEffect(() => {
        lectureService.getById(lectureId)
            .then(res => {
                setLecture(res.data)
                console.log(lecture)
            })
    }, [lectureId])

    const onLectureEdit = (e) => {
        e.preventDefault()

        let lectureData = Object.fromEntries(new FormData(e.currentTarget));

        lectureService
            .update(lectureId, lectureData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setLectureCard(response.data);
                }
            });
    }
    return (
        <section className={style.editPage}>
            <p className={style.p}>Edit Lecture</p>
            <button className={style.btnClose} onClick={() => { props.closeModal() }}>&times;</button>

            <form onSubmit={onLectureEdit} method="PUT">
                <div>
                    <input className={style.input} required="required" name="Name" defaultValue={lecture.name} placeholder="Name*" />
                    <input className={style.input} required="required" name="Description" defaultValue={lecture.description} placeholder="Description*" />
                    <div className={style.buttonContainer}>
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" value="Edit" className={style.btnEdit} />
                    </div>
                </div>
            </form>
        </section >
    )
}

export default EditLecture;
