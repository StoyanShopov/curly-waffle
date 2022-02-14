import css from "./DeleteResource.module.css"

function DeleteResource({closeModal}) {
    return (
        <section className={css.section}>
            <div className={css.topDiv}>
          
            <button className={css.close} onClick = {() => {closeModal(false)}}>X</button>
                <p className={css.p}>Are you sure you want to remove this resource?</p>
            </div>
            <div className={css.bottomDiv}>
            <button className={css.btnCancel} onClick = {() => {closeModal(false)}}>Cancel</button>
            <input type="submit" value="Remove" className={css.btnSubmit} />
            </div>
        </section>
    )
}
export default DeleteResource;