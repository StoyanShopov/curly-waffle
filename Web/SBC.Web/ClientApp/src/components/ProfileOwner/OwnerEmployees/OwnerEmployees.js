import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";

import css from "./OwnerEmployees.module.css";
import Modal from 'react-modal';
import ModalAddEmployee from "../Modals/ModalAddEmployee";

import Sidebar from "../../Sidebar/Sidebar";
import { OwnerService } from '../../../services';

export default function OwnerEmployees() {
    const [showModal, setShowModal] = useState(false);

    const [employees, setEmployees] = useState([]);

    useEffect(() => {
        OwnerService.CompanyGetEmployees(0)
            .then(res => {
                setEmployees(res.portions);
                console.log(res);
            });

    }, []);

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    const handleSkip = (skip) => {
        setSkip(prevSkip => {
            return prevSkip + skip;
        });
    }

    const handleClient = (client) => {
        setClients(prevPortions => {
            return [client, ...prevPortions];
        });
    }

    return (
        <>
            <Sidebar />
            <div className={css.container}>
                <table className={css.tableContainer}>
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
                        {employees.length > 0
                            ? employees.map(x => {
                                return (
                                    <tr key={x.id}>
                                        <td className={css.name}> { x.fullName}</td>
                                        <td className={css.email} >{ x.email}</td>
                                    </tr>
                                    )
                            })
                            : <tr>
                                <td>Test</td>
                             </tr>
                        }
                        <tr id={css.flex}>
                            <td>
                                <Link to="" className={css.link} onClick={() => { prop.handleViewMore() }}>View More</Link>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <Modal
                style={{
                    content: {
                        top: '50%',
                        left: '50%',
                        right: 'auto',
                        width: '45%',
                        bottom: 'auto',
                        transform: 'translate(-50%, -50%)',
                        padding: '0px',
                    }
                }}
                isOpen={showModal}
                onRequestClose={handleClose}
                contentLabel="Example Modal"
            >
                <ModalAddEmployee handleClose={handleClose} handleSkip={handleSkip} handleClient={handleClient} />
            </Modal>
        </>);
}
