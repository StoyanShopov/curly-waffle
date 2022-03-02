import React, { useEffect,} from 'react';
import { NavLink, Link } from 'react-router-dom';

import { userService } from '../../services';
import { TokenManagement } from '../../helpers';

import styles from "./Sidebar.module.css";

export default function Sidebar(props) {

    let userData = TokenManagement.getUserData();
    const onLogout = () => {
        userService.logout();
    }

    useEffect(() => {
        userData = TokenManagement.getUserData();
    }, [])

    return (

        <div className={styles.container}>
            <NavLink to="/profileOwner" className={styles.pencilLink}>
                <img src="assets/images/iconmonstr-pencil-2.svg" className={styles.pencil} alt="" />
            </NavLink>
            <div className={styles.namesContainer}>
                <div className={styles.greenCircle}>
                    {userData ? userData.fullname[0] : "N/A"}
                </div>
                <div className={styles.names}>
                    <div className={styles.fullName}>
                        {userData ? userData.fullname : "N/A"}
                    </div>
                    <div className={styles.companyName}>
                        {!props.adminData['company'] ? null : props.adminData['company']}
                    </div>
                </div>
            </div>
            <div className={styles.navigation}>
                <ul>
                    <li><NavLink to="/profileOwner" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
                    <li><NavLink to="/courses" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Courses</NavLink></li>
                    <li><NavLink to="/coaches" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Coaches</NavLink></li> 
                    <li><NavLink to='/ownerEmployees' className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Employees</NavLink></li>
                    <li><NavLink to="/item2" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Invoice</NavLink></li>
                    <li><NavLink to="" className={styles.logout} onClick={onLogout} >Log Out</NavLink></li>
                </ul>
            </div>
        </div>
    );
}
