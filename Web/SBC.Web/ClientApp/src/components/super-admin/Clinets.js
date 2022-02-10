import { Link } from 'react-router-dom';
import css from './Clients.module.css';

export default function Clients() {
  return (
    <div className={css.container}>
      <table className={css.table}>
        <thead>
          <tr class="blue-background">
            <th>Company Name</th>
            <th>Email</th>
            <td className={css.addClient}>
              <Link to="" onClick={() => { }}>
                <img src={"../../../add-client.ico"} alt="add-icon"></img>
              </Link>
            </td>
            {/* <td id="add-client"><a><img src="../../../public/add-client.ico"></img></a></td> */}
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Motion Software</td>
            <td>hello@motion-sofrware.com</td>
          </tr>
          <tr>
            <td>Software University</td>
            <td>university@softuni.bg</td>
          </tr>
          <tr>
            <td>VMware</td>
            <td>partnerconnect@vmware.com</td>
          </tr>
          <tr id={css.flex}>
            <td>
              <Link to="" className={css.link} onClick={() => { }}>View More</Link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}