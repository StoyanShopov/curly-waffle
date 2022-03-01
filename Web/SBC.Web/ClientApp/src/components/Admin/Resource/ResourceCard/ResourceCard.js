import { useState } from "react";

import style from "../ResourceCard/ResourceCard.module.css"

import DeleteResource from "../DeleteResource/DeleteResource.js";
import EditResource from "../EditResource/EditResource.js";

export default function ResourceCard(props) {
    const index = props.index;
    const [resource, setResource] = useState(props.resource);
    const fileUrl = resource.fileUrl;

    const onResourceHandler = () => {
        if (resource.fileType === 'Video') {
            props.setVideo(fileUrl)
        } else if (resource.fileType) {
            window.open(fileUrl);
        }
    }

    return (
        <div className={style.container}>
            <p className={style.resourceTitle} onClick={onResourceHandler}>{index + 1}. {resource.name}</p>           
            .<button className={style.btnEdit} onClick={() => {
                props.openModal(<EditResource
                    closeModal={props.closeModal}
                    resourceId={resource.id}
                    setResource={setResource} />)
            }}>Edit</button>
            <button className={style.btnDelete} onClick={() => {
                props.openModal(<DeleteResource
                    closeModal={props.closeModal}
                    resourceId={resource.id}
                    setResources={props.setResources}
                    resources={props.resources} />)
            }}>Delete</button>
        </div>
    )
}
