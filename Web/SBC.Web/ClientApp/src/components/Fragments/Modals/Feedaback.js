import { EmployeeService } from '../../../services/employee-service';

export default function Feedback(props) {


    function onSendFeedback() {
        console.log(props.coachId)
        EmployeeService.leftFeedback(props.coachId)
            .then(res => {
                //         if (res.status) {
                console.log(res);//
                //             navigate('/profile/owner/coaches');//
                //         }
                //         else {
                //             /*console.log(error)//*/
                //         }
            });
    }
    return (
        <>
            <h2>Feedaback modal</h2>
            <button onClick={() => onSendFeedback()}>Left Feedback</button>
        </>
    );
}