import { resourceService } from "../../../../services/resource.service";
import css from "./CreateResource.module.css"


function CreateResource(props){
    const onResourceCreate = (e) => {
        e.preventDefault();
        
        let resourceData = Object.fromEntries(new FormData(e.currentTarget));
        resourceData.lectureId = props.id
        
        resourceService
            .create(resourceData)
            .then((response) => {
                if (response.status === 200) {
                    props.closeModal();
                    props.setResources([...props.resources, response.data]);
                }
            })
    }
    return(
        <section className={css.section}>
        <div className={css.container}>
            <form onClick={onResourceCreate} method="POST">
                <div>
                    <button className={css.btnClose} onClick = {() => {closeModal(false)}}>X</button>
                    <p className={css.p}>Add Resource</p>
                </div>
                <div>
                <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                    <input className={css.imput} required = "required" name="Fileurl" placeholder="FileUrl*"></input>
                    <input className={css.imput} required = "required" name="Size" placeholder="Size*"></input> 
                    <button className={css.btnCancel} onClick = {() => {closeModal(false)}}>Cancel</button>
                    <input type="submit" value="Add" className={css.btnSubmit} />
                </div>
            </form>
        </div>
    </section>
)
}
export default CreateResource;