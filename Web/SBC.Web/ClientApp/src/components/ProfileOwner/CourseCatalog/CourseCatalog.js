import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";
import Modal from 'react-modal';

import { OwnerService } from '../../../services';
import ManagerCourseCard from '../../Fragments/ManagerCourseCard';
import ModalRemoveCourse from "../Modals/ModalRemoveCourse";
import { CategoriesList } from "./CategoriesList";
import { LanguagesList } from "./LanguagesList";

import styles from "./CourseCatalog.module.css";

export default function CourseCatalog(prop) {
    const [showModal, setShowModal] = useState(false);

    const [courses, setCourses] = useState([]);

    useEffect(() => {
        OwnerService.GetCoursesCatalog()
            .then(res => {
                setCourses(res.data);
                console.log(res.data);//
            });
    }, []);

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
                        <img className={styles.book} src="/assets/images/Group 23.svg" alt="" />
                    </div>
                </div>
                <div className={styles.cardscontainer}>
                    {courses.length > 0
                        ? courses.map(x => <ManagerCourseCard key={x.id} course={x} />)
                        : <h3>No courses yet</h3>
                    }
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
                <ModalRemoveCourse handleClose={handleClose} />
            </Modal>
        </>
    );
}
