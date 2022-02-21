import React from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./Sidebar.module.css";

export default function Sidebar(prop) {
    return (
        <div className={styles.container}>

            <NavLink to="/profileOwner" className={styles.pencilLink}>
                <img src="assets/images/iconmonstr-pencil-2.svg" className={styles.pencil} alt="" />
            </NavLink>
            <div className={styles.namesContainer}>
                <div className={styles.greenCircle}>
                    A
                </div>
                <div className={styles.names}>
                    <div className={styles.fullName}>
                        Aya Krusteva
                    </div>
                    <div className={styles.companyName}>
                        Motion Software
                    </div>
                </div>
            </div>
            <div className={styles.navigation}>
                <ul>
                    <li><NavLink to="/profileOwner" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
                    <li><NavLink to="/courses" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Courses</NavLink></li>
                    <li><NavLink to="/coaches" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Coaches</NavLink></li>
                    <li><NavLink to="/item1" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Item 1</NavLink></li>
                    <li><NavLink to="/item2" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Item 2</NavLink></li>
                    <li><NavLink to="/logout" className={styles.logout}>Log Out</NavLink></li>
                </ul>
            </div>
        </div>
    );
}
