import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";

import styles from "./CourseCatalog.module.css";
import Modal from 'react-modal';
import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import { CategoriesList } from "./CategoriesList";
import { LanguagesList } from "./LanguagesList";

export default function CourseCatalog(prop) {
    const [showModal, setShowModal] = useState(false);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    const handleSkip = (skip) => {
        setSkip(prevSkip => {
            return prevSkip + skip;
        });
    }

    const handleClient = (client) => {
        setClients(prevPortions => {
            return [client, ...prevPortions];
        });
    }



    return (
        <>
            <div className={styles.container}>


                <div className={styles.headContainer}>

                    <div className={styles.categoryContainer}>
                        <h3 className={styles.categoryHeader}>Category</h3>
                        <ul className={styles.categoryList}>
                            {CategoriesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <div className="toppings-list-item">
                                            <div className="left-section">
                                                <input
                                                    type="checkbox"
                                                    id={`custom-checkbox-${index}`}
                                                    name={name}
                                                    value={name}
                                                />
                                                <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                            </div>
                                        </div>
                                    </li>
                                );
                            })}

                        </ul>
                    </div>
                    <div className={styles.lineContainer}>
                    </div>

                    <div className={styles.categoryContainer}>
                        <h3 className={styles.categoryHeader}>Languages</h3>
                        <ul className={styles.categoryList}>
                            {LanguagesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <div className="toppings-list-item">
                                            <div className="left-section">
                                                <input
                                                    type="checkbox"
                                                    id={`custom-checkbox-${index}`}
                                                    name={name}
                                                    value={name}
                                                />
                                                <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                            </div>
                                        </div>
                                    </li>
                                );
                            })}

                        </ul>
                    </div>

                    <div className={styles.imageC}>
                        <img className={styles.book} src="assets/images/Group 23.svg" alt="" />
                    </div>


                </div>




                <div className={styles.cardscontainer}>
                    <div className={styles.card}>
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1221.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1225.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1237.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1229.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1232.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1240.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1269.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1270.png" alt="" />
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
                        <div>
                            <img className={styles.cardpic} src="assets/images/Rectangle 1281.png" alt="" />
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
