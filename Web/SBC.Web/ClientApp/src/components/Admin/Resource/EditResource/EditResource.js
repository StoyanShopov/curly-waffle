import css from "./EditResource.module.css"
function EditResource(){
    return(
        <section className={css.section}>
            <form>
                <div>
                    <p className={css.p}>Edit Resource</p>
                </div>
                <div>
                <input className={css.imput} placeholder="Id*"></input>
                    <input className={css.imput} placeholder="Name*"></input>
                    <input className={css.imput} placeholder="FileUrl*"></input>
                    <input className={css.imput} placeholder="Size*"></input>
                    <select className={css.imput} >
                    <option value="One">One</option>
                    <option value="Two">Two</option>
                    <option value="Three">Three</option>
                    </select>
                    <input className={css.imput} placeholder="LectureId*"></input>
                    <input type="submit" value="Edit" className={css.btn} />
                </div>
            </form>
        </section>
    )
}
export default EditResource;
