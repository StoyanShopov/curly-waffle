import css from "./ResourceTestHomePage.module.css"
import { useState } from "react"
import CreateResource from "./CreateResource/CreateResource";
import EditResource from "./EditResource/EditResource";
import DeleteResource from "./DeleteResource/DeleteResource";

export default function Home() {
    
    const [openAddFormModal, setOpenAddFormModal] = useState(false);

    return (
        <div>
            <h1>Open Modal</h1>
            <button className={css.openModalBtn} onClick = {() => {setOpenAddFormModal(true)}}>Open</button>
            {openAddFormModal && <DeleteResource closeModal={setOpenAddFormModal}/>}
        </div>
    )
}