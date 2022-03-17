import axios from 'axios';
import { useEffect, useState} from 'react';
import { Link } from "react-router-dom";

import { OwnerService } from '../../../services';
import ManagerCourseCard from '../../Fragments/ManagerCourseCard';

import { CategoriesList } from "./CategoriesList";
import { LanguagesList } from "./LanguagesList";

import styles from "./CourseCatalog.module.css";

export default function CourseCatalog(prop) {
    const [courses, setCourses] = useState([]);
   
    const [isPending, setIsPending] = useState(false);
    const [skip, setSkip] = useState(0);
    const [viewMoreAvailable, setViewMoreAvailable] = useState(false);

    const cancelTokenSource = axios.CancelToken.source();

    useEffect(() => {
        handleViewMore(0);
        setSkip(0);

        return () => {
            cancelTokenSource.cancel();
        }
    }, [])

    const handleSkip = (skip) => {
        setSkip(prevSkip => {
            return prevSkip + skip;
        });
    }

    const handleViewMore = async () => {
        setIsPending(true);

        const json = await OwnerService.GetCoursesCatalog(skip, cancelTokenSource);

        console.log('js', json)//  

        setIsPending(false);

        setCourses(prevPortions => {
            return [...prevPortions, ...json.data.portions];
        });

        handleSkip(3);

        setViewMoreAvailable(json.data.viewMoreAvailable);
    }

    return (
        <>
            <div className={styles.container}>
                <div className={styles.headContainer}>
                    <div className={styles.categoryContainer}>
                        <h3>Category</h3>
                        <ul className={styles.categoryList}>
                            {CategoriesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <input
                                            type="checkbox"
                                            id={`custom-checkbox-${index}`}
                                            name={name}
                                            value={name}
                                        />
                                        <span></span>
                                        <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                        <span></span>
                                    </li>
                                );
                            })}
                        </ul>
                    </div>
                    <div className={styles.lineContainer}>
                    </div>
                    <div className={styles.categoryContainer}>
                        <h3>Languages</h3>
                        <ul className={styles.languageList}>
                            {LanguagesList.map(({ name }, index) => {
                                return (
                                    <li key={index}>
                                        <input
                                            type="checkbox"
                                            id={`custom-checkbox-${index}`}
                                            name={name}
                                            value={name}
                                        />
                                        <span></span>
                                        <label htmlFor={`custom-checkbox-${index}`}>{name}</label>
                                        <span></span>
                                    </li>
                                );
                            })}
                        </ul>
                    </div>
                    <div className={styles.imageC}>
                        <img className={styles.book} src="/assets/images/Group 23.svg" alt="" />
                    </div>
                </div>
                <div className={styles.cardscontainer}>
                    {courses.length > 0
                        ? courses.map(x => <ManagerCourseCard key={x.id} course={x} courses={courses} setCourses={setCourses} isProfile={false} />)
                        : <h3>No courses yet</h3>
                    }
                </div>
                <div key={"unique_loading"} id={styles.pending}>
                    {isPending &&
                        <h2>Loading...</h2>
                    }
                </div>
                <div key={"unique_view_more"} className={styles.buttonContainer}>
                    {viewMoreAvailable &&
                        <Link to="" ><button className={styles.manageButton} onClick={() => { handleViewMore() }}>View More</button></Link>
                    }
                </div>
            </div>
        </>
    );
}
