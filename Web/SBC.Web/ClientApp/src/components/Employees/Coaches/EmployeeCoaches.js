import { useCallback, useEffect, useState } from "react";
import Modal from "react-modal/lib/components/Modal";
import { employeeService } from "../../../services/employee-service";
import CoachCard from "../../Fragments/CoachCard";

import styles from "./EmployeeCoaches.module.css";
let i = 1;
export default function EmployeeCoaches() {

    const [coaches, setCoaches] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [child, setChild] = useState();

    Modal.setAppElement('body');

    useEffect(() => {
        employeeService.getAllCoaches().then(res=>{
            setCoaches(res)
        })
    }, []);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    function openModal(child) {
        setChild(child)
        setShowModal(true);
    }

    console.log(coaches);


    return (
        <div className={styles.container}>
            <div className={styles.cardscontainer}>
                {coaches.length > 0
                    ? coaches.map((x, index) => { return <CoachCard key={index} coach={x} openModal={openModal} handleClose={handleClose} /> })
                    : <h3>No coaches yet</h3>
                }
            </div>
            <Modal
                style={{
                    content: {
                        top: '58%',
                        left: '50%',
                        right: 'auto',
                        width: '65%',
                        height: '79%',
                        bottom: 'auto',
                        transform: 'translate(-50%, -50%)',
                        padding: '0px',
                    }
                }}
                isOpen={showModal}
                onRequestClose={handleClose}
                contentLabel="Example Modal"
            >
                {child}
            </Modal>
        </div>
    );
}