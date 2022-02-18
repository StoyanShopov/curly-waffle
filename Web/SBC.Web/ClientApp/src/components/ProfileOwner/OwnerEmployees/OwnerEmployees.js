import React from "react";
import css from "./OwnerEmployees.module.css";
import Sidebar from "../../Sidebar/Sidebar"
import { Link } from "react-router-dom";

export default function OwnerEmployees(prop) {
    // add prop before setShowModal and handleViewMore 
    // project was fault  setShowModal and handleViewMore not defined
    return (
        <>
            <Sidebar />
            <div className={css.container}>
                <table className={css.table}>
                    <thead>
                        <tr>
                            <th className={css.firstTh}>Employees (64)</th>
                            <th className={css.secondTh}>Email</th>
                            <th >
                                <div className={css.plusSignContainer} >
                                    <Link to="" onClick={() => prop.setShowModal(true)}>
                                        <img src="assets/images/Plus.svg" alt="add-icon"></img>
                                    </Link>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr key={1}>
                            <td className={css.name}> Aya Krusteva</td>
                            <td className={css.email} >aya.krusteva@motion-software.com</td>
                        </tr>
                        <tr key={2}>
                            <td className={css.name}>Anna Vasileva</td>
                            <td className={css.email}>anna.vasileva@motion-software.com</td>
                        </tr>
                        <tr key={3}>
                            <td className={css.name}>Victor Georgiev</td>
                            <td className={css.email}>victor.georgiev@motion-software.com</td>
                        </tr>
                        <tr id={css.flex}>
                            <td>
                                <Link to="" className={css.link} onClick={() => { prop.handleViewMore() }}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </>);
}