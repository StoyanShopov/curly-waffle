import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";

import styles from "./CoachCatalog.module.css";
import Modal from 'react-modal';
import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import { CategoriesList } from "../CourseCatalog/CategoriesList";
import { LanguagesList } from "../CourseCatalog/LanguagesList";

export default function CoachCatalog(prop) {
    const [showModal, setShowModal] = useState(false);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    return (
        <>
            <div className={styles.container}>
                <div className={styles.headContainer}>
                    <div className={styles.categoryContainer}>
                        <h3>Category</h3>
                        <ul className={styles.categoryList}>
                            {CategoriesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <input
                                            type="checkbox"
                                            id={`custom-checkbox-${index}`}
                                            name={name}
                                            value={name}
                                        />
                                        <span></span>
                                        <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                        <span></span>
                                    </li>
                                );
                            })}
                        </ul>
                    </div>
                    <div className={styles.lineContainer}>
                    </div>
                    <div className={styles.categoryContainer}>
                        <h3>Languages</h3>
                        <ul className={styles.languageList}>
                            {LanguagesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <input
                                            type="checkbox"
                                            id={`custom-checkbox-${index}`}
                                            name={name}
                                            value={name}
                                        />
                                        <span></span>
                                        <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                        <span></span>
                                    </li>
                                );
                            })}
                        </ul>
                    </div>
                    <div className={styles.imageC}>
                        <img className={styles.megaphone} src="assets/images/Group 49.svg" alt="" />
                    </div>
                </div>
                <div className={styles.cardscontainer}>
                    <div className={styles.card + ' ' + styles.removeCard}>
                        <div className={styles.upper}>
                            <img className={styles.cardpic} src="assets/images/Mask Group 2.png" alt="" />
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
                    <div className={styles.card + ' ' + styles.removeCard}>
                        <div className={styles.upper}>
                            <img className={styles.cardpic} src="assets/images/Mask Group 3.png" alt="" />
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
                        <div className={styles.upper}>
                            <img className={styles.cardpic} src="assets/images/Mask Group 10.png" alt="" />
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
                                <Link to="add"><button className={styles.removeButton}>Add</button></Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img className={styles.cardpic} src="assets/images/Mask Group 7.png" alt="" />
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
                                <Link to="add"><button className={styles.removeButton}>Add</button></Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img className={styles.cardpic} src="assets/images/Mask Group 8.png" alt="" />
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
                                <Link to="add"><button className={styles.removeButton}>Add</button></Link>
                            </div>
                        </div>
                    </div>
                </div>
                <div className={styles.buttonContainer}>
                    <Link to="/manage" ><button className={styles.manageButton}>View More</button></Link>
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
                <ModalRemoveCourse handleClose={handleClose} handleSkip={handleSkip} handleClient={handleClient} />
            </Modal>
        </>
    );
}
