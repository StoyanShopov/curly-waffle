import { useEffect, useState } from "react";
import { EmployeeService } from "../../../services/employee-service";
import CoachCard from "../../Fragments/CoachCard.js";

import styles from "./EmployeeCoaches.module.css";

export default function EmployeeCoaches(props) {
    const [coaches, setCoaches] = useState([]);

    useEffect(() => {
        EmployeeService.getAllCoaches()
            .then(res => {
                setCoaches(res.data);
            })
    }, []);

    return (
        <div className={styles.container}>
            <div className={styles.cardscontainer}>
                {coaches.length > 0
                    ? coaches.map(x => <CoachCard key={x.id} coach={x} coaches={coaches} setCoaches={setCoaches} />)
                    : <h3>No coaches yet</h3>
                }
            </div>
        </div>
    );
}