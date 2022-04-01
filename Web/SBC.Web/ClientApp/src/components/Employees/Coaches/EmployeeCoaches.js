import { useEffect, useState } from "react";
import { employeeService } from "../../../services/employee-service";
import CoachCard from "../../Fragments/CoachCard";

import styles from "./EmployeeCoaches.module.css";

export default function EmployeeCoaches(props) {

    const [coaches, setCoaches] = useState([]);

    useEffect(() => {
        employeeService.getAllCoaches("all").then(res => {
            setCoaches(res)
        })
    }, []);
    console.log(coaches);


    return (
        <div className={styles.container}>
            <div className={styles.cardscontainer}>
                {coaches.length > 0
                    ? coaches.map((x, index) => { return <CoachCard key={index} coach={x} openModal={props.modal.openModal} handleClose={props.modal.handleClose} /> })
                    : <h3>No coaches yet</h3>
                }
            </div>

        </div>
    );
}