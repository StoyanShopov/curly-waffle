import css from "./DeleteResource.module.css"

function DeleteResource() {
    return (
        <section className={css.section}>
            <div className={css.topDiv}>
                <span className={css.close}>&times;</span>
                <p className={css.p}>Are you sure you want to remove this resource?</p>
            </div>
            <div className={css.bottomDiv}>
            <button className={css.btnCancel}>Cancel</button>
            <button className={css.btnRemove}>Remove</button>
            </div>
        </section>
    )
}
export default DeleteResource;