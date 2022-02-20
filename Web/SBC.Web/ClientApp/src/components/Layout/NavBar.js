import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";
import { TokenManagement } from '../../helpers';
import { Links } from './Links';

const NavBar = () => {
    let user = TokenManagement.getUserData() == null ? null : TokenManagement.getUserData();
    let status = TokenManagement.getUser() ;
    useEffect(() => {
        user = TokenManagement.getUser() == null ? null : TokenManagement.getUserData();
        status = TokenManagement.getUser();
    }, [])


    return (
        <header>
            <div className={styles.headerContainer}>
                < div className={styles.logoContainer}>
                    <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    < div className={styles.upskillContainer}>
                        <NavLink to="/" className={styles.upskillLink}>upskill</NavLink>
                    </div>
                </div>
                <div className={styles.coursesCoaches}>
                    <ul> <li>
                        <a href="/docs">Swagger</a>
                    </li></ul>
                    {TokenManagement.getUser() != null
                        ?
                        <ul>
                            <li><Links role={status.role} /></li>
                            <li> <NavLink
                                to="/courses"
                                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                            >
                                Courses
                            </NavLink> </li>
                            <li><NavLink
                                to="/coaches"
                                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                            >
                                Coaches
                            </NavLink> </li>
                        </ul>
                        : <ul>
                            <li><NavLink tag={Link} to="/registerAsOwner">Register</NavLink></li> </ul>
                    }
                </div>

                {TokenManagement.getUser() == null
                    ? <div className={styles.homePageButtons}>
                        <ul>
                            <li><Link to="/loginasemployee" ><button className={styles.loginButton}>Login</button></Link></li>
                            <li><Link to="/request-a-demo" ><button className={styles.requestDemoBtn}>Request a Demo</button></Link></li>
                        </ul>
                    </div>
                    : <div className={styles.greenCircle}>
                        {user==null?'A':user['fullname'][0]}
                    </div>
                }
            </div>
        </header>
    )
}

export default NavBar;
