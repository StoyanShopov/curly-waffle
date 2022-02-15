import React, { useState } from "react";
import DeleteModal from "../Delete/DeleteModal.js";
import EditCourse from "../Edit/EditModal.js";
import style from './CardCourse.module.css';

const CardCourse = () => {
    const [deleteModal, setDeleteModal] = useState(false);
    const [editModal, setEditModal] = useState(false);

    return (
            <div className={style.card}>
                <div className={style.imageCourse}>
                    <img className={style.cardImage} src="./Rectangle 1221.png" alt="" />
                    <h2 className={style.courseName}>Course name</h2>
                    <button className={style.pencil} onClick={() => { setEditModal(true); }}><img src="./Group 81.svg" alt="" /></button>
                    {editModal && <EditCourse setEditModal={setEditModal} />}
                </div>
                <div className={style.infoCourse}>
                    <p className={style.cardName}>Course name</p>
                    <p className={style.cardCoach}>Coach name</p>
                    <p className={style.cardPrice}>Price per session</p>
                    <span className={style.cardCompany}>Google</span>
                    <div className={style.cardButtonDiv}>
                        <button className={style.cardDeleteBtn} type="submit" onClick={() => { setDeleteModal(true); }}>Delete</button>
                        {deleteModal && <DeleteModal setDeleteModal={setDeleteModal} />}
                    </div>
                </div>
            </div>

    )
}

export default CardCourse;