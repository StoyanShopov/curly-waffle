import React from 'react';

import { OwnerService } from '../../services';

import styles from './ManagerCoachCard.module.css';

export default function ManagerCoachCard(props) {

    const onDelete = () => {
        OwnerService.CompanyRemoveCoachFromActive(props.coach.id)
            .then(res => {
                console.log('Successful delete')//
            })
    }

    const onSet = async () => {
        await OwnerService.CompanySetCoachToActive(props.coach.id)
            .then(res => {
                console.log('Successful set')//
            })
    }


    console.log(props.coach)


    return (
        <div className={styles.card}>
            <div className={styles.upper}>
                <img className={styles.cardpic} src="/assets/images/Mask Group 3.png" alt="" />
            </div>
            <div className={styles.down}>
                <div className={styles.name}>
                    <span>{props.coach.categoryByDefault}</span>
                    <span>{props.coach.fullName}</span>
                </div>
                <div className={styles.price}>
                    <span>{props.coach.pricePerSession}&#8364; per session</span>
                    <span className={styles.imgContainer}><img src={props.coach.companyLogoUrl} /></span>
                </div>
                <div className={styles.button}>
                    {props.coach.isActive
                        ? <button className={styles.removeButton} onClick={onDelete}>Remove</button>
                        : <button className={styles.removeButton} onClick={onSet}>Add</button>
                    }
                </div>
            </div>
        </div>
    )
}