import React from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";

const NavBar = () => {

    return (
        <header>
            <div className={styles.headerContainer}>
                < div className={styles.logoContainer}>
                    
                    <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />

                    < div className={styles.upskillContainer}>
                        <a href="/">
                            <b>upskill</b>
                        </a>
                    </div>
                </div>

                < div className={styles.testedLinks}>
                    <ul>
                        <li>
                            <NavLink tag={Link} to="/loginasemployee">Login as Employee</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/register">Register</NavLink>
                        </li>
                        <li>
                            <NavLink tag={Link} to="/docs">Docs</NavLink>
                        </li>
                    </ul>
                </div>

            </div>
        </header>
    )
}

export default NavBar;