import { useCallback, useEffect, useState } from "react";
import Modal from "react-modal/lib/components/Modal";
import { EmployeeService } from "../../../services/employee-service";
import CoachCard from "../../Fragments/CoachCard.js";

import styles from "./EmployeeCoaches.module.css";

export default function EmployeeCoaches() {

    const [coaches, setCoaches] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [child, setChild] = useState();

    Modal.setAppElement('body');

    useEffect(() => {
        EmployeeService.getAllCoaches()
            .then(res => {
                setCoaches(res.data);
            })
    }, []);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    function openModal(child) {
        setChild(child)
        setShowModal(true);
    }
    return (
        <div className={styles.container}>
            <div className={styles.cardscontainer}>
                {coaches.length > 0
                    ? coaches.map(x => <CoachCard key={x.id} coach={x} openModal={openModal} handleClose={handleClose} />)
                    : <h3>No coaches yet</h3>
                }
            </div>
            <Modal
                style={{
                    content: {
                        top: '50%',
                        left: '50%',
                        right: 'auto',
                        width: '30%',
                        height: '40%',
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