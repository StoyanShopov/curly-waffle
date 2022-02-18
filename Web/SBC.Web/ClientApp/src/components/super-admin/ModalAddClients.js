// import axios from 'axios';
import { Link } from 'react-router-dom';

import styles from './ModalAddClients.module.css'
// import { baseUrl } from '../../constants';
import { AddClient } from '../../services/client-service';

export default function ModalAddClients(props) {
  const submitHandler = async (e) => {
    e.preventDefault();

    const enteredFullName = e.target?.fullName?.value;
    const enteredEmail = e.target?.email?.value;

    const clientData = {
      fullName: enteredFullName,
      email: enteredEmail,
    }

    //const response =
     AddClient(clientData).then((data) => {
      if (data.status === 200) {
        props.handleSkip(1);

        props.handleClient(data.client);

        const btnId = e.nativeEvent.submitter.id;

        if (btnId === "continue") {
          e.target.reset();
        }
        else {
          props.handleClose();
        }
      }

    }, (err) => console.log(err))
  }


    // if (response.status === 200) {
    //   props.handleSkip(1);

    //   props.handleClient(response.data.client);

    //   const btnId = e.nativeEvent.submitter.id;

    //   if (btnId === "continue") {
    //     e.target.reset();
    //   }
    //   else {
    //     props.handleClose();
    //   }
    // }else{


  return (
    <div className={styles.body}>
      <section>
        <div className={styles.modal}>
          <div className={styles.modalHead}>
            <h2 className={styles.modalTitle}>Add Clients</h2>
            <Link to="" className={styles.closeBtn} onClick={props.handleClose} >X</Link>
          </div>
          <div className={styles.modalContented}>
            <form
              className={styles.formMain}
              onSubmit={submitHandler}
            >
              <div className={styles.formGroup, styles.field}>
                <input
                  type="text"
                  className={styles.formField}
                  placeholder="Full Name*"
                  name="fullName" />
              </div>
              <div className={styles.formGroup, styles.field}>
                <input
                  type="email"
                  className={styles.formField}
                  placeholder="Email Address*"
                  name="email" />
              </div>
              <button className={styles.addAnotherCoachBtn} id="continue" type="submit">
                + Create another client
              </button>
              <div className={styles.modalFooter}>
                <button className={styles.modalBtnCancel} onClick={props.handleClose} >Cancel</button>
                <button className={styles.modalBtnSave} id="save" type="submit" >Save</button>
              </div>
            </form>
          </div>
        </div>
      </section>
    </div>
  );
}
