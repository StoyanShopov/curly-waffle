import React from 'react';
import { NavLink, } from 'react-router-dom';

import { userService } from '../../services';
import EditProfile from './EditProfile';

import styles from "./Sidebar.module.css";

export default function Sidebar(props) {
    function onOpenModal(){
        props.modal.openModal(
          <EditProfile closeModal={props.modal.handleClose} user={props.auth.user}  editUser={() => props.editUser()} />,
          null
        )
      }
    return (

        <div className={styles.container}>
            <button className={styles.pencilLink} onClick={() => onOpenModal()}>
                <img className={styles.pencil} src="/assets/images/iconmonstr-pencil-2.svg" alt="" />
            </button>
            <div className={styles.namesContainer}>
                <div className={styles.greenCircle}>
                    {props.auth.user['photoUrl']
                            ? <img className={styles.profilePhoto} src={props.auth.user['photoUrl']} alt="" />
                            : props.auth.user
                                ? props.auth.user.fullname[0]
                                : "N/A"}
                </div>
                <div className={styles.names}>
                    <div className={styles.fullName}>
                        {props.auth.user ? props.auth.user.fullname : "N/A"}
                    </div>
                    <div className={styles.companyName}>
                        {!props.auth.user['companyName'] ? null : props.auth.user.companyName}
                    </div>
                </div>
            </div>
            <div className={styles.navigation}>

                {props.auth.role == "Administrator"
                    ? _adminUrl
                    : props.auth.role == "Owner"
                        ? _ownerUrls
                        : props.auth.role == "Employee"
                            ? _employeeUrl
                            : null}

            </div>
        </div>
    );
}
const onLogout = () => {
    userService.logout();
}
const _ownerUrls = (
    <ul>
        <li><NavLink to="owner/dashboard" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
        <li><NavLink to="owner/courses" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Courses</NavLink></li>
        <li><NavLink to="owner/coaches" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Active Coaches</NavLink></li>
        <li><NavLink to="owner/employees" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Employees</NavLink></li>
        <li><NavLink to="owner/invoice" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Invoice</NavLink></li>
        <li><NavLink to="" className={styles.logout} onClick={onLogout} >Log Out</NavLink></li>
    </ul>
);


const _adminUrl = (
    <ul>
        <li> <NavLink to="admin/dashboard" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
        <li> <NavLink to="admin/clients" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Clients</NavLink></li>
        <li> <NavLink to="admin/revenue" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Revenue</NavLink></li>
        <li><NavLink to="" className={styles.logout} onClick={onLogout} >Log Out</NavLink></li>
    </ul>
);

const _employeeUrl = (
    <ul>
        <li> <NavLink to="employee/dashboard" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Dashboard</NavLink></li>
        <li> <NavLink to="employee/courses" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Courses</NavLink></li>
        <li> <NavLink to="employee/coaches" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Coaches</NavLink></li>
        <li> <NavLink to="employee/achievements" className={({ isActive }) => (isActive ? styles.active : styles.notActive)}>Achievements</NavLink></li>
        <li><NavLink to="" className={styles.logout} onClick={onLogout} >Log Out</NavLink></li>
    </ul>
);

let subtitle = {
    content: {
      top: '55%',
      left: '50%',
      right: 'auto',
      width: '44%',
      height: '500px',
      bottom: 'auto',
      marginTop: '-5%',
      marginRight: '-50%',
      transform: 'translate(-50%, -40%)',
      padding: '0px',
    },
    color: '#f00'
  };