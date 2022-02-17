import React from "react";
import { Link } from "react-router-dom";
import styles from "./OwnerDashboard.module.css";
import Sidebar from "../../Sidebar/Sidebar";

export default function OwnerDashboard(prop) {
    return (
        <>
            <Sidebar />
                       
            <div className={styles.containerH}>
                <div className={styles.dashboard}>
                    <section className={styles.dashboardHeader} >
                        <article><span>Employees</span><span>12</span></article>
                        <svg width="1" height="126" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <article><span>Courses</span><span style={{ color: "#296CFB" }}>34</span></article>
                        <svg width="1" height="126" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <article><span>Coaches</span><span style={{ color: "#16D696" }}>56</span></article>
                    </section>
                </div>                
            </div >

            <div className={styles.containerT}>
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th className={styles.theadTh}>September</th>                            
                        </tr>                        
                        <svg width="926" height="4" viewBox="0 0 926 4">
                            <line id="Line_49" data-name="Line 49" x2="925" transform="translate(0.5 0.5)" fill="none" stroke="#fff" stroke-linecap="round" stroke-width="2" />
                        </svg>                       
                        <tr className={styles.tableTr}>
                            <th className={styles.firstTh}>Course Name</th>
                            <th className={styles.secondTh}>Enrolled</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr key={1}>
                            <td className={styles.name}>Aya Krusteva</td>
                            <td className={styles.enrolled} >23</td>
                        </tr>
                        <tr key={2}>
                            <td className={styles.name}>Anna Vasileva</td>
                            <td className={styles.enrolled}>45</td>
                        </tr>
                        <tr key={3}>
                            <td className={styles.name}>Victor Georgiev</td>
                            <td className={styles.enrolled}>67</td>
                        </tr>
                        <tr id={styles.flex}>
                            <td>
                                <Link to="/profileOwner" className={styles.link}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div className={styles.containerC}>
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th className={styles.theadTh}>September</th>
                        </tr>
                        <svg width="926" height="4" viewBox="0 0 926 4">
                            <line id="Line_49" data-name="Line 49" x2="925" transform="translate(0.5 0.5)" fill="none" stroke="#fff" stroke-linecap="round" stroke-width="2" />
                        </svg>
                        <tr className={styles.tableTr}>
                            <th className={styles.firstTh}>Coach Name</th>
                            <th className={styles.secondTh}>Sessions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr key={1}>
                            <td className={styles.name}>Brent Foster</td>
                            <td className={styles.enrolled} >12</td>
                        </tr>
                        <tr key={2}>
                            <td className={styles.name}>Phillip Pena</td>
                            <td className={styles.enrolled}>23</td>
                        </tr>
                        <tr key={3}>
                            <td className={styles.name}>Veronica Casey</td>
                            <td className={styles.enrolled}>34</td>
                        </tr>
                        <tr id={styles.flex}>
                            <td>
                                <Link to="/profileOwner" className={styles.link}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>     
        </>
    );
}
