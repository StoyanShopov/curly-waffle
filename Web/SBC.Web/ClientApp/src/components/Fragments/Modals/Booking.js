import { PopupButton, InlineWidget } from "react-calendly";
import { TokenManagement } from "../../../helpers";
import { EmployeeService } from "../../../services/employee-service";
import style from './Booking.module.css';

import ResponsivePlayer from "../../Admin/Player/VideoPlayer";

export default function Booking(props) {

    const user = TokenManagement.getUserData()
    const onBook = async () => {
        console.log("Goes Book")
        //await EmployeeService.bookCoach(props.coachId)
        //    .then(res => console.log(res))
        //    .catch(err => console.log(err))
        props.onChangeButton();
        props.openModal(<InlineWidget
            url={props.url}
            rootElement={document.getElementById("root")}
            text="Book"
            prefill={{
                email: user.email,
                name: user.fullname,
            }}
           /* style={{width: "320px", height: "620px"}}*/
        />)

    }
    return (
        <div className={style.editContainer}>


            <div className={style.mainContainer}>

                <div className={style.upContainer + ' ' + style.colorUpContainer}>
                    <button onClick={() => props.handleClose()}>X</button>
                    <p>MANAGEMENT</p>
                    <div>
                        
                        <section className={style.lectorSection}>
                            <div>
                                <div className={style.lectorPic}>
                                    <img className={style.cardpic} src="https://image.shutterstock.com/image-photo/picture-beautiful-view-birds-600w-1836263689.jpg" alt="" />
                                </div>
                            </div>
                            <div>
                                <p className={style.pCreatedBy}>Coach</p>
                                <p className={style.lectorName}>Ben Levis</p>
                                <p className={style.pCompanyName}>Google</p>
                            </div>
                        </section>
                    </div>

                </div>
                <div className={style.downContainer}>
                    <p>Session Description</p>
                    <div>
                        In this session, you will learn the fundamental language skills of reading, writing, speaking, listening, thinking, viewing and presenting.
                    </div>
                    <p>What you will learn</p>
                    <ul className={style.ulStyle}>
                        <li>Learn more information about management</li>
                        <li>Improve your strategic skills</li>
                        <li>Solve problems</li>
                    </ul>
                </div>
            </div>
            <div className={style.rightContainer}>
                <div className={style.videoPlayer}>
                    <ResponsivePlayer videoUrl="https://www.youtube.com/watch?v=vRiWG1iNikc&list=RDvRiWG1iNikc" />

                </div>
                <p>This session includes</p>
                <p>20 minutes discussion</p>
                <p>23 downloadable resources</p>
                <p>Full lifetime access</p>
                <p>Access on mobile</p>
                <div className={style.sessionIncludes}>

                    <button className={style.bookButton} onClick={() => onBook()}>Book</button>
                                        
                        <PopupButton

                            url={props.url}                           
                            rootElement={document.getElementById("root")}
                            text="Book"
                            prefill={{
                                email: user.email,
                                name: user.fullname,
                            }}
                        />                   

                </div>                   
                
            </div>


        </div>

    );
}