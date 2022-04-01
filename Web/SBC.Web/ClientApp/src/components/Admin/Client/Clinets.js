import axios from 'axios';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import css from './Clients.module.css';
import ModalAddClients from './ModalAddClients';
import { ClientService } from '../../../services/client-service';


export default function Clients(props) {
  const [clients, setClients] = useState([]);
  const [isPending, setIsPending] = useState(false);
  const [skip, setSkip] = useState(0);
  const [viewMoreAvaliable, setViewMoreAvaliable] = useState(false);

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

  const handleClient = (client) => {
    setClients(prevPortions => {
      return [client, ...prevPortions];
    });
  }

  const handleViewMore = async () => {
    setIsPending(true);

    const json = await ClientService.loadClientData(skip, cancelTokenSource);

    setIsPending(false);

    setClients(prevPortions => {
      return [...prevPortions, ...json.portions];
    });

    handleSkip(3);

    setViewMoreAvaliable(json.viewMoreAvaliable);
  }

  function onOpenModal(){
    console.log(props.modal)
    props.modal.openModal(
      <ModalAddClients closeModal={props.modal.handleClose}  handleSkip={handleSkip} handleClient={handleClient} />,
      style
    )
  }
  return (
    <>
      <div className={css.container}>
        <table className={css.table}>
          <thead>
            <tr>
              <th>Company Name</th>
              <th>Email</th>
              <td className={css.addClient}>
                <Link to="" onClick={() => onOpenModal()}>
                  <img className={css.plus} src={"/add-client.ico"} alt="add-icon"></img>
                </Link>
              </td>
            </tr>
          </thead>
          <tbody>
            {clients && clients.map(client => (
              <tr key={client?.id}>
                <td>{client?.companyName}</td>
                <td>{client?.email?.toLowerCase()}</td>
              </tr>
            ))}
            <tr key={"unique_loading"} id={css.pending}>
              {isPending &&
                <td>
                  <h2>Loading...</h2>
                </td>
              }
            </tr>
            <tr key={"unique_view_more"} id={css.flex}>
              <td>
                {viewMoreAvaliable &&
                  <Link to="" className={css.link} onClick={() => { handleViewMore() }}>View More</Link>
                }
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </>
  );
}

const style = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    width: '44%',
    bottom: 'auto',
    transform: 'translate(-50%, -50%)',
    padding: '0px',
  }
}
