import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";
import Modal from 'react-modal';

import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import ManagerCourseCard from '../../Fragments/ManagerCourseCard';
import { OwnerService } from '../../../services';
import styles from "./ActiveCourses.module.css";

export default function ActiveCourses() {
    const [showModal, setShowModal] = useState(false);

    const [courses, setCourses] = useState([]);

    useEffect(() => {
        OwnerService.CompanyGetActiveCourses()
            .then(res => {
                setCourses(res.data);
                console.log(res.data)//
            })
    }, []);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    return (
        <>
            <div className={styles.container}>
                <div className={styles.buttonContainer}>
                    <Link to="/courseCatalog" ><button className={styles.manageButton}>Manage</button></Link>
                </div>
                <div className={styles.cardscontainer}>
                    {courses.length > 0
                        ? courses.map(x => <ManagerCourseCard key={x.id} course={x} />)
                        : <h3>No courses yet</h3>
                    }                    
                </div>
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
                <ModalRemoveCourse handleClose={handleClose} />
            </Modal>
        </>
    );
}
