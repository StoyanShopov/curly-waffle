import style from "./CreateResource.module.css"

import { resourceService } from "../../../../services/resource-service";

const fileTypeEnums = {
    Video: 1,
    Pdf: 2,
    Url: 3,
    Word: 4,
    Image: 5,
    Audio: 6,
}

function CreateResource(props) {
    const onResourceCreate = async (e) => {
        e.preventDefault();

        let resourceData = Object.fromEntries(new FormData(e.currentTarget));
        resourceData.lectureId = props.lectureId;

        let result = await resourceService.uploadFile(resourceData.fileUrl);
        resourceData.fileUrl = result.photoUrl;

        resourceService
            .create(resourceData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setResources([...props.resources, response.data]);
                }
            })
    }

    return (
        <section className={style.container}>
            <p className={style.p}>Add Resource</p>
            <button className={style.btnClose} onClick={() => { props.closeModal() }}>&times;</button>
            <form onSubmit={onResourceCreate} method="POST">
                <div>
                    <input type="text" className={style.input} required="required" name="name" placeholder="Name*" />
                    <input type="number" className={style.input} required="required" name="size" placeholder="Size*" />
                    <select type="text" className={style.selectContainer} name="fileType">
                        {Object.keys(fileTypeEnums).map(key => <option key={key} value={key}>{key}</option>)}
                    </select>
                    <input type="file" className={style.input} required="required" name="fileUrl" placeholder="File*" />
                    <div className={style.buttonContainer}>
                        <button className={style.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" value="Submit" className={style.btnSubmit} />
                    </div>
                </div>
            </form>
        </section>
    )
}

export default CreateResource;
