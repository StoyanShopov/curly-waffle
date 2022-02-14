import css from "./EditResource.module.css"
function EditResource({closeModal}){
    return(
        <section className={css.section}>
        <div className={css.container}>
            <form>
                <div>
                    <button className={css.btnClose} onClick = {() => {closeModal(false)}}>X</button>
                    <p className={css.p}>Edit Resource</p>
                </div>
                <div>
                <input className={css.imput} required = "required" name="Id" placeholder="Id*"></input>   
                <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                    <input className={css.imput} required = "required" name="Fileurl" placeholder="FileUrl*"></input>
                    <input className={css.imput} required = "required" name="Size" placeholder="Size*"></input>
                    <select className={css.imput} name="Select" >
                    <option value="One">One</option>
                    <option value="Two">Two</option>
                    <option value="Three">Three</option>
                    </select>
                    <input className={css.imput} required = "required"  name="LectureId" placeholder="LectureId*"></input>
                    <button className={css.btnCancel} onClick = {() => {closeModal(false)}}>Cancel</button>
                    <input type="submit" value="Edit" className={css.btnSubmit} />
                </div>
            </form>
        </div>
    </section>
)
}
export default EditResource;
