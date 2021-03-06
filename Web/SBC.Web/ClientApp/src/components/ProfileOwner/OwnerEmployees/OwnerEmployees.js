import axios from 'axios';
import { useEffect, useState, useCallback } from 'react';
import { Link, useNavigate } from "react-router-dom";

import styles from "./OwnerEmployees.module.css";
import Modal from 'react-modal';
import ModalAddEmployee from "../Modals/ModalAddEmployee";

import { ownerService } from '../../../services';

export default function OwnerEmployees() {
    const [employees, setEmployees] = useState([]);
    const [count, setCount] = useState();

    const [isPending, setIsPending] = useState(false);
    const [skip, setSkip] = useState(0);
    const [showModal, setShowModal] = useState(false);
    const [viewMoreAvailable, setViewMoreAvailable] = useState(false);

    const cancelTokenSource = axios.CancelToken.source();
    let navigate = useNavigate();

    Modal.setAppElement('body');

    useEffect(() => {
        handleViewMore(0);
        setSkip(0);

        return () => {
            cancelTokenSource.cancel();
        }
    }, [])

    const RemoveEmployee = async (id) => {
        await ownerService.companyRemoveEmployee(id)
            .then(res => {
                navigate('/profile/owner/dashboard')//
            })
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
        employee.fullName = employee.firstName + ' ' + employee.lastName;
        setCount(count +1);
        setEmployees(prevPortions => {
            return [employee, ...prevPortions];
        });
    }

    const handleViewMore = async () => {
        setIsPending(true);

        const json = await ownerService.companyGetEmployees(skip, cancelTokenSource);

        console.log('js', json)//

        setCount(json.count);

        setIsPending(false);

        setEmployees(prevPortions => {
            return [...prevPortions, ...json.portions];
        });

        handleSkip(3);

        setViewMoreAvailable(json.viewMoreAvailable);
    }

    return (
        <>
            <div className={styles.container}>
                <table className={styles.tableContainer}>
                    <thead>
                        <tr>
                            <th className={styles.firstTh}>Employees ({count})</th>
                            <th className={styles.secondTh}>Email</th>
                            <th >
                                <div className={styles.plusSignContainer} >
                                    <Link to="" onClick={() => setShowModal(true)}>
                                        <img src="/assets/images/Plus.svg" alt="add-icon"></img>
                                    </Link>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees && employees.map(employee => (
                            <tr key={employee.id}>
                                <td className={styles.name}>{employee.fullName}</td>
                                <td className={styles.email}>{employee.email.toLowerCase()}</td>
                                <td ><button onClick={() => { RemoveEmployee(employee.id) }} className={styles.remove}>X</button></td>
                            </tr>
                        ))}
                        <tr key={"unique_loading"} id={styles.pending}>
                            {isPending &&
                                <td>
                                    <h2>Loading...</h2>
                                </td>
                            }
                        </tr>
                        <tr key={"unique_view_more"} id={styles.flex}>
                            <td>
                                {viewMoreAvailable &&
                                    <Link to="" className={styles.link} onClick={() => { handleViewMore() }}>View More</Link>
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
