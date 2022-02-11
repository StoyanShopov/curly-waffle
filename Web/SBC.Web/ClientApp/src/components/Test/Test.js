import css from "./Test.module.css"
import Background from '../../assets/Group 5.png'

export default function Test() {
    return (
        <>
            <div style={{ backgroundImage: `url(${Background})`, width: "1000px", height: "1000px" }} >
                <img src="/Group 5.jpg" className={css.pic} alt="" />
            </div>

            <div style={{
                backgroundImage: 'url("https://media.geeksforgeeks.org/' +
                    'wp-content/uploads/20201221222410/download3.png")',
                height: "300px", backgroundRepeat: "no-repeat"
            }}>
                <h1> HELLO </h1>
            </div>
            
        </>
    )
}
