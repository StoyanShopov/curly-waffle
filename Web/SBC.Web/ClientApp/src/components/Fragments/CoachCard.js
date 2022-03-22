import Booking from './Modals/Booking';
import Feedback from './Modals/Feedaback';

import styles from './ManagerCoachCard.module.css';

export default function ManagerCoachCard(props) {

    const onBook = (coachId) => {
        console.log("Book");
        props.openModal(<Booking handleClose={props.handleClose} coachId={coachId} />);
    }

    const onLeftFeedBack = (coachId) => {
        console.log("Feedback");
        props.openModal(<Feedback handleClose={props.handleClose} coachId={coachId} />);
    }



    return (
        <>
            <div className={styles.card}>
                <div className={styles.upper}>
                    <img className={styles.cardpic} src={props.coach.imageUrl} alt="" />
                </div>
                <div>
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
                            ? <button className={styles.removeButton} onClick={() => onLeftFeedBack(props.coach.id)}>Feedback</button>
                            : <button className={styles.removeButton} onClick={() => onBook(props.coach.id)}>Book</button>
                        }
                    </div>
                </div>
            </div>

        </>
    )
}
