import axios from 'axios';
import { Link } from 'react-router-dom';
import { baseUrl } from '../../../constants';

import styles from './ModalRemoveCourse.module.css'

export default function ModalRemoveCourse(props) {

    return (
        <div className={styles.body}>
            <section>
                <div className={styles.modal}>
                    <div className={styles.modalHead}>
                        <h2 className={styles.modalTitle}>Are you sure you want to remove this {props.item}?</h2>
                        <Link to="" className={styles.closeBtn} onClick={props.handleClose} >X</Link>
                    </div>
                    <div className={styles.modalContented}>
                        <div className={styles.modalFooter}>
                            <button className={styles.modalBtnCancel} onClick={props.handleClose} >Cancel</button>
                            <button className={styles.modalBtnRemove} onClick={props.delete} >Remove</button>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}
