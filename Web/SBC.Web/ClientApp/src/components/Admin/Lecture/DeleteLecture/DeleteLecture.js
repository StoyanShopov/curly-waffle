import css from "./DeleteLecture.module.css"

export default function DeleteLecture() {
    return (
        <section className={css.section}>
            <div className={css.topDiv}>
                <span className={css.close}>&times;</span>
                <p className={css.p}>Are you sure you want to remove this course?</p>
            </div>
            <div className={css.bottomDiv}>
            <button className={css.btnCancel}>Cancel</button>
            <button className={css.btnRemove}>Remove</button>
            </div>
        </section>
    )
}