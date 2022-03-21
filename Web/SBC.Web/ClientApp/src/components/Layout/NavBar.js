import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";

const NavBar = (props) => {

    useEffect(() => {
        console.log(props.auth.user)
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

                <div className={styles.coursesCoaches}>
                    {props.auth.role == "Administrator"
                        ? courses
                        : null}
                </div>
                {props.auth.user != null
                    ?
                    <div className={styles.greenCircle}>
                        <NavLink tag={Link} to="profile">{props.auth.user.fullname[0]}</NavLink>
                    </div>
                    : null}
            </div>
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