import React, { useEffect } from 'react';
import Modal from 'react-modal';
import NotificationModal from './NotificationModal';

import { useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";
import { TokenManagement } from '../../helpers';
import { Links } from './Links';

const NavBar = () => {

    const [modalIsOpen, setModalIsOpen] = useState(false);

    let user = TokenManagement.getUserData() == null ? null : TokenManagement.getUserData();
    let status = TokenManagement.getUser() ;
    useEffect(() => {
        user = TokenManagement.getUser() == null ? null : TokenManagement.getUserData();
        status = TokenManagement.getUser();
    }, [])
    
    var message = true;
    
    function openModal() {
        setModalIsOpen(true);
      }
    
      function afterOpenModal() {
        subtitle.color = '#000';
      }
    
      function closeModal() {
        setModalIsOpen(false);
      }

    let subtitle = {
        content: {
          top: '55%',
          left: '50%',
          right: 'auto',
          width: '30%',
          height: '300px',
          bottom: 'auto',
          marginTop: '-5%',
          marginRight: '-50%',
          transform: 'translate(+65%, -70%)',
          padding: '0px',
        },
        color: '#000'
      };


    return (
        <header className={styles.headerC}>
            <div className={styles.headerContainer}>
                < div className={styles.logoContainer}>
                    <img src="/assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    < div className={styles.upskillContainer}>
                        <NavLink to="/" className={styles.upskillLink}>upskill</NavLink>
                    </div>
                </div>
                <div className={styles.testedLinks}>
                    <ul>
                        <li>
                            <NavLink tag={Link} to="/signUp">SignUp</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/loginasemployee">Login as Employee</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/registerAsOwner">Register</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/profileOwner">Owner</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/ownerEmployees">Owner Employees</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/ownerInvoice">Invoice</NavLink>
                        </li>                        
                        <li>
                            <NavLink tag={Link} to="/activeCourses">Active Courses</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/activeCoaches">Active Coaches</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/courseCatalog">Courses</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/coachCatalog">Coaches</NavLink>
                        </li>
                        <li>
                            <a href="/docs">Swagger</a>
                        </li>
                    </ul>
                </div>
                {/* {location.pathname === "/" &&*/}
                <div className={styles.homePageButtons}>
                    <ul>
                        <li>
                            <Link to="/login" ><button className={styles.loginButton}>Login</button></Link>
                        </li>
                        <li>
                            <Link to="/request-a-demo" ><button className={styles.requestDemoBtn}>Request a Demo</button></Link>
                        </li>
                    </ul>
                </div>
                {/* }*/}

                {/*{location.pathname !== "/" &&*/}
                <div className={styles.coursesCoaches}>
                    <ul>
                        <li>
                            <NavLink
                                to="/courses"
                                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                            >
                                Courses
                            </NavLink>
                        </li>
                        <li>
                            <NavLink
                                to="/coaches"
                                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                            >
                                Coaches
                            </NavLink>
                        </li>
                        <li>
                            {message ? 
                            <a c
                                to="/" onClick={() => openModal()}>
                        <i className="fa fa-bell fa-shake fa-lg fa-spin"></i>
                            </a>
                            :
                            <div>
                                <a
                                     onClick={() => openModal()}>
                                    <i className="fa fa-bell fa-lg rotate"></i>
                                </a>
                            </div>
                            }
                        </li>
                    </ul>
                </div>
                <div className={styles.greenCircle}>
                    A
                </div>
            </div>

            <Modal
                style={subtitle}
                isOpen={modalIsOpen}
                onAfterOpen={afterOpenModal}
                onRequestClose={closeModal}
                ariaHideApp={false}
            >
            <NotificationModal closeModal={closeModal}/>
            </Modal>
        </header>
    )
}

export default NavBar;
