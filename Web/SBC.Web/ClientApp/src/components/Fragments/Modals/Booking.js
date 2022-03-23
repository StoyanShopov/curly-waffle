import { PopupButton } from "react-calendly";
import { TokenManagement } from "../../../helpers";
import { EmployeeService } from "../../../services/employee-service";

export default function Booking(props) {

    const user = TokenManagement.getUserData()
    const onBook = async () => {
        console.log("Goes Book")
        await EmployeeService.bookCoach(props.coachId)
            .then(res => console.log(res))
            .catch(err => console.log(err))

    }
    return (
        <div>
            <p>Booking modal</p>
            <button onClick={() => props.handleClose()}>X</button>
            <button onClick={() => onBook()}>
                <PopupButton

                    url={props.url}
                    /*
                     * react-calendly uses React's Portal feature (https://reactjs.org/docs/portals.html) to render the popup modal. As a result, you'll need to
                     * specify the rootElement property to ensure that the modal is inserted into the correct domNode.
                     */
                    rootElement={document.getElementById("root")}
                    text="Book"
                    prefill={{
                        email: user.email,
                        name: user.fullname,
                    }}
                />
            </button>
        </div>
    );
}