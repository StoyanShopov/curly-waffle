import axios from "axios";
import { useCallback, useEffect, useState } from "react";
import Modal from "react-modal/lib/components/Modal";
import { calendly_token } from "../../../constants";
import { EmployeeService } from "../../../services/employee-service";
import CoachCard, { getTypeEvents } from "../../Fragments/CoachCard.js";
import ManagerCoachCard from "../../Fragments/ManagerCoachCard";

import styles from "./EmployeeCoaches.module.css";
let i = 1;
export default function EmployeeCoaches() {

    const [coaches, setCoaches] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [child, setChild] = useState();

    Modal.setAppElement('body');

    useEffect(async () => {
        const res = await EmployeeService.getAllCoaches()
        console.log(res)
        setCoaches(res);
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
                {/* {
                    coaches.map(x => { console.log(x.index); return <CoachCard key={i++} coach={x} openModal={openModal} handleClose={handleClose} /> })

                } */}
                {coaches.length > 0
                    ? coaches.map(x => <ManagerCoachCard key={x.id} coach={x} coaches={coaches} setCoaches={setCoaches} isProfile={true} />)
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