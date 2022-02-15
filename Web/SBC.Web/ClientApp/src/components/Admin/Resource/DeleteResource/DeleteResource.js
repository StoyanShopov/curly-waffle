import css from "./DeleteResource.module.css"

function DeleteResource({closeModal}) {
    return (
        <div className={css.modalBackground}>
            <div className={css.deleteWindow}>
                <div className={css.topDiv}>
                    <button className={css.closeDelete} onClick={() => { closeModal(false); }}>&times;</button>
                    <p className={css.textQuestion}>Are you sure you want to delete this resource?</p>
                </div>
                <div className={css.bottomDiv}>
                    <div className={css.buttonDiv}>
                        <button className={css.btnCancel} type="button" onClick={() => { closeModal(false); }} id="cancelBtn">Cancel</button>
                        <button className={css.btnDelete} type="submit">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
    }
export default DeleteResource;