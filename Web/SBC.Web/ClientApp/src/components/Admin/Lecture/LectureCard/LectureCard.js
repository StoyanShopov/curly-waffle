import {useState} from "react"

import css from "./LectureCard.module.css"

import DeleteLecture from "../DeleteLecture/DeleteLecture"
import EditLecture from "../EditLecture/EditLecture"
import ResourceCard from "../../Resource/ResourceCard/ResourceCard"

export default function LectureCard(props) {
    const [lecture, setLecture] = useState(props.lecture)
    const setLectureDemo = (param) => {
        setLecture(param);
    }

    return (
        <div>
            <div className={css.btnsDiv}>
                <h3 className={css.lectureTitle}>{props.index + 1}. {lecture.name}</h3>
                <button className={css.btnDelete} onClick = {() => 
                    {props.openModal(<DeleteLecture closeModal = {props.closeModal} lecture = {props.lecture} lectures = {props.lectures} setLectures ={props.setLectures}/>)}
                    }>Delete</button>
                <button className={css.btnEdit} onClick = {() => {props.openModal(<EditLecture closeModal = {props.closeModal} lectureId = {lecture.id} setLectureCard = {setLectureDemo} />)}} >Edit</button>
            </div>
            <div>
                {<ResourceCard />}
                {<ResourceCard />}
            </div>
        </div>
    )
}