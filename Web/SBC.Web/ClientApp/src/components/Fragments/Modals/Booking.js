import { useEffect } from "react";
import { PopupButton } from "react-calendly";
import { TokenManagement } from "../../../helpers";
import { EmployeeService } from "../../../services/employee-service";

import style from './Booking.module.css';

import ResponsivePlayer from "../../Admin/Player/VideoPlayer";


export default function Booking(props) {
    const CalendlyEventListener = (e) => {
        return e.data.event &&
            e.data.event.indexOf('calendly') === 0 &&
            e.data.event === 'calendly.event_scheduled'
    }

    const user = TokenManagement.getUserData()

    useEffect(() => {
        window.addEventListener(
            'message',
            async (e) => {
                if (CalendlyEventListener(e)) {
                    await EmployeeService.bookCoach(props.entity.coachId)
                    props.onChangeButton();
                    props.handleClose();
                }
            })
    }, []);
    return (
        <div className={style.editContainer}>
            <div className={style.mainContainer}>
                <div className={style.upContainer + ' ' + style.colorUpContainer}>
                    <button className={style.closeButton} onClick={() => props.handleClose()}>X</button>
                    <p className={style.categoryName}>{props.entity.eCategoryName}</p>
                    <div className={style.lector}>
                        <section className={style.lectorSection}>
                            <div>
                                <div className={style.lectorPic}>
                                    <img className={style.cardpic} src={props.entity.eCoachImgUrl} alt="" />
                                </div>
                            </div>
                            <div>
                                <p className={style.pCreatedBy}>{props.entity.eType}</p>
                                <p className={style.lectorName}>{props.entity.eName}</p>
                                <p className={style.pCompanyName}>{props.entity.eCompanyName}</p>
                            </div>
                        </section>
                    </div>
                </div>
                <div className={style.downContainer}>
                    <p>{props.isMode == "coach" ? 'Session' : 'Course'} Description</p>
                    <div>
                        {props.entity.eDescription}
                    </div>
                    <p>What you will learn</p>
                    <ul className={style.ulStyle}>
                        <li>Learn more information about {props.entity.eCategoryName.toLowerCase()}</li>
                        <li>Improve your strategic skills</li>
                        <li>Solve problems</li>
                    </ul>
                </div>
            </div>
            <div className={style.rightContainer}>
                <div>
                    <ResponsivePlayer videoUrl={props.entity.eVideoUrl} />
                </div>
                <div className={style.rightContainerDown}>

                    <p className={style.includes}>This  {props.isMode == "coach" ? "session" : "course"} includes</p>
                    <div className={style.resources}>
                        <p>{props.entity.eDuration}</p>
                        <p>{props.entity.eResource}</p>
                        <p>Full lifetime access</p>

                        {props.isMode == "couch"
                            ? <p>Access on mobile</p>
                            : <p>Sertificate of completion</p>
                        }
                    </div>
                    <div className={style.sessionIncludes}>
                        {props.isMode == "coach"
                            ? <PopupButton
                                className={style.bookButton}
                                url={props.url}
                                rootElement={document.getElementById("root")}
                                text="Book"
                                prefill={{
                                    email: user.email,
                                    name: user.fullname,
                                }}
                            />
                            : <p>Put your booking</p>
                        }
                    </div>
                </div>
            </div>
        </div>
    );
}
