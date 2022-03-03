import React, { useEffect, useState} from 'react';
import { NavLink, } from 'react-router-dom';

import { userService } from '../../services';
import { TokenManagement } from '../../helpers';

import styles from "./Sidebar.module.css";

export default function Sidebar(props) {

    let userData = TokenManagement.getUserData();

    useEffect(() => {
        userData = TokenManagement.getUserData();
    }, [])

    const onLogout = () => {
        userService.logout();
    }

    return (

        <div className={styles.container}>
            <button className={styles.pencilLink} onClick={() => props.showModal()}>
                <img src="assets/images/iconmonstr-pencil-2.svg" className={styles.pencil} alt="" />
            </button>
            <div className={styles.namesContainer}>
                <div className={styles.greenCircle}>
                    {userData ? userData.fullname[0] : "N/A"}
                </div>
                <div className={styles.names}>
                    <div className={styles.fullName}>
                        {userData ? userData.fullname : "N/A"}
                    </div>
                    <div className={styles.companyName}>
                        Motion
                    </div>
                </div>
            </div>
            <div className={styles.navigation}>
                <ul>
                    <li><NavLink to="/managerProfile/dashboard" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
                    <li><NavLink to="/managerProfile/courses" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Courses</NavLink></li>
                    <li><NavLink to="/managerProfile/coaches" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Coaches</NavLink></li>
                    <li><NavLink to='/managerProfile/ownerEmployees' className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Employees</NavLink></li>
                    <li><NavLink to="/managerProfile/invoice" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Invoice</NavLink></li>
                    <li><NavLink to="" className={styles.logout} onClick={onLogout} >Log Out</NavLink></li>
                </ul>
            </div>
        </div>
    );
}
