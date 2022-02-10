import { useState,useEffect } from 'react';

import styles from './AddCoach.module.css';


const AddCoach = () => {

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('')
    const [price, setPrice] = useState(0);
    const [description, setDescription] = useState('');
    const [callendlyUrl, setCalendlyUrl] = useState('');
    const [file, setFile] = useState('');

    const onChangeLastName = (e) =>{
        setLastName(e.target.value);
    }

    const onChangeFirstName = (e) =>{
        setFirstName(e.target.value);
    }

    const onChangeCallendlyUrl = (e) =>{
        setCalendlyUrl(e.target.value);
    }

    const onChangeFile = (e) =>{
        setFile(e.target.file[0]);
    }

    const onChangeDescription = (e) =>{
        setDescription(e.target.value);
    }

    const onChangePrice = (e) =>{
        setPrice(e.target.value)
    }

    const onSubmitAddCoach=(e) =>{
        e.preventDefault()
    }

    return (
        <body className={styles.body}>
            <section>
                <div className={styles.modal}>
                    <div className={styles.modalHead}>
                        <span className={styles.modalBtnClose}>
                            <i className={styles.fa}></i>
                        </span>
                        <h2 className={styles.modalTitle}>Add Coaches</h2>
                    </div>
                    <div className={styles.modalContented}>
                        <form 
                        className={styles.formMain}
                        // onSubmit={(e) =>{onSubmitAddCoach}}
                        >
                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="text" 
                                className={styles.formField} 
                                placeholder="First Name*" 
                                id="firstName"
                                value={firstName}
                                onChange={onChangeFirstName}
                                    required />
                                <label htmlFor="firstname" className={styles.formLabel}></label>
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="text" 
                                className={styles.formField} 
                                placeholder="Last Name*" 
                                id="lastname"
                                value={lastName}
                                onChange={onChangeLastName}
                                    required />
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="text" 
                                className={styles.formField} 
                                placeholder="Price*" 
                                id="price" 
                                onChange={onChangePrice}
                                    required />
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="text" 
                                className={styles.formField} 
                                placeholder="Description*" 
                                id="description" 
                                value={description}
                                onChange={onChangeDescription}
                                    required />
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="text" 
                                className={styles.formField} 
                                placeholder="Callendly-URL*" 
                                id="calendly"
                                value={callendlyUrl}
                                onChange={onChangeCallendlyUrl}
                                    required />
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input 
                                type="file" 
                                className={styles.formField} 
                                placeholder="file*" 
                                id="file"
                                value={file}
                                onChange={onChangeFile}
                                     required />
                            </div>

                            <button className={styles.addAnotherCoachBtn}>
                                + Create another coach
                            </button>

                            <div className={styles.modalFooter}>
                                <div className={styles.submitBox}>
                                    <button className={styles.modalBtnCancel} type="submit">Cancel</button>
                                    <button className={styles.modalBtnSave} type="submit">Save</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </section>
        </body>
    )
}

export default AddCoach;