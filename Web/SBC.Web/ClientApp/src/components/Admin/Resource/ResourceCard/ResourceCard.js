import { useState } from "react";

import style from "../ResourceCard/ResourceCard.module.css"

import DeleteResource from "../DeleteResource/DeleteResource.js";
import EditResource from "../EditResource/EditResource.js";

export default function ResourceCard(props) {
    const index = props.index;
    const [resource, setResource] = useState(props.resource);

    return (
        <div className={style.container}>
            <p className={style.resourceTitle}>{index + 1}. {resource.name}</p>
            <button className={style.btnEdit} onClick={() => { props.openModal(<EditResource closeModal={props.closeModal} resourceId={resource.id} setResource={setResource} />) }}>Edit</button>
            <button className={style.btnDelete} onClick={() => { props.openModal(<DeleteResource closeModal={props.closeModal} resourceId={resource.id} setResources={props.setResources} resources={props.resources} />) }}>Delete</button>
        </div>
    )
}
