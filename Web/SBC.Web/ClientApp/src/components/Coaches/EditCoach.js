import { useState, useEffect } from 'react';
import { getCoach } from '../../services/adminCoachesService';

import styles from './EditCoach.module.css';

const EditCoach = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('')
    const [price, setPrice] = useState(0);
    const [company, setCompany] = useState('');
    const [description, setDescription] = useState('');
    const [calendlyUrl, setCalendlyUrl] = useState('');
    const [file, setFile] = useState('');



    const onChangeFirstName = (e) => {
        setFirstName(e.target.value);
    }

    const onChangeLastName = (e) => {
        setLastName(e.target.value);
    }

    const onChangeCompany = (e) => {
        setCompany(e.target.value);
    }

    const onChangecalendlyUrl = (e) => {
        setCalendlyUrl(e.target.value);
    }

    const onChangeFile = (e) => {
        console.log(e.target.files[0]);
        setFile(e.target.files[0]);
    }

    const onChangeDescription = (e) => {
        setDescription(e.target.value);
    }

    const onChangePrice = (e) => {
        setPrice(e.target.value)
    }

    return (
        <div className={styles.bodyContainer}>
            <div className={styles.addContainer}>
                <form>
                    <div className={styles.headerContainer}>
                        <div className={styles.titleContainer}>Edit Coach</div>
                        <div className={styles.fileUpload}>
                            <input
                                type="file"
                                className={styles.upload}
                                onChange={onChangeFile}
                                required />
                            <span>Upload image</span>
                        </div>
                        <button className={styles.closeBtn}>
                            <svg xmlns="http://www.w3.org/2000/svg" width="21.92" height="21.92" viewBox="0 0 21.92 21.92">
                                <g id="Group_46" data-name="Group 46" transform="translate(-1484.379 -241.379)">
                                    <line id="Line_59" data-name="Line 59" y2="25" transform="translate(1504.178 243.5) rotate(45)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                                    <line id="Line_60" data-name="Line 60" y2="25" transform="translate(1504.178 261.178) rotate(135)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                                </g>
                            </svg>
                        </button>
                    </div>
                    <div className={styles.inputContainer}>
                        <div>
                            <input className={styles.inputField}
                                name="firstName"
                                placeholder='First Name'
                                type="text"
                                value={firstName}
                                onChange={onChangeFirstName}
                                required />
                            <span className={styles.starFirstName}>*</span>
                        </div>

                        <div>
                            <input className={styles.inputField}
                                name="lastName"
                                placeholder='Last Name'
                                type="text"
                                value={lastName}
                                onChange={onChangeLastName}
                                required />
                            <span className={styles.starLastName}>*</span>
                        </div>
                        <div>
                            <input className={styles.inputField}
                                name="price"
                                placeholder='Price'
                                type="text"
                                onChange={onChangePrice}
                                required />
                            <span className={styles.starPrice}>*</span>
                        </div>
                        <div>
                            <input className={styles.inputField}
                                name="company"
                                placeholder='Company(optional)'
                                type="text"
                                value={company}
                                onChange={onChangeCompany} />
                        </div>
                        <div>
                            <input className={styles.inputField}
                                name="calendlyUrl"
                                placeholder='Calendly URL'
                                type="text"
                                value={calendlyUrl}
                                onChange={onChangecalendlyUrl}
                                required />
                            <span className={styles.starCalendlyUrl}>*</span>
                        </div>

                        <div>
                            <textarea className={styles.inputField}
                                name="description"
                                placeholder='Description'
                                type="textarea"
                                value={description}
                                onChange={onChangeDescription}
                                required />
                            <span className={styles.starDescription}>*</span>
                        </div>
                        <button className={styles.addAnotherCoachBtn}>
                            + Add another coach
                        </button>
                        <div className={styles.footerContainer}>
                            <button className={styles.btnCancel} type="button">Cancel</button>
                            <button className={styles.btnSave} type="submit">Save</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    )
}
export default EditCoach;