import axios from 'axios';
import { Link } from 'react-router-dom';

import styles from './ModalRemoveCourse.module.css'

export default function ModalRemoveCourse(props) {
    const submitHandler = async (e) => {
        e.preventDefault();

        const response = await axios.post(baseUrl + 'Administration/Client', clientData)

        if (response.status === 200) {
            props.handleSkip(1);

            props.handleClient(response.data.client);

            const btnId = e.nativeEvent.submitter.id;

            if (btnId === "continue") {
                e.target.reset();
            }
            else {
                props.handleClose();
            }
        }
    }

    return (
        <div className={styles.body}>
            <section>
                <div className={styles.modal}>
                    <div className={styles.modalHead}>
                        <h2 className={styles.modalTitle}>Are you sure you want to remove this course?</h2>
                        <Link to="" className={styles.closeBtn} onClick={props.handleClose} >X</Link>
                    </div>
                    <div className={styles.modalContented}>
                        <form
                            className={styles.formMain}
                            onSubmit={submitHandler}
                        >
                            <div className={styles.modalFooter}>
                                <button className={styles.modalBtnCancel} onClick={props.handleClose} >Cancel</button>
                                <button className={styles.modalBtnRemove} id="save" type="submit" >Remove</button>
                            </div>
                        </form>
                    </div>
                </div>
            </section>
        </div>
    );
}
