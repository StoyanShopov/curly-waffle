import css from "./CreateResource.module.css"

function CreateResource(){
    return(
        <section className={css.section}>
            <form>
                <div>
                    <p className={css.p}>Add Resource</p>
                </div>
                <div>
                    <input className={css.imput} placeholder="Name*"></input>
                    <input className={css.imput} placeholder="FileUrl*"></input>
                    <input className={css.imput} placeholder="Size*"></input>
                    <select className={css.imput} >
                    <option value="One">One</option>
                    <option value="Two">Two</option>
                    <option value="Three">Three</option>
                    </select>
                    <input className={css.imput} placeholder="LectureId*"></input>
                    <input type="submit" value="Add" className={css.btn} />
                </div>
            </form>
        </section>
    )
}
export default CreateResource;