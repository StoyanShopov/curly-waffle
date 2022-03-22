import { EmployeeService } from '../../../services/employee-service';

export default function Booking(props) {

    function onBooking() {
        // EmployeeService.bookCoach(props.coach.id)
        //     .then(res => {
        //         console.log('Successful delete');//
        //         setShowModal(false);
        //     });
    }

    return (
        <p>Booking modal</p>
    );
}