import style from "./DeleteResource.module.css"

import { resourceService } from "../../../../services/resource.service";

function DeleteResource(props) {
    const resourceId = props.resourceId;
    const resources = props.resources.filter(x => x.id !== resourceId);

    const onDeleteHandler = (e) => {
        e.preventDefault();

        resourceService
            .deleteResource(resourceId)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                }
            })
            .finally(() => {
                props.setResources(resources);
            })
    }

    return (
        <div className={style.modalBackground}>
            <div className={style.deleteWindow}>
                <div className={style.topDiv}>
                    <button className={style.closeDelete} onClick={() => { props.closeModal() }}>&times;</button>
                    <p className={style.textQuestion}>Are you sure you want to delete this resource?</p>
                </div>
                <div className={style.bottomDiv}>
                    <div className={style.buttonDiv}>
                        <button className={style.btnCancel} type="button" onClick={() => { props.closeModal() }} id="cancelBtn">Cancel</button>
                        <button className={style.btnDelete} type="submit" onClick={onDeleteHandler}>Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default DeleteResource;
