import { useState, useEffect } from 'react';

import css from './EditProfile.module.css';

import { uploadImage } from '../../services/blob-service';
import { userService } from '../../services';
import { TokenManagement } from '../../helpers';

export default function EditProfile(props) {
    const [user, setUser] = useState({});
    const [imageURL, setImageURL] = useState("");

    useEffect(() => {
        const _user = TokenManagement.getUserData()
        setUser(_user)
        setImageURL(_user.photoUrl)
    }, []);

    const OnEditUser = async (e) => {
        e.preventDefault();

        const fd = new FormData(e.target);
        const data = [...fd.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});
        console.log(data)
        console.log(fd)
        if (data.photoUrl == null || data.photoUrl.size == 0) {
            data.photoUrl = user.photoUrl
        }
        else {
            let result = await uploadImage(data.photoUrl);
            data.photoUrl = result.photoUrl;
        }

        userService.EditUser(data)
            .then((_data) => {
                if (_data['status']) {
                    props.closeModal();
                    TokenManagement.setUserData(JSON.stringify(_data['data']));
                    props.getUserData();
                    props.editUser();
                }
            }, (err) => {
                console.error(err)
            })
    }

    function onChange(e) {
        const img = e.target.files[0]
        setImageURL(URL.createObjectURL(img))
    }

    return (
        <div className={css.editContainer}>
            <div className={css.headerContainer}>
                <span className={css.text}>Personal Information</span>
                <button onClick={() => props.closeModal()} className={css.close}>X</button>
            </div>
            <form onSubmit={e => OnEditUser(e)}>
                <div className={css.bodyContainer}>

                    <div className={css.bodyContainer2}>
                        <div className={css.profileImage}>
                            {
                                imageURL ? <img src={imageURL} className={css.imagePhoto} />
                                    : <svg xmlns="http://www.w3.org/2000/svg" width="130px" height="150px" viewBox="0 0 157 157">
                                        <path id="iconmonstr-user-5"
                                            d="M124.292,45.8A45.792,45.792,0,1,1,78.5,0,45.8,45.8,0,0,1,124.292,45.8ZM113.838,92.767a58.42,58.42,0,0,1-70.709-.013C16.492,104.483,0,141.006,0,157H157C157,141.15,139.992,104.627,113.838,92.767Z"
                                            fill="#fff" />
                                    </svg>
                            }
                        </div>
                        <button type='button' className={css.fileUpload}>
                            Edit Photo
                            <input name="photoUrl" type="file" className={css.upload} onChange={(e) => onChange(e)} />
                        </button>

                    </div>

                    <div className={css.bodyContainer3}>
                        <input
                            name="fullname"
                            className={css.nameCntr}
                            type="text"
                            defaultValue={user.fullname}
                            placeholder="Aya Krasteva" />
                        <input
                            editable='false'
                            name="email"
                            className={css.nameCntr}
                            type="text"
                            defaultValue={user.email}                           
                            placeholder="Hello@Motion-Software.com" />
                        <textarea name="profileSummary" className={css.resizableContent} type="text" placeholder="Profile Summary" defaultValue={user.profileSummary}></textarea>
                    </div>
                </div>
                <div className={css.footer}>
                    <button onClick={() => props.closeModal()} className={css.buttonPrs}>Cancel</button>
                    <button className={css.button} type="Submit">Save</button>
                </div>
            </form>
        </div>
    )
}