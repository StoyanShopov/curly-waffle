import css from "./Revenue.module.css";

export default function Revenue() {
    return (
        <div className={css.revenue}>
            <table>
                <thead style={{ background: "#296CFB" }}>
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
                        <td>1 0000€</td>
                        <td>2 000€</td>
                        <td>8 000€</td>
                    </tr>
                    <tr>
                        <td>Managment</td>
                        <td>5 000€</td>
                        <td>2 000€</td>
                        <td>3 000€</td>
                    </tr>
                    <tr>
                        <td>Marketing</td>
                        <td>12 000€</td>
                        <td>10 000€</td>
                        <td>2 000€</td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td>Total</td>
                        <td></td>
                        <td></td>
                        <td>13 000€</td>
                    </tr>
                </tfoot>
            </table>
        </div>
    );
}