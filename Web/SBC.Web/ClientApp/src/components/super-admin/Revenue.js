import css from "./Revenue.module.css"

export default function Revenue() {
    return (
        <div className={css.revenue}>
        <table>
            <thead style={{background:"#296CFB"}}>
                <tr>
                <th>Course/Coach</th>
                <th>Revenue</th>
                <th>Expenses</th>
                <th>Profit</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Design</td>
                    <td>10000€</td>
                    <td>2000€</td>
                    <td>8000€</td>
                </tr>
                <tr>
                    <td>Managment</td>
                    <td>5000€</td>
                    <td>2000€</td>
                    <td>3000€</td>
                </tr>
                <tr>
                    <td>Marketing</td>
                    <td>12000€</td>
                    <td>10000€</td>
                    <td>2000€</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                <td>Total</td>
                <td></td>
                <td></td>
                <td>13000€</td>
                </tr>
            </tfoot>
        </table>
        </div>
    );
}