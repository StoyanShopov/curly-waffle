import css from "./CreateLecture.module.css"
export default function CreateLecture(){
    return(
        <section className={css.section}>
            <form>
                <div>
                    <p className={css.p}>Add Lecture</p>
                </div>
                <div>
                    <input className={css.imput} name = "Name" placeholder="Name*"></input>
                    <input className={css.imput} name = "Description" placeholder="Description*"></input>
                    <input type="submit" value="Add" className={css.btn} />
                </div>
            </form>
        </section>
    )
}