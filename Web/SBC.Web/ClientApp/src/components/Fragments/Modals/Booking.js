import { PopupButton } from "react-calendly";

export default function Booking(props) {


    return (
        <div>
            <p>Booking modal</p>
            <button onClick={() => props.handleClose()}>X</button>
            <PopupButton
                url="https://calendly.com/sbc-upskill/30min"
                /*
                 * react-calendly uses React's Portal feature (https://reactjs.org/docs/portals.html) to render the popup modal. As a result, you'll need to
                 * specify the rootElement property to ensure that the modal is inserted into the correct domNode.
                 */
                rootElement={document.getElementById("root")}
                text="Book"
            />
        </div>
    );
}