import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import css from './Clients.module.css';


export default function Clients() {
  const [clients, setClients] = useState([]);
  const [skip, setSkip] = useState(0);
  const [viewMoreAvaliable, setViewMoreAvaliable] = useState(false);


  const url = 'https://localhost:44319/Administration/Client/GetPortion';

  useEffect(() => {
    handleViewMore(0);
    setSkip(3);
  }, [])

  const handleViewMore = async () => {
    console.log("Hello handleViewMore")

    const json = await GetPartions(skip);

    setClients(prevPortions => {
      return [...prevPortions, ...json.portions];
    });

    setSkip(prevSkip => {
      return prevSkip + 3;
    });

    setViewMoreAvaliable(json.viewMoreAvaliable);
  }

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
          </tr>
        </thead>
        <tbody>
          {clients && clients.map(client => (
            <tr key={client?.id}>
              <td>{client?.companyName}</td>
              <td>{client?.email.toLowerCase()}</td>
            </tr>
          ))}
          <tr id={css.flex}>
            <td>
              {viewMoreAvaliable &&
                <Link to="" className={css.link} onClick={() => { handleViewMore() }}>View More</Link>
              }
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );

  async function GetPartions(skip) {
    const controller = new AbortController()

    const response = await fetch(url + '?skip=' + skip, {
      method: 'Get',
      headers: {
        'Content-Type': 'application/json'
      },
      signal: controller.signal
    });

    if (response.status !== 200) {
      throw new Error(response.statusText)
    }

    const json = await response.json();

    return json;
  }
}