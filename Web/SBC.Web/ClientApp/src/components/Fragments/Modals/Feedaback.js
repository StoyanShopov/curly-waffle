import { EmployeeService } from '../../../services/employee-service';

export default function Feedback(props) {


    function onSendFeedback() {
        // EmployeeService.leftFeedback(props.coach.id)
        //     .then(res => {
        //         if (res.status) {
        //             console.log('Successful set', res);//
        //             navigate('/profile/owner/coaches');//
        //         }
        //         else {
        //             /*console.log(error)//*/
        //         }
        //     });
    }
    return (
        <h2>Feedaback modal</h2>
    );
}