import React from 'react';

import styles from './ManagerCourseCard.module.css';

export default function ManagerCourseCard(props) {
    return (

        <div className={styles.card}>
            <div className={styles.cardpicContainer}>
                <img className={styles.cardpic} src="/assets/images/Rectangle 1221.png" alt="" />
                <div className={styles.centered}>{props.course.title}</div>
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>Category?</span>
                    <span>{props.course.coachName}</span>
                </div>
                <div className={styles.price}>
                    <span>{props.course.pricePerPerson}&#8364; per person</span>
                    <span className={styles.imgContainer}><img src={props.course.companyLogoUrl} /></span>
                </div>
                <div className={styles.button}>
                    {props.course.isActive
                        ? <button className={styles.removeButton}>Remove</button>
                        : <button className={styles.removeButton}>Add</button>
                    }
                </div>
            </div>
        </div>
    )
}