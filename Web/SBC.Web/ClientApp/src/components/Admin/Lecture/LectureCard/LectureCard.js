import { useEffect, useState } from "react"

import css from "./LectureCard.module.css"

import DeleteLecture from "../DeleteLecture/DeleteLecture"
import EditLecture from "../EditLecture/EditLecture"
import CreateResource from "../../Resource/CreateResource/CreateResource"
import { resourceService } from "../../../../services/resource.service"

export default function LectureCard(props) {
    const [resources, setResources] = useState([]);
    const [lecture, setLecture] = useState(props.lecture);
    useEffect(() => {
        resourceService.getAll(lecture.id)
            .then(response => { setResources(response.data) })
    }, [])
    const setLectureDemo = (param) => {
        setLecture(param);
    }

    return (
        <div>
            <div className={css.btnsDiv}>
                <h3 className={css.lectureTitle}>{props.index + 1}. {lecture.name}</h3>
                <button className={css.btnAdd} onClick={() => { props.openModal(<CreateResource closeModal={props.closeModal} resources = {resources} setResources = {setResources} lectureId = {lecture.id}  />) }}>Add</button>
                <button className={css.btnDelete} onClick={() => { props.openModal(<DeleteLecture closeModal={props.closeModal} lecture={props.lecture} lectures={props.lectures} setLectures={props.setLectures} />) }
                }>Delete</button>
                <button className={css.pencil} onClick={() => { props.openModal(<EditLecture closeModal={props.closeModal} lectureId={lecture.id} setLectureCard={setLectureDemo} />) }} >Edit</button>
            </div>
            <div>
            </div>
        </div>
    )
}