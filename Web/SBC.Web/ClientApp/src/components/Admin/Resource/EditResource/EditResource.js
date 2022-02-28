import { useState, useEffect } from "react";

import style from "./EditResource.module.css";

import { resourceService } from "../../../../services/resource.service";

const fileTypeEnums = {
    Video: 1,
    Pdf: 2,
    Url: 3,
    Word: 4,
    Image: 5,
    Audio: 6,
}

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

    const onResourceEdit = async (e) => {
        e.preventDefault();

        let resourceData = Object.fromEntries(new FormData(e.currentTarget));
        resourceData.lectureId = lectureId;

        if (resourceData.fileUrl) {
            let blobName = resource.fileUrl.split('/').pop();
            console.log(blobName);
            let deletedFile = await resourceService.deleteFile(blobName);

            let result = await resourceService.uploadFile(resourceData.fileUrl);
            resourceData.fileUrl = result.fileUrl;
        }

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
                        <select type="text" className={style.input} name="fileType" value={resource.fileType}
                            onChange={(e) => setResource(s => ({ ...s, fileType: e.target.value }))}>
                            {Object.keys(fileTypeEnums).map(key => <option key={key} value={key}>{key}</option>)}
                        </select>
                        <input type="number" className={style.input} required="required" name="Size" placeholder="Size*" defaultValue={resource.size} />
                        <input type="file" className={style.input} name="fileUrl" placeholder="File*" />
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" className={style.btnSubmit} value="Submit" />
                    </div>
                </form>
            </div>
        </section>
    )
}
export default EditResource;
