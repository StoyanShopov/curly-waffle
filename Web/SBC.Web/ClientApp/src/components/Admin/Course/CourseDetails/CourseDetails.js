import css from "./CourseDetails.module.css";

export default function CourseDetails() {
    return (
        <section className={css.container}>
            <div className={css.leftPart}>
                <h1 className={css.marketingHeader}>MARKETING</h1>
                <div>
                    <img src="/Rectangle 1396.svg" alt="image" />
                </div>
                <div className={css.controllsDiv}>
                    <img src="Polygon 5.svg" alt="image" />
                </div>
            </div>
            <div className={css.rightPart}>
                <p>part2</p>
            </div>
        </section>
    )
}