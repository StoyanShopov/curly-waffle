import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import css from './EditProfile.module.css';
import { EditAdmin, uploadImage, GetAdminData } from './../../services/super-admin-service';
import { _adapters } from 'chart.js';

export default function EditProfile(props) {
    let [admin, setAdmin] = useState({});

    useEffect(async () => {
        await GetAdminData().then(r => {
            setAdmin(r)
        })
    }, [])

    function onInputchange(element) {
        //console.log(element)
        setAdmin({ [element.name]: element.value })
    }

    const OnEditAdmin = async (e) => {
        e.preventDefault();
        //console.log(e.target);

        const fd = new FormData(e.target);

        const data = [...fd.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});
        //console.log(data);

        if (data.photoUrl == null || data.photoUrl.size == 0) { data.photoUrl = admin.photoUrl }

        else {
            let result = 'https://upskillstoragetest.blob.core.windows.net/upskillcontainertest/fb42e363-259b-4566-b7b2-dddf94b073ee' //await uploadImage(data.photoUrl);//does not return imgUrl
            console.log(result);
            data.photoUrl = result;
        }

        EditAdmin(data)
            .then((data) => {
                console.log(data['status'])
                if (data['status']) { props.closeModal() }
            }, (err) => {
                console.error(err)
            })
    }


    return (
        <div className={css.editContainer}>
            <div className={css.headerContainer}>
                <span className={css.text}>Personal Information</span>
                <Link to="" onClick={() => props.closeModal()} className={css.close}>X</Link>
            </div>
            <form onSubmit={e => OnEditAdmin(e)}>
                <div className={css.bodyContainer}>

                    <div className={css.bodyContainer2}>
                        <div className={css.profileImage}>
                            {
                                admin.photoUrl ? <img src={admin.photoUrl} width="198"/>
                                    : <svg xmlns="http://www.w3.org/2000/svg" width="198" height="208" viewBox="0 0 157 157">
                                        <path id="iconmonstr-user-5"
                                            d="M124.292,45.8A45.792,45.792,0,1,1,78.5,0,45.8,45.8,0,0,1,124.292,45.8ZM113.838,92.767a58.42,58.42,0,0,1-70.709-.013C16.492,104.483,0,141.006,0,157H157C157,141.15,139.992,104.627,113.838,92.767Z"
                                            fill="#fff" />
                                    </svg>
                            }
                        </div>
                        <div className={css.fileUpload}>
                            <input name="photoUrl" type="file" className={css.upload} />
                            <span>Edit Photo</span>
                        </div>
                    </div>
                    <div className={css.bodyContainer3}>
                        <input name="fullname" className={css.nameCntr} type="text" value={admin['fullname']} onChange={(e) => onInputchange(e.target)} placeholder="Aya Krasteva"></input>
                        <input name="email" className={css.nameCntr} type="text" value={admin['email']} onChange={(e) => onInputchange(e.target)} placeholder="Hello@Motion-Software.com"></input>
                        <textarea name="profileSummary" className={css.resizableContent} type="text" onChange={(e) => onInputchange(e.target)} placeholder="Profile Summary" value={admin['profileSummary']}></textarea>
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