import React from "react";
import styles from "./ProfileOwner.module.css";
import Sidebar from "../Sidebar/Sidebar";

export default function OwnerDashboard(prop) {
    return (
        <>
            <Sidebar />

            <div className={styles.container}>
                <div className={styles.contentContainer}>
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                    Owner Dashboard Test
                </div>
                <div className={styles.testContainer}>
                    Test
                </div>
            </div >
        </>
    );
}
