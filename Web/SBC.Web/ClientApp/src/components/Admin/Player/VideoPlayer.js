import React from 'react'
import ReactPlayer from 'react-player'

import style from "./VideoPlayer.module.css";

const ResponsivePlayer = (props) => {
    return (
        <div className={style.playerWrapper}>
            <ReactPlayer
                className={style.reactPlayer}
                url={props.videoUrl}
                width='100%'
                height='100%'
                controls={true}
            />
        </div>
    )
}

export default ResponsivePlayer;