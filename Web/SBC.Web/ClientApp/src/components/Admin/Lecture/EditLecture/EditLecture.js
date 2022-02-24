import { useEffect, useState } from "react";

import style from "./EditLecture.module.css";

import { lectureService } from "../../../../services/lecture.service";

export default function EditLecture(props) {
    const lectureId = props.lectureId;
    const [lecture, setLecture] = useState({});

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
        <section className={style.section}>
            <div className={style.container}>
                <form onSubmit={onLectureEdit} method="PUT">
                    <div>
                        <button className={style.btnClose} onClick={() => { props.closeModal() }}>X</button>
                        <p className={style.p}>Edit Lecture</p>
                    </div>
                    <div>
                        <input className={style.imput} required="required" name="Name" defaultValue={lecture.name} placeholder="Name*"></input>
                        <input className={style.imput} required="required" name="Description" defaultValue={lecture.description} placeholder="Description*"></input>
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" value="Edit" className={style.btnEdit} />
                    </div>
                </form>
            </div>
        </section>
    )
}
