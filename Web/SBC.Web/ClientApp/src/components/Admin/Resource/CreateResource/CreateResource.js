import css from "./CreateResource.module.css"
import { resourceService } from "../../../../services/resource.service";


function CreateResource(props) {
    const onResourceCreate = (e) => {
        e.preventDefault();

        let resourceData = Object.fromEntries(new FormData(e.currentTarget));
        resourceData.lectureId = props.lectureId;

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
        <section className={css.section}>
            <div className={css.container}>
                <form onSubmit={onResourceCreate} method="POST">
                    <div>
                        <button className={css.btnClose} onClick={() => { props.closeModal() }}>X</button>
                        <p className={css.p}>Add Resource</p>
                    </div>
                    <div>
                        <input type="text" className={css.input} required="required" name="name" placeholder="Name*"></input>
                        <input type="text" className={css.input} required="required" name="fileurl" placeholder="FileUrl*"></input>
                        <input type="number" className={css.input} required="required" name="size" placeholder="Size*"></input>
                        <input type="file" className={css.input} required="required" name="fileType" placeholder="FileType*"></input>
                        <button className={css.btnCancel} onClick={() => { props.closeModal() }}>Cancel</button>
                        <input type="submit" value="Submit" className={css.btnSubmit} />
                    </div>
                </form>
            </div>
        </section>
    )
}
export default CreateResource;