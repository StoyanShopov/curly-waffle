import { EmployeeService } from '../../../services/employee-service';

export default function Booking(props) {

    function onBooking() {
        console.log(props.coachId)
        EmployeeService.bookCoach(props.coachId)
            .then(res => {
                console.log(res);//
                props.handleClose();
            });
    }

    return (
        <div>
            <p>Booking modal</p>
            <button onClick={() => onBooking()}>Book</button>
        </div>
    );
}