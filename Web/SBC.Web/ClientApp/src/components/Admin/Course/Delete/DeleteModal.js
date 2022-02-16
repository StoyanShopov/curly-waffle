import React from 'react';
import style from "./DeleteModal.module.css";

const DeleteModal = (props) => {
    return (
        <div className={style.modalBackground}>
            <div className={style.deleteWindow}>
                <div className={style.topDiv}>
                    <button className={style.closeDelete} onClick={() => { props.closeModal() }}>&times;</button>
                    <p className={style.textQuestion}>Are you sure you want to delete this course?</p>
                </div>
                <div className={style.bottomDiv}>
                    <div className={style.buttonDiv}>
                        <button className={style.btnCancel} type="button" onClick={() => { props.closeModal() }} id="cancelBtn">Cancel</button>
                        <button className={style.btnDelete} type="submit">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default DeleteModal;