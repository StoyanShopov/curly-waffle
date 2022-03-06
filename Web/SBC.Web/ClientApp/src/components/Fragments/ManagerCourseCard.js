import React from 'react';

import { OwnerService } from '../../services';
import styles from './ManagerCourseCard.module.css';

export default function ManagerCourseCard(props) {

    const onDelete = () => {
        OwnerService.CompanyRemoveCourseFromActive(props.course.id)
            .then(res => {
                console.log('Successful delete')//
            })
    }

    const onSet = () => {
        OwnerService.CompanySetCourseToActive(props.course.id)
            .then(res => {
                console.log('Successful set')//
            })
    }

    return (
        <div className={styles.card}>
            <div className={styles.cardpicContainer}>
                <img className={styles.cardpic} src="/assets/images/Rectangle 1221.png" alt="" />
                <div className={styles.centered}>{props.course.title}</div>
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>Category?</span>
                    <span>{props.course.coachFullName}</span>
                </div>
                <div className={styles.price}>
                    <span>{props.course.pricePerPerson}&#8364; per person</span>
                    <span className={styles.imgContainer}><img src={props.course.companyLogoUrl} /></span>
                </div>
                <div className={styles.button}>
                    {props.course.isActive
                        ? <button className={styles.removeButton} onClick={onDelete}>Remove</button>
                        : <button className={styles.removeButton} onClick={onSet}>Add</button>
                    }
                </div>
            </div>
        </div>
    )
}