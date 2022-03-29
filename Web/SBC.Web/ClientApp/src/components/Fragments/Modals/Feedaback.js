import { useState } from 'react';
import { employeeService } from '../../../services/employee-service';

export default function Feedback(props) {


    function onSendFeedback(e) {
        e.preventDefault();

        const fd = new FormData(e.target);
        fd.append("coachId", props.coachId)
        const data = [...fd.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});

        console.log(data)


        employeeService.leftFeedback(data)
            .then(res => {
                console.log(res);//
                if (res['status'] == 200) {
                    props.onChangeButton();
                    props.handleClose();
                }
            });
    }
    return (
        <>
            <h2>Feedaback modal</h2>

            <form onSubmit={onSendFeedback} >
                <div>
                    <label htmlFor="Message"></label>
                    <input
                        type="text"
                        name="message"
                        autoComplete="off"

                        placeholder="Left Feedback*"
                        required="required"
                    />
                </div>

                <div >
                    <button type="submit">Left Feedback</button>
                </div>
            </form>
        </>
    );
}