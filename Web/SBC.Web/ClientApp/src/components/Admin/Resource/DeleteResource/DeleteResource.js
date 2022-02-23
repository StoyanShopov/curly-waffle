import style from "./DeleteResource.module.css"

function DeleteResource({ closeModal }) {
    return (
        <div className={style.modalBackground}>
            <div className={style.deleteWindow}>
                <div className={style.topDiv}>
                    <button className={style.closeDelete} onClick={() => { closeModal(false); }}>&times;</button>
                    <p className={style.textQuestion}>Are you sure you want to delete this resource?</p>
                </div>
                <div className={style.bottomDiv}>
                    <div className={style.buttonDiv}>
                        <button className={style.btnCancel} type="button" onClick={() => { closeModal(false); }} id="cancelBtn">Cancel</button>
                        <button className={style.btnDelete} type="submit">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default DeleteResource;
