import Modal from 'react-modal';
import NotificationModal from './NotificationModal';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React, { useEffect, useState } from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";

import { TokenManagement } from '../../helpers';
import { Links } from './Links';
import Notification from '../../SignalR-Notification/Notification'

const NavBar = (props) => {
const [modalIsOpen, setModalIsOpen] = useState(false);

    const [isLogin, setIsLogin] = useState(false); // only for test

    //let user = TokenManagement.getUserData() == null ? null : TokenManagement.getUserData();
    //let status = TokenManagement.getUser() ;
    // useEffect(() => {
    //     user = TokenManagement.getUser() == null ? null : TokenManagement.getUserData();
    //     status = TokenManagement.getUser();
    // }, [])
    
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

    useEffect(() => {
        console.log(props.auth.user)//
    })

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
                </div>
                <div className={styles.homePageButtons}>
                    {props.auth.user != null
                        ? null
                        : unLogged}
                </div>
                {/* }*/}
                {isLogin && <Notification />}
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
                {props.auth.user != null
                    ?
                    <div className={styles.greenCircle}>
                        <NavLink tag={Link} to="profile">{props.auth.user.fullname[0]}</NavLink>
                    </div>
                    : null}
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
const courses = (
    <ul>

        <li>
            <NavLink
                to="admin/courses"
                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
            >
                Courses
            </NavLink>
        </li>
        <li>
            <NavLink
                to="admin/coaches"
                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
            >
                Coaches
            </NavLink>
        </li>
    </ul>
);
const unLogged = (<ul>
    <li>
        <Link to="/login" ><button className={styles.loginButton}>Login</button></Link>
    </li>
    <li>
        <Link to="/request-a-demo" ><button className={styles.requestDemoBtn}>Request a Demo</button></Link>
    </li>
</ul>);
