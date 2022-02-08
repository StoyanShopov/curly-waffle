import css from "./EditLecture.module.css"
export default function EditLecture(){
    return(
        <section className={css.section}>
            <form>
                <div>
                    <p className={css.p}>Edit Lecture</p>
                </div>
                <div>
                    <input className={css.imput} placeholder="Name*"></input>
                    <input className={css.imput} placeholder="Description*"></input>
                    <input type="submit" value="Edit" className={css.btn} />
                </div>
            </form>
        </section>
    )
}
