import { useState } from "react";

import style from "./ResourceCard.module.css"

import DeleteResource from "../Delete/DeleteResource.js";
import EditResource from "../Edit/EditResource.js";

function ResourceCard(props) {
    const [resource, setResource] = useState(props.resource);
    const index = props.index;
    const fileUrl = resource.fileUrl;
    const isAdmin = props.isAdmin;

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
            .{isAdmin && <button className={style.btnDelete} onClick={() => {
                props.openModal(<DeleteResource
                    closeModal={props.closeModal}
                    resource={resource}
                    setResources={props.setResources}
                    resources={props.resources} />)
            }}>Delete</button>}
            {isAdmin && <button className={style.btnEdit} onClick={() => {
                props.openModal(<EditResource
                    closeModal={props.closeModal}
                    resourceId={resource.id}
                    setResource={setResource} />)
            }}>Edit</button>}
        </div>
    )
}

export default ResourceCard;
