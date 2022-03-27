import { useState } from 'react';
import { EmployeeService } from '../../../services/employee-service';

import style from './Feedback.module.css';

export default function Feedback(props) {


    function onSendFeedback(e) {
        e.preventDefault();

        const fd = new FormData(e.target);
        fd.append("coachId", props.coachId)
        const data = [...fd.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});

        EmployeeService.leftFeedback(data)
            .then(res => {
                if (res['status'] == 200) {
                    props.onChangeButton();
                    props.handleClose();
                }
            });
    }
    return (
        <>
            <div className={style.header}>
                <h2 className={style.text}>Leave Feedback</h2>
            </div>
            <form className={style.inputForm} onSubmit={onSendFeedback} >
                <div className={style.inputField}>
                    <label htmlFor="Message"></label>
                    <textarea
                        type="text"
                        name="message"
                        autoComplete="off"

                        placeholder="Write it down here..."
                        required="required"
                    />
                </div>

                <div className={style.btnDiv}>
                    <button className={style.modalBtnSend} type="submit">Send</button>
                </div>
            </form>
        </>
    );
}