import { useState, useEffect } from "react"

import style from "./LectureCard.module.css"

import { resourceService } from "../../../../services/resource-service";
import { employeeService } from "../../../../services/employee-service";

import DeleteLecture from "../Delete/DeleteLecture"
import EditLecture from "../Edit/EditLecture"
import ResourceCard from "../../Resources/Card/ResourceCard"
import CreateResource from "../../Resources/Create/CreateResource"

function LectureCard(props) {
    const [lecture, setLecture] = useState(props.lecture);
    const [resources, setResources] = useState([]);

    const isAdmin = props.isAdmin;

    useEffect(() => {
        if (!isAdmin) {
            employeeService
                .getAllResources(lecture.id)
                .then(response => {
                    setResources(response.data)
                });
        } else {
            resourceService
                .getAll(lecture.id)
                .then(response => {
                    setResources(response.data)
                });
        }
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
                {isAdmin && <button className={style.btnDelete} onClick={() => {
                    props.openModal(<DeleteLecture
                        closeModal={props.closeModal}
                        lecture={props.lecture}
                        lectures={props.lectures}
                        setLectures={props.setLectures} />)
                }}>Delete</button>}
                {isAdmin && <button className={style.btnEdit} onClick={() => {
                    props.openModal(<EditLecture
                        closeModal={props.closeModal}
                        lectureId={lecture.id}
                        setLectureCard={setLecture} />)
                }} >Edit</button>}
            </div>
            <div className={style.resourseDiv}>
                {isAdmin && <button className={style.btnAdd} onClick={() => {
                    props.openModal(<CreateResource
                        closeModal={props.closeModal}
                        resources={resources}
                        setResources={setResources}
                        lectureId={lecture.id} />)
                }}>Add Resource</button>}
                {resources.length > 0 && resources.map((r, i) => <ResourceCard
                    key={r.id}
                    isAdmin={isAdmin}
                    openModal={props.openModal}
                    closeModal={props.closeModal}
                    setResources={setResources}
                    setVideo={props.setVideo}
                    index={i}
                    resource={r}
                    resources={resources} />)}
            </div>
        </div>
    )
}

export default LectureCard;
