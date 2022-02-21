import { useEffect , useState} from "react";
import { lectureService } from "../../../../services/lecture.service";
import css from "./EditLecture.module.css"
export default function EditLecture(props) {
    const lectureId = props.lectureId;
    const [lecture, setLecture] = useState({});

    useEffect(() => {
        lectureService.getById(lectureId)
        .then(res =>{
            setLecture(res.data)
            console.log(lecture)
        })
    },[lectureId])

    const onLectureEdit = (e) =>{
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
        <section className={css.section}>
            <div className={css.container}>
                <form onSubmit = {onLectureEdit} method = "PUT">
                    <div>
                        <button className={css.btnClose} onClick={() => { closeEditModal(false) }}>X</button>
                        <p className={css.p}>Edit Lecture</p>
                    </div>
                    <div>
                        <input className={css.imput} required = "required" name="Name" defaultValue={lecture.name} placeholder="Name*"></input>
                        <input className={css.imput} required = "required" name="Description" defaultValue={lecture.description} placeholder="Description*"></input>
                        <button className={css.btnCancel} onClick={() => { closeEditModal(false) }}>Cancel</button>
                        <input type="submit" value="Edit" className={css.btnEdit} />
                    </div>
                </form>
            </div>
        </section>
    )
}
