import React, { useState } from "react";
import DeleteModal from "../Delete/DeleteModal.js";
import EditModal from "../Edit/EditModal.js";
import './CardCourse.css';

const CardCourse = () => {
    const [deleteModal, setDeleteModal] = useState(false);
    const [editModal, setEditModal] = useState(false);

    return (
            <div className="card">
                <div className="image-course">
                    <img className="card-image" src="./Rectangle 1221.png" alt="" />
                    <h2 className="course-name">Course name</h2>
                    <button className="pencil" onClick={() => { setEditModal(true); }}><img src="./Group 81.svg" alt="" /></button>
                    {editModal && <EditModal setEditModal={setEditModal} />}
                </div>
                <div className="info-course">
                    <p className="card-name">Course name</p>
                    <p className="card-coach">Coach name</p>
                    <p className="card-price">Price per session</p>
                    <span className="card-company">Google</span>
                    <div className="card-button-div">
                        <button className="card-delete-btn" type="submit" onClick={() => { setDeleteModal(true); }}>Delete</button>
                        {deleteModal && <DeleteModal setDeleteModal={setDeleteModal} />}
                    </div>
                </div>
            </div>

    )
}

export default CardCourse;