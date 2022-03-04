import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";
import Modal from 'react-modal';

import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import ManagerCoachCard from '../../Fragments/ManagerCoachCard';
import { OwnerService } from '../../../services';
import styles from "./ActiveCoaches.module.css";

export default function ActiveCoaches() {
    const [coaches, setCoaches] = useState([]);

    const [showModal, setShowModal] = useState(false);

    useEffect(() => {
        OwnerService.CompanyGetActiveCoaches()
            .then(res => {
                setCoaches(res.data)
                console.log(res.data)//
            })
    }, []);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    const handleSkip = (skip) => {
        setSkip(prevSkip => {
            return prevSkip + skip;
        });
    }


    return (
        <>
            <div className={styles.container}>
                <div className={styles.buttonContainer}>
                    <Link to="/coachCatalog" ><button className={styles.manageButton}>Manage</button></Link>
                </div>
                {coaches.length > 0
                    ? coaches.map(x => <ManagerCoachCard key={x.id} coach={x} />)
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
                <ModalRemoveCourse handleClose={handleClose} handleSkip={handleSkip} />
            </Modal>
        </>
    );
}
