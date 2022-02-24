import ReactDOM from 'react-dom'
import css from './Modal.module.css'

export default function Modal({ children, handleClose }) {
    return ReactDOM.createPortal((
        <div className={css.modalBackdrop}>
            <div className={css.modal}>
                {children}
                <button onClick={handleClose}>Close</button>
            </div>
        </div>
    ), document.body)
}
