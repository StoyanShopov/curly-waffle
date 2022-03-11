import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';
import styles from "./NavBar.module.css";
import { TokenManagement } from '../../helpers';

const NavBar = (props) => {

    useEffect(() => {
        console.log(props.auth.user)//
    })
   
    return (
        <header className={styles.headerC}>
            <div className={styles.headerContainer}>
                < div className={styles.logoContainer}>
                    <img src="assets/images/Group 5.svg" className={styles.arrow} alt="" />
                    < div className={styles.upskillContainer}>
                        <NavLink to="/" className={styles.upskillLink}>upskill</NavLink>
                    </div>
                </div>
                <div className={styles.testedLinks}>
                    {/*{props.auth.user != null*/}
                    {/*    ? loggedOwner*/}
                    {/*    : null*/}
                    {/*}*/}
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
                    {/*{props.auth.user != null*/}
                    {/*    ? courses*/}
                    {/*    : null}*/}
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
    </ul>
);
const unLogged = (<ul>
    {/* <li>
        <NavLink tag={Link} to="/loginasemployee">Login as Employee</NavLink>
    </li> */}
    <li>
        <Link to="/loginasemployee" ><button className={styles.loginButton}>Login</button></Link>
    </li>
    <li>
        <Link to="/request-a-demo" ><button className={styles.requestDemoBtn}>Request a Demo</button></Link>
    </li>
</ul>);

const loggedOwner = (
    <ul>
        <li>
            <a href="/docs">Swagger</a>
        </li>
        <li>
            <NavLink tag={Link} to="/registerAsOwner">Register</NavLink>
        </li>
        <li>
            <NavLink tag={Link} to="profile">Profile</NavLink>
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
        </li></ul>
);