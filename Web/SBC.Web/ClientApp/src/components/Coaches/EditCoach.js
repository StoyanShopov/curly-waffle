import { useEffect, useState } from 'react';
import Select from 'react-select'
import { uploadImage, updateCoach, getCompanyEmailById } from "../../services/adminCoachesService";

import styles from './EditCoach.module.css';

const EditCoach = (props) => {
  const [languages, setLanguages] = useState([]);
  const [languagesOptions] = useState(props.languages)
  const [categories, setCategories] = useState([])
  const [categoriesOptions] = useState(props.categories)
  const [coach, setCoach] = useState(props.coach)
  const [companyEmail, setCompanyEmail] = useState();

  useEffect(() => {
    if(coach.companyId!==null){
      getCompanyEmailById(coach.companyId).then(res =>{
        setCompanyEmail(res)
      })
    }
    setCoach(props.coach)

  },[props.coach])

  const coachLanguagesAsArrayOfIds = coach.languages.map(x => x.languageId);
  const coachLanguages = languagesOptions.filter(x => coachLanguagesAsArrayOfIds.includes(x.value))

  const coachCategoriesAsArrayOfIds = coach.categories.map(x => x.categoryId)
  const coachCategories = categoriesOptions.filter(x => coachCategoriesAsArrayOfIds.includes(x.value))

  const onChangeLanguages = (languagesOptions) => {
    setLanguages(languagesOptions);
  };

  const onChangeCategories = (categoriesOptions) => {
    setCategories(categoriesOptions);
  };

  function createLanguagesSelect() {
    if (coachLanguages.length > 0) {
      return (
        <Select
          defaultValue={coachLanguages}
          options={languagesOptions}
          isMulti
          name="languages"
          styles={selectStyles}
          placeholder="Select Languages"
          onChange={onChangeLanguages}
          required
        >
        </Select>
      )
    }
  }

  function createCategoriesSelect() {
    if (coachCategories.length > 0) {
      return (
        <Select
          defaultValue={coachCategories}
          options={categoriesOptions}
          isMulti
          name="categories"
          styles={selectStyles}
          placeholder="Select Categories"
          onChange={onChangeCategories}
          required
        >
        </Select>
      )
    }
  }

  const onSubmitEditCoach = async (e) => {
    e.preventDefault()

    const fd = new FormData(e.target);
    fd.append('id', props.id);

    const data = [...fd.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    );

    if (data.imageUrl === null || data.imageUrl.size === 0) {
      data.imageUrl = coach.imageUrl
    }
    else {
      let result = await uploadImage(data.imageUrl);
      data.imageUrl = result
    }

    languages.length === 0 ?
      data.languages = coachLanguages.map(x => ({
        languageId: x.value,
        coachId: coach.id
      })) :
      data.languages = languages.map(x => ({
        languageId: x.value,
        coachId: coach.id
      }))

    categories.length === 0 ?
      data.categories = coachCategories.map(x => ({
        categoryId: x.value,
        coachId: coach.id
      })) :
      data.categories = categories.map(x => ({
        categoryId: x.value,
        coachId: coach.id
      }))

    updateCoach(data)
      .then(() => { 
      const languagesAsObj = data.languages.map(x=> ({languageId : x.languageId}))
      const categoriesAsObj = data.categories.map(x=> ({categoryId : x.categoryId}))
      data.languages = languagesAsObj
      data.categories = categoriesAsObj

      data['companyId'] = coach.companyId

      props.setCoach(data)
      props.closeModal();
      })
  }


  return (
    <div className={styles.bodyContainer}>
      <div className={styles.addContainer}>
        <form onSubmit={onSubmitEditCoach}>
          <div className={styles.headerContainer}>
            <div className={styles.titleContainer}>Edit Coach</div>
            <div className={styles.fileUpload}>
              <input
                type="file"
                name="imageUrl"
                className={styles.upload}
              />
              <span>Upload image</span>
            </div>
            <button className={styles.closeBtn} onClick={() => props.closeModal()}>
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="21.92"
                height="21.92"
                viewBox="0 0 21.92 21.92"
              >
                <g
                  id="Group_46"
                  data-name="Group 46"
                  transform="translate(-1484.379 -241.379)"
                >
                  <line
                    id="Line_59"
                    data-name="Line 59"
                    y2="25"
                    transform="translate(1504.178 243.5) rotate(45)"
                    fill="none"
                    stroke="#fff"
                    strokeLinecap="round"
                    strokeWidth="3"
                  />
                  <line
                    id="Line_60"
                    data-name="Line 60"
                    y2="25"
                    transform="translate(1504.178 261.178) rotate(135)"
                    fill="none"
                    stroke="#fff"
                    strokeLinecap="round"
                    strokeWidth="3"
                  />
                </g>
              </svg>
            </button>
          </div>
          <div className={styles.inputContainer}>
            <div>
              <input
                className={styles.inputField}
                defaultValue={coach.firstName}
                name="firstName"
                placeholder="First Name"
                type="text"
                required
              ></input>
              <span className={styles.starFirstName}>*</span>
            </div>

            <div>
              <input
                className={styles.inputField}
                defaultValue={coach.lastName}
                name="lastName"
                placeholder="Last Name"
                type="text"
                required
              />
              <span className={styles.starLastName}>*</span>
            </div>

            <div>
              <input
                className={styles.inputField}
                defaultValue={coach.videoUrl}
                name="videoUrl"
                placeholder="Video URL"
                type="text"
                required
              />
              <span className={styles.starVideoUrl}>*</span>
            </div>

            <div>
              <input
                className={styles.inputField}
                defaultValue={coach.pricePerSession}
                name="pricePerSession"
                placeholder="Price"
                type="text"
                required
              />
              <span className={styles.starPrice}>*</span>
            </div>

            <div>
              <input
                className={styles.inputField}
                defaultValue={coach.calendlyUrl}
                name="calendlyUrl"
                placeholder="Calendly URL"
                type="text"
                required
              />
              <span className={styles.starCalendlyUrl}>*</span>
            </div>

            <div>
              <input
                className={styles.inputField}
                defaultValue={companyEmail}
                name="companyEmail"
                placeholder="Company(optional)"
                type="text"
              />
            </div>

            <div className={styles.languageOptions}>
              {createLanguagesSelect()}
            </div>

            <div className={styles.languageOptions}>
              {createCategoriesSelect()}
            </div>

            <div>
              <textarea
                className={styles.inputField}
                defaultValue={coach.description}
                name="description"
                placeholder="Description"
                type="textarea"
                required
              />
              <span className={styles.starDescription}>*</span>
            </div>

            <div className={styles.footerContainer}>
              <button className={styles.btnCancel} onClick={() => props.closeModal()} type="button">
                Cancel
              </button>
              <button className={styles.btnSave} type="submit">
                Save
              </button>
            </div>
          </div>
        </form>
      </div>
    </div>
  );
}
const selectStyles = {
  multiValue: styles => {
    return {
      ...styles,
      backgroundColor: "#296CFB",
      borderRadius: 10,
      color: '#ffffff'
    };
  },
  multiValueLabel: (styles) => ({
    ...styles,
    color: '#ffffff',
  }),
  multiValueRemove: (styles) => ({
    ...styles,
    color: "white",
    ':hover': {
      color: 'red',
    },
  }),
  placeholder: (styles) => {
    return {
      ...styles,
      color: "#296CFB",
      fontWeight: 420,
      position: 'absolute',
      paddingLeft: 20
    }
  }
};

export default EditCoach;