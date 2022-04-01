import CanvasJSReact from '../Canvas/assets/canvasjs.react';
import css from '../../Admin/Dashboard/Dashboard.module.css';

export default function Diagram(props) {
    var CanvasJSChart = CanvasJSReact.CanvasJSChart;
    let _data = props.curve;
    const options = {
        animationEnabled: false,
        exportEnabled: false,
        theme: "light2", // "light1", "dark1", "dark2"
        axisY: {
            includeZero: true,
        },
        axisX: {
            includeZero: true,
            intervalType: "month",
            valueFormatString: "MMM"
        },
        data: [{
            type: "line",
            color:props.color,
            xValueType: "month",
            dataPoints: props.curve
        }]
    }
    
    return (
        <section className={css.curve} >
            <h3 style={{ background: props.color }}>{props.title}</h3>
            <CanvasJSChart options = {options} 
				/* onRef={ref => this.chart = ref} */
			/>
        </section >);
}

