import { useState } from "react"

import style from "./LectureCard.module.css"

import DeleteLecture from "../DeleteLecture/DeleteLecture"
import EditLecture from "../EditLecture/EditLecture"
import ResourceCard from "../../Resource/ResourceCard/ResourceCard"

export default function LectureCard(props) {
    const [lecture, setLecture] = useState(props.lecture)
    const setLectureDemo = (param) => {
        setLecture(param);
    }

    const onLectureHandler = (e) => {
        if (e.target.tagName === 'H3') {
            let isVisible = e.currentTarget.children[1].style.display === 'block';
            e.currentTarget.children[1].style.display = isVisible ? 'none' : 'block';
            props.setDescription(lecture.description)
        }
    }

    return (
        <div onClick={onLectureHandler}>
            <div className={style.btnsDiv}>
                <h3 className={style.lectureTitle} >{props.index + 1}. {lecture.name}</h3>
                <button className={style.btnDelete} onClick={() => { props.openModal(<DeleteLecture closeModal={props.closeModal} lecture={props.lecture} lectures={props.lectures} setLectures={props.setLectures} />) }
                }>Delete</button>
                <button className={style.btnEdit} onClick={() => { props.openModal(<EditLecture closeModal={props.closeModal} lectureId={lecture.id} setLectureCard={setLectureDemo} />) }} >Edit</button>
            </div>
            <div className={style.resourseDiv}>
                {<ResourceCard />}
            </div>
        </div>
    )
}
