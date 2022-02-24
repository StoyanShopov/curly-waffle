import { useState, useEffect } from "react";

import style from "./EditResource.module.css";

import { resourceService } from "../../../../services/resource.service";

function EditResource(props) {
    const resourceId = props.resourceId;
    const [resource, setResource] = useState({});
    const lectureId = resource.lectureId;

    useEffect(() => {
        resourceService.getById(resourceId)
            .then(response => {
                setResource(response.data);
            })
    }, [resourceId]);

    const onResourceEdit = (e) => {
        e.preventDefault();

        let resourceData = Object.fromEntries(new FormData(e.currentTarget));
        resourceData.lectureId = lectureId;

        resourceService
            .update(resourceId, resourceData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setResource(response.data);
                }
            });
    }

    return (
        <section className={style.section}>
            <div className={style.container}>
                <form onSubmit={onResourceEdit} method="PUT">
                    <div>
                        <button className={style.btnClose} onClick={() => { props.closeModal() }}>X</button>
                        <p className={style.p}>Add Resource</p>
                    </div>
                    <div>
                        <input type="text" className={style.input} required="required" name="Name" placeholder="Name*" defaultValue={resource.name} />
                        <input type="text" className={style.input} required="required" name="Fileurl" placeholder="FileUrl*" defaultValue={resource.fileUrl} />
                        <input type="number" className={style.input} required="required" name="Size" placeholder="Size*" defaultValue={resource.size} />
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" className={style.btnSubmit} value="Submit" />
                    </div>
                </form>
            </div>
        </section>
    )
}
export default EditResource;
