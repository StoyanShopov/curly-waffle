import css from "./TestHomePage.module.css"
import { useState } from "react"
import CreateLecture from "./CreateLecture/CreateLecture";
import EditLecture from "./EditLecture/EditLecture"
import DeleteLecture from "./DeleteLecture/DeleteLecture"

export default function Home() {
    
    const [openAddFormModal, setOpenAddFormModal] = useState(false);
    const [openEditFormModal, setOpenEditFormModal] = useState(false);
    const [openDeleteModal, setOpenDeleteModal] = useState(false);


    return (
        <div >
            <h1>Open Modal</h1>
            <button className={css.openModalBtn} onClick = {() => {setOpenDeleteModal(true)}}>Open</button>
            {openDeleteModal && <DeleteLecture closeDeleteModal={setOpenDeleteModal}/>}
        </div>
    )
}