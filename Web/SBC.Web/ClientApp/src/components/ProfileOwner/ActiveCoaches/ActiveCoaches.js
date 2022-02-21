import React from "react";
import { Link } from "react-router-dom";
import styles from "./ActiveCoaches.module.css";
import Sidebar from "../../Sidebar/Sidebar";

export default function ActiveCoaches(prop) {
    return (
        <>
            <Sidebar />
            <div className={styles.container}>
                <div className={styles.buttonContainer}>
                    <Link to="/manage" ><button className={styles.manageButton}>Manage</button></Link>
                </div>
                <div className={styles.cardscontainer}>
                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img
                                className={styles.cardpic}
                                src="assets/images/Mask Group 2.png"
                                alt=""
                            />
                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="/remove" ><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img
                                className={styles.cardpic}
                                src="assets/images/Mask Group 3.png"
                                alt=""
                            />
                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="/remove" ><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img
                                className={styles.cardpic}
                                src="assets/images/Mask Group 7.png"
                                alt=""
                            />

                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="/remove" ><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.card}>
                        <div className={styles.upper}>
                            <img
                                className={styles.cardpic}
                                src="assets/images/Mask Group 8.png"
                                alt=""
                            />

                        </div>
                        <div className={styles.down}>
                            <div className={styles.name}>
                                <span>Management</span>
                                <span>Timmy Ramsey</span>
                            </div>
                            <div className={styles.price}>
                                <span>80&#8364; per person</span>
                                <span><img src="assets/images/Image 2.png" /></span>
                            </div>
                            <div className={styles.button}>
                                <Link to="/remove" ><button className={styles.removeButton}>Remove</button></Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
