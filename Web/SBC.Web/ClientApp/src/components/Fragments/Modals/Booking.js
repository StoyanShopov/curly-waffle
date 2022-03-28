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

    const color = `${(props.isMode == "coach") ? style.colorUpContainerGreen : style.colorUpContainerBlue}`

    const bulletColor = `${(props.isMode == "coach") ? style.ulStyleGreen : style.ulStyleBlue}`

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
                <div className={color}>
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
                    <ul className={bulletColor}>
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

                        {props.isMode == "coach"
                            ? <p>&#128490; &nbsp; &nbsp; {props.entity.eDuration} &#128223; &#128250; </p>
                            : <p>&#9655; &nbsp; &nbsp; {props.entity.eDuration}</p>
                        }

                        <p>&#128203; &nbsp; &nbsp; {props.entity.eResource} &#128196;</p>
                        <p>&#4113;  &nbsp; &nbsp; Full lifetime access &nbsp;  &#9655;</p>

                        {props.isMode == "coach"
                            ? <p className={style.resourceFour}>&#128241; &nbsp; &nbsp; Access on mobile &#127942;</p>
                            : <p className={style.resourceFour}>&#127942; &nbsp; &nbsp; Sertificate of completion</p>
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
