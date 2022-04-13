import React from "react"

import style from "./ReplacementPage.module.css";

function ReplacementPage() {
    return (

        <section className={style.container}>
            <div className={style.picDiv}>
                <img src="/assets/images/Path9.png" className={style.signupFigure} />
                <img src="assets/images/Group50_2x.png" className={style.man} />
            </div>
            <div className={style.buttonAndText}>

                <div>
                    <img src="/assets/images/Group 5.svg" className={style.arrow} alt="" />
                </div>
                <h1 className={style.feature}>Feature in progress!</h1>
                <h2 className={style.functionality}>This functionality is still under development!</h2>
                <h4>
                    Support us on patreon! &nbsp; &nbsp;
                    <i className="fa fa-solid fa-mug-hot fa-lg"
                        style={{ fontSize: '40px', color: "#296CFB", cursor: 'pointer' }} >
                    </i>
                </h4>

            </div>
        </section>
    );
}

export default ReplacementPage;
