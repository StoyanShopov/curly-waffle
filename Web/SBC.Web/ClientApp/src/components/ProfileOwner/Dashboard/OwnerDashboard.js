import React from "react";
import styles from "./ProfileOwner.module.css";
import Sidebar from "../../Sidebar/Sidebar";

export default function OwnerDashboard(prop) {
    return (
        <>
            <Sidebar />

            <div className={styles.containerTest}>
                <div className={styles.contentContainer}>
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                </div>
            </div >

            <div className={styles.container}>

                <div className={styles.dashboard}>
                    <section className={styles.dashboardHeader} >
                        <article><span>Clients</span><span>12</span></article>
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
                <p> </p>
                <p> </p>
                <p> </p>
                <p> </p>
                <p> </p>
                <div className={styles.testContainer}>
                    Test
                </div>

            </div >



        </>
    );
}
