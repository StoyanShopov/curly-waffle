import css from "./DeleteLecture.module.css"

export default function DeleteLecture({closeDeleteModal}) {
    return (
        <section className={css.section}>
            <div className={css.topDiv}>
                <button className={css.btnClose} onClick = {() => {closeDeleteModal(false)}}>X</button>
                <p className={css.p}>Are you sure you want to remove this lecture?</p>
            </div>
            <div className={css.bottomDiv}>
            <button className={css.btnCancel} onClick = {() => {closeDeleteModal(false)}}>Cancel</button>
            <button className={css.btnRemove}>Remove</button>
            </div>
        </section>
    )
}