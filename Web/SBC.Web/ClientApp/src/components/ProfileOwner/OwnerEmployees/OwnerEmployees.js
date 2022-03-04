import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link } from "react-router-dom";

import css from "./OwnerEmployees.module.css";
import Modal from 'react-modal';
import ModalAddEmployee from "../Modals/ModalAddEmployee";

import { OwnerService } from '../../../services';

export default function OwnerEmployees() {
    const [employees, setEmployees] = useState([]);

    const [isPending, setIsPending] = useState(false);
    const [skip, setSkip] = useState(0);
    const [showModal, setShowModal] = useState(false);
    const [viewMoreAvailable, setViewMoreAvailable] = useState(false);

    const cancelTokenSource = axios.CancelToken.source();

    useEffect(() => {
        handleViewMore(0);
        setSkip(0);

        return () => {
            cancelTokenSource.cancel();
        }
    }, [])

    const RemoveEmployee = async (id) => {
        await OwnerService.CompanyRemoveEmployee(id);
    }

    const handleClose = useCallback(() => {
        setShowModal(false)
    }, []);

    const handleSkip = (skip) => {
        setSkip(prevSkip => {
            return prevSkip + skip;
        });
    }

    const handleEmployee = (employee) => {
        setEmployees(prevPortions => {
            return [employee, ...prevPortions];
        });
    }

    const handleViewMore = async () => {
        setIsPending(true);

        const json = await OwnerService.CompanyGetEmployees(skip, cancelTokenSource);

        console.log(json)//

        setIsPending(false);

        setEmployees(prevPortions => {
            return [...prevPortions, ...json.portions];
        });

        handleSkip(3);

        setViewMoreAvailable(json.viewMoreAvailable);
    }

    return (
        <>
            <div className={css.container}>
                <table className={css.tableContainer}>
                    <thead>
                        <tr>
                            <th className={css.firstTh}>Employees (64)</th>
                            <th className={css.secondTh}>Email</th>
                            <th >
                                <div className={css.plusSignContainer} >
                                    <Link to="" onClick={() => setShowModal(true)}>
                                        <img src="assets/images/Plus.svg" alt="add-icon"></img>
                                    </Link>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees && employees.map(employee => (
                            <tr key={employee.id}>
                                <td className={css.name}>{employee.fullName}</td>
                                <td className={css.email}>{employee.email.toLowerCase()}</td>
                                <td><button onClick={() => { RemoveEmployee(employee.id) }}>X</button></td>
                            </tr>
                        ))}
                        <tr key={"unique_loading"} id='pending'>
                            {isPending &&
                                <td>
                                    <h2>Loading...</h2>
                                </td>
                            }
                        </tr>
                        <tr key={"unique_view_more"} id={css.flex}>
                            <td>
                                {viewMoreAvailable &&
                                    <Link to="" className={css.link} onClick={() => { handleViewMore() }}>View More</Link>
                                }
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
                <ModalAddEmployee handleClose={handleClose} handleSkip={handleSkip} handleEmployee={handleEmployee} />
            </Modal>
        </>);
}
