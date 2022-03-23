import Booking from './Modals/Booking';
import Feedback from './Modals/Feedaback';

import styles from './ManagerCoachCard.module.css';
import axios from 'axios';
import { calendly_token } from '../../constants';

export default function ManagerCoachCard(props) {

    const onBook = async (coachId) => {
        console.log("Book");
        await axios({
            method: "GET",
            url: "https://api.calndly.com/event_types",
            headers: {
                "Access-Control-Allow-Origin": "*",
                "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
                Authorization: "Bearer " + calendly_token,
                'Content-Type': 'application/json'
            }
        }).then(data => console.log(data))
            .catch(err => console.log(err));
        //    props.openModal(<Booking handleClose={props.handleClose} coachId={coachId} />);
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
                        <span>Session: {props.coach.calendlyUrl.substr(props.coach.calendlyUrl.length - 5)} </span>
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
