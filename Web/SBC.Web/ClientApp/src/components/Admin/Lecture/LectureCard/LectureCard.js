import { useState, useEffect } from "react"

import style from "./LectureCard.module.css"

import { resourceService } from "../../../../services/resource.service"

import DeleteLecture from "../DeleteLecture/DeleteLecture"
import EditLecture from "../EditLecture/EditLecture"
import ResourceCard from "../../Resource/ResourceCard/ResourceCard"
import CreateResource from "../../Resource/CreateResource/CreateResource"

export default function LectureCard(props) {
    const [lecture, setLecture] = useState(props.lecture);
    const [resources, setResources] = useState([]);

    useEffect(() => {
        resourceService.getAll(lecture.id)
            .then(response => {
                setResources(response.data)
            });
    }, []);

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
                <button className={style.btnEdit} onClick={() => { props.openModal(<EditLecture closeModal={props.closeModal} lectureId={lecture.id} setLectureCard={setLecture} />) }} >Edit</button>
            </div>
            <div className={style.resourseDiv}>
                <button className={style.btnAdd} onClick={() => { props.openModal(<CreateResource closeModal={props.closeModal} resources={resources} setResources={setResources} lectureId={lecture.id} />) }}>Add Resource</button>
                {resources.length > 0 && resources.map((r, i) => <ResourceCard key={r.id} resource={r} openModal={props.openModal} closeModal={props.closeModal} setResources={setResources} resources={resources} index={i} />)}
            </div>
        </div>
    )
}
