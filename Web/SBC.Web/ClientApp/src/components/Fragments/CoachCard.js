import Booking from './Modals/Booking';
import Feedback from './Modals/Feedaback';

import styles from './ManagerCoachCard.module.css';
import { useState } from 'react';

export default function CoachCard(props) {
    const [button, setButton] = useState(props.coach.feedbacked);
    const onBook = async (coachId) => {
       // console.log(props.coach)
        props.openModal(<Booking
            key={coachId}
            isMode={"coach"}
            url={props.coach.scheduling_url}
            onChangeButton={onChangeButton}
            openModal={props.openModal}
            handleClose={props.handleClose}
            entity={{
                coachId: coachId,
                eType: "Coach",
                eName: props.coach.fullName,
                eCompanyName: props.coach.companyName,
                eCoachImgUrl: props.coach.imageUrl,
                eCategoryName: props.coach.calendlyName,
                eDescription: props.coach.description,
                eVideoUrl: props.coach.videoUrl,
                eDuration: `${props.coach.duration} minutes discussion`,
                eResourse: `${23} downloadable resources`,
            }}

        />);
    }

    const onLeftFeedBack = (coachId) => {
        props.openModal(<Feedback handleClose={props.handleClose} onChangeButton={onChangeButton} coachId={coachId} />);
    }

    const onChangeButton = () => {
        setButton(!button);
    }

    return (
        <>
            <div className={styles.card}>
                <div className={styles.upper}>
                    <img className={styles.cardpic} src={props.coach.imageUrl} alt="" />
                </div>
                <div>
                    <div className={styles.name}>
                        <span>{props.coach.calendlyName}</span>
                        <span>{props.coach.fullName}</span>
                    </div>
                    <div className={styles.price}>
                        <span>Session: {props.coach.duration} min </span>
                        <span className={styles.imgContainer}><img src={props.coach.companyLogoUrl} /></span>
                    </div>
                    <div className={styles.button}>
                        {button
                            ? <button className={styles.removeButton} onClick={() => onLeftFeedBack(props.coach.id)}>Feedback</button>
                            : props.coach.active
                                ? <button className={styles.removeButton} onClick={() => onBook(props.coach.id)}>Book</button>
                                : null
                        }
                    </div>
                </div>
            </div>

        </>
    )
}
