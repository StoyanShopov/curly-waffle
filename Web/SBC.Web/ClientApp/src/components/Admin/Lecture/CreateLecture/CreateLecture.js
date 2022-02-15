import css from "./CreateLecture.module.css"

export default function CreateLecture({closeModal}) {

    return (
        <section className={css.section}>
            <div className={css.container}>
                <form>
                    <div>
                        <button className={css.btnClose} onClick = {() => {closeModal(false)}}>X</button>
                        <p className={css.p}>Add Lecture</p>
                    </div>
                    <div>
                        <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                        <input className={css.imput} required = "required" name="Description" placeholder="Description*"></input>
                        <button className={css.btnCancel} onClick = {() => {closeModal(false)}}>Cancel</button>
                        <input type="submit" value="Add" className={css.btnSubmit} />
                    </div>
                </form>
            </div>
        </section>
    )
}