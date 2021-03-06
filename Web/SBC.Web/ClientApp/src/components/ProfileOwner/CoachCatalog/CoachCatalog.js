import axios from 'axios';
import { useEffect, useState} from 'react';
import { Link } from "react-router-dom";

import { ownerService } from '../../../services';
import ManagerCoachCard from '../../Fragments/CoachCards/ManagerCoachCard';

import { CategoriesList } from "../CourseCatalog/CategoriesList";
import { LanguagesList } from "../CourseCatalog/LanguagesList";

import styles from "./CoachCatalog.module.css";

export default function CoachCatalog(props) {
    const [coaches, setCoaches] = useState([]);

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

        const json = await ownerService.getCoachesCatalog(skip, cancelTokenSource);

        console.log('js', json)       

        setIsPending(false);

        setCoaches(prevPortions => {
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
                        <img className={styles.megaphone} src="/assets/images/Group 49.svg" alt="" />
                    </div>
                </div>
                <div className={styles.cardscontainer}>
                    {coaches.length > 0
                        ? coaches.map(x => <ManagerCoachCard key={x.id} coach={x} coaches={coaches} setCoaches={setCoaches} isProfile={false} connection={props.connection} sendNotification={props.sendNotification} />)
                        : <h3>No coaches yet</h3>
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
