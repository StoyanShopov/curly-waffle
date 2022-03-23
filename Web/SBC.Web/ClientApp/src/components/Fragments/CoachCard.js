import Booking from './Modals/Booking';
import Feedback from './Modals/Feedaback';

import styles from './ManagerCoachCard.module.css';

// const orgId = "3b91d81f-2042-4964-a5ce-e1c43314347b";
export const userId = "dcd2e179-a4f5-4f67-9547-b1ce4000baec";
export const linkUsrById = "https://api.calendly.com/users/dcd2e179-a4f5-4f67-9547-b1ce4000baec";
//type events
export const getTypeEvents = "https://api.calendly.com/event_types?user=https%3A%2F%2Fapi.calendly.com%2Fusers%2F";
export const getTypeEventById = "https://api.calendly.com/event_types/93be18fb-f981-4a4c-80e3-88cbd861a606";

//schedule events
export const scheduled_events = "https://api.calendly.com/scheduled_events?user=" + linkUsrById;
export default function CoachCard(props) {
    //  console.log(props.key)
    const onBook = async (coachId) => {
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
                        <span>Session: {props.coach.calendlyUrl} </span>
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
