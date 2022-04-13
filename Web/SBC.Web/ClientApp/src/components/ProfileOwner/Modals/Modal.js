import ReactDOM from 'react-dom'
import styles from './Modal.module.css'

export default function Modal({ children, handleClose }) {
    return ReactDOM.createPortal((
        <div className={styles.modalBackdrop}>
            <div className={styles.modal}>
                {children}
                <button onClick={handleClose}>Close</button>
            </div>
        </div>
    ), document.body)
}
