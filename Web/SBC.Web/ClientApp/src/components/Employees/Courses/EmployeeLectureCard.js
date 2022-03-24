import { useState, useEffect } from "react"

import style from "./EmployeeLectureCard.module.css"

//import { resourceService } from "../../../../services/resource.service"



import ResourceCard from "../../Admin/Resource/ResourceCard/ResourceCard.js"


export default function LectureCard(props) {
    const [lecture, setLecture] = useState(props.lecture);
    const [resources, setResources] = useState([]);

    // useEffect(() => {
    //     resourceService.getAll(lecture.id)
    //         .then(response => {
    //             setResources(response.data)
    //         });
    // }, []);

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
            </div>
            <div className={style.resourseDiv}>
                {resources.length > 0 && resources.map((r, i) => <ResourceCard key={r.id}
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