import { PopupButton } from "react-calendly";
import { TokenManagement } from "../../../helpers";

export default function Booking(props) {

    const user = TokenManagement.getUserData()
    console.log(user)
    return (
        <div>
            <p>Booking modal</p>
            <button onClick={() => props.handleClose()}>X</button>
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
        </div>
    );
}