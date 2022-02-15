import css from "./EditLecture.module.css"
export default function EditLecture({ closeEditModal }) {
    return (
        <section className={css.section}>
            <div className={css.container}>
                <form>
                    <div>
                        <button className={css.btnClose} onClick={() => { closeEditModal(false) }}>X</button>
                        <p className={css.p}>Edit Lecture</p>
                    </div>
                    <div>
                        <input className={css.imput} required = "required" name="Name" placeholder="Name*"></input>
                        <input className={css.imput} required = "required" name="Description" placeholder="Description*"></input>
                        <button className={css.btnCancel} onClick={() => { closeEditModal(false) }}>Cancel</button>
                        <input type="submit" value="Edit" className={css.btnEdit} />
                    </div>
                </form>
            </div>
        </section>
    )
}
