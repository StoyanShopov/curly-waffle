import React from "react";
import styles from "./Invoice.module.css";

export default function Invoice() {
    return (
        <div>
            <div className={styles.containerH}>
                <div className={styles.dashboard}>
                    <section className={styles.dashboardHeader} >
                        <article><span>Invoice Status</span><span className={styles.invoiceStatus}>Pending</span></article>
                        <svg width="1" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <article><span>Due Date</span><span>30.09.2021</span></article>
                        <svg width="1" viewBox="0 0 1 126">
                            <line id="Line_63" data-name="Line 63" y2="125" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                        </svg>
                        <div className={styles.export}>Export</div>
                    </section>
                </div>
            </div >
            <div className={styles.containerT}>
                <table className={styles.tableContainer}>
                    <thead>
                        <tr>
                            <th colSpan="3" className={styles.center}>
                                <svg className={styles.leftArrow} width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1033" data-name="Path 1033" d="M10,108.541a1.4,1.4,0,0,1-.99-.41l-8.6-8.6a1.4,1.4,0,0,1,1.981-1.981L10,105.16l7.609-7.609a1.4,1.4,0,0,1,1.98,1.981l-8.6,8.6A1.4,1.4,0,0,1,10,108.541Z" transform="translate(108.541 -0.001) rotate(90)" fill="#fff" />
                                </svg>
                                September
                                <svg className={styles.rightArrow} width="11.4" height="20" viewBox="0 0 11.4 20">
                                    <path id="Path_1034" data-name="Path 1034" d="M10,0a1.4,1.4,0,0,0-.99.41L.41,9.01A1.4,1.4,0,0,0,2.391,10.99L10,3.381l7.609,7.609a1.4,1.4,0,0,0,1.98-1.981L10.99.41A1.4,1.4,0,0,0,10,0Z" transform="translate(11.4) rotate(90)" fill="#fff" />
                                </svg>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <svg className={styles.line} width="926" height="4" viewBox="0 0 926 4">
                                    <line id="Line_49" data-name="Line 49" x2="925" transform="translate(0.5 0.5)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="2" />
                                </svg>
                            </th>
                        </tr>
                        <tr className={styles.tableTr}>
                            <th className={styles.firstTh}>Course/Coach</th>
                            <th className={styles.secondTh}>Date</th>
                            <th className={styles.thirdTh}>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr key={1}>
                            <td className={styles.name}>Photoshop Advanced</td>
                            <td className={styles.enrolled}>10.09.2021</td>
                            <td className={styles.price}>100 &#8364;</td>
                        </tr>
                        <tr key={2}>
                            <td className={styles.name}>Illustrator Advanced</td>
                            <td className={styles.enrolled}>15.09.2021</td>
                            <td className={styles.price}>100 &#8364;</td>
                        </tr>
                        <tr key={3}>
                            <td className={styles.name}>Life Balance Coach</td>
                            <td className={styles.enrolled}>22.09.2021</td>
                            <td className={styles.price}>100 &#8364;</td>
                        </tr>
                        <tr className={styles.total} key={4}>
                            <td>Total</td>
                            <td></td>
                            <td>300 &#8364;</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
}
