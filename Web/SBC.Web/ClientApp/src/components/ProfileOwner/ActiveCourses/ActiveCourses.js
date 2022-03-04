import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";
import Modal from 'react-modal';

import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import { OwnerService } from '../../../services';
import styles from "./ActiveCourses.module.css";

export default function ActiveCourses() {
    const [showModal, setShowModal] = useState(false);

    const [courses, setCourses] = useState([]);

    useEffect(() => {
        OwnerService.CompanyGetActiveCourses()
            .then(res => {
                setCourses(res.data);
                console.log("courses", res.data);//
            });
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
                    <div className={styles.card}>
                        <div className={styles.imgContainer}>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1221.png" alt="" />
                            <div className={styles.centered}>MARKETING</div>
                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="" onClick={() => setShowModal(true)}><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.imgContainer}>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1225.png" alt="" />
                            <div className={styles.centered}>DESIGN</div>
                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="" onClick={() => setShowModal(true)}><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.card}>
                        <div className={styles.imgContainer}>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1229.png" alt="" />
                            <div className={styles.centered}>HTML&CSS</div>
                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="" onClick={() => setShowModal(true)}><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>
                    
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
