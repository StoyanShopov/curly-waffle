import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import { ownerService } from '../../../services/owner-service'

import styles from "./OwnerDashboard.module.css";

export default function OwnerDashboard() {
    const [items, setItems] = useState({});

    useEffect(() => {
        ownerService.getOwnerDashboard()
            .then(res => {
                setItems(res.data);
                console.log(res.data)//
            })
    }, [])

    return (
        <>
            <div className={styles.containerH}>
                <div className={styles.dashboard}>
                    <section className={styles.dashboardHeader} >
                        <article><span>Employees</span><span>{items.employeesCount}</span></article>
                        <svg width="1" height="126" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <article><span>Courses</span><span style={{ color: "#296CFB" }}>{items.coursesCount}</span></article>
                        <svg width="1" height="126" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <article><span>Coaches</span><span style={{ color: "#16D696" }}>{items.coachesCount}</span></article>
                    </section>
                </div>
            </div >
            <div className={styles.containerT}>
                <table className={styles.tableContainer}>
                    <thead>
                        <tr className={styles.theadTr}>
                            <th className={styles.theadTh}>
                                <svg width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1035" data-name="Path 1035" d="M10,108.541a1.4,1.4,0,0,1-.99-.41l-8.6-8.6a1.4,1.4,0,0,1,1.981-1.981L10,105.16l7.609-7.609a1.4,1.4,0,0,1,1.98,1.981l-8.6,8.6A1.4,1.4,0,0,1,10,108.541Z" transform="translate(108.541 -0.001) rotate(90)" fill="#fff" />
                                </svg>
                            </th>
                            <th>September</th>
                            <th className={styles.theadTh}>
                                <svg width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1034" data-name="Path 1034" d="M10,0a1.4,1.4,0,0,0-.99.41L.41,9.01A1.4,1.4,0,0,0,2.391,10.99L10,3.381l7.609,7.609a1.4,1.4,0,0,0,1.98-1.981L10.99.41A1.4,1.4,0,0,0,10,0Z" transform="translate(11.4) rotate(90)" fill="#fff" />
                                </svg>
                            </th>
                        </tr>
                        <tr className={styles.tableTr}>
                            <th className={styles.firstTh}>Course Name</th>
                            <th className={styles.secondTh}>Enrolled</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr key={1}>
                            <td className={styles.name}>HTML & CSS</td>
                            <td className={styles.enrolled} >23</td>
                        </tr>
                        <tr key={2}>
                            <td className={styles.name}>Python Masterclass</td>
                            <td className={styles.enrolled}>45</td>
                        </tr>
                        <tr key={3}>
                            <td className={styles.name}>Marketing Basics</td>
                            <td className={styles.enrolled}>67</td>
                        </tr>
                        <tr id={styles.flexViewMore}>
                            <td>
                                <Link to="/profile" className={styles.link}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className={styles.containerC}>
                <table className={styles.tableContainer}>
                    <thead>
                        <tr className={styles.theadTr}>
                            <th className={styles.theadTh}>
                                <svg width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1035" data-name="Path 1035" d="M10,108.541a1.4,1.4,0,0,1-.99-.41l-8.6-8.6a1.4,1.4,0,0,1,1.981-1.981L10,105.16l7.609-7.609a1.4,1.4,0,0,1,1.98,1.981l-8.6,8.6A1.4,1.4,0,0,1,10,108.541Z" transform="translate(108.541 -0.001) rotate(90)" fill="#fff" />
                                </svg>
                            </th>
                            <th> September</th>
                            <th className={styles.theadTh}>
                                <svg width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1034" data-name="Path 1034" d="M10,0a1.4,1.4,0,0,0-.99.41L.41,9.01A1.4,1.4,0,0,0,2.391,10.99L10,3.381l7.609,7.609a1.4,1.4,0,0,0,1.98-1.981L10.99.41A1.4,1.4,0,0,0,10,0Z" transform="translate(11.4) rotate(90)" fill="#fff" />
                                </svg>
                            </th>
                        </tr>
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
                        <tr id={styles.flexViewMore}>
                            <td>
                                <Link to="/profile" className={styles.link}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </>
    );
}
