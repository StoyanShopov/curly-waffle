import css from "./TestHomePage.module.css"
import { useState } from "react"
import CreateLecture from "./CreateLecture/CreateLecture";

export default function Home() {
    
    const [openAddFormModal, setOpenAddFormModal] = useState(false);

    return (
        <div >
            <h1>Open Modal</h1>
            <button className={css.openModalBtn} onClick = {() => {setOpenAddFormModal(true)}}>Open</button>
            {openAddFormModal && <CreateLecture closeModal={setOpenAddFormModal}/>}
        </div>
    )
}