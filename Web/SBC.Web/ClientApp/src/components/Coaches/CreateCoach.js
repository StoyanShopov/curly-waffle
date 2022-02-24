import { useEffect, useState } from "react";
import { createCoach, uploadImage, getLanguages, getCategories } from "../../services/adminCoachesService";
import Select from 'react-select'

import styles from "./CreateCoach.module.css";

const CreateCoach = () => {
  const [languages, setLanguages] = useState([]);
  const [languagesOptions, setLanugagesOptions] = useState()
  const [categories, setCategories] = useState([])
  const [categoriesOptions, setCategoriesOptions] = useState()

  useEffect(() => { 
    getLanguages().then(res =>{
      setLanugagesOptions(res.data.map(x=> ({
        value: x.id,
        label: x.name
      })))
    })
    getCategories().then(res =>{
      setCategoriesOptions(res.data.map(x=> ({
        value: x.id,
        label: x.name
      })))
    })
  }, [])

  const onChangeLanguages = (languagesOptions) => {
    setLanguages(languagesOptions);
  };
 
  const onChangeCategories = (categoriesOptions) => {
    setCategories(categoriesOptions);
  };

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

  const onSubmitAddCoach = async (e) => {
    e.preventDefault();

    const fd = new FormData(e.target);
    const data = [...fd.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    );

    const imageUrl = await uploadImage(data.imageUrl);
    data.imageUrl = imageUrl;
    data.languages = languages.map(x=> (x.value))
    data.categories = categories.map(x=> (x.value))
    console.log(data);

    createCoach(data).then((response) => {
      console.log(response);
    });
  };

  return (
    <div className={styles.bodyContainer}>
      <div className={styles.addContainer}>
        <form onSubmit={onSubmitAddCoach}>
          <div className={styles.headerContainer}>
            <div className={styles.titleContainer}>Add Coach</div>
            <div className={styles.fileUpload}>
              <input
                type="file"
                name="imageUrl"
                className={styles.upload}
                required
              />
              <span>Upload image</span>
            </div>
            <button className={styles.closeBtn}>
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
                name="company"
                placeholder="Company(optional)"
                type="text"
              />
            </div>

            <div>
              <input
                className={styles.inputField}
                name="calendlyUrl"
                placeholder="Calendly URL"
                type="text"
                required
              />
              <span className={styles.starCalendlyUrl}>*</span>
            </div>

            <div className={styles.languageOptions}>
              <Select
                options={languagesOptions}
                isMulti
                name="languages"
                defaultInputValue={[languagesOptions]}
                onChange={(onChangeLanguages)}
                styles={selectStyles}
                placeholder="Select Languages"
              >
              </Select>
            </div>

            <div className={styles.languageOptions}>
              <Select
                options={categoriesOptions}
                isMulti
                name="categories"
                defaultInputValue=""
                onChange={(onChangeCategories)}
                styles={selectStyles}
                placeholder="Select Categories"
              >
              </Select>
            </div>

            <div>
              <textarea
                className={styles.inputField}
                name="description"
                placeholder="Description"
                type="textarea"
                required
              />
              <span className={styles.starDescription}>*</span>
            </div>


            <button className={styles.addAnotherCoachBtn}>
              + Add another coach
            </button>

            <div className={styles.footerContainer}>
              <button className={styles.btnCancel} type="button">
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
};

export default CreateCoach;
