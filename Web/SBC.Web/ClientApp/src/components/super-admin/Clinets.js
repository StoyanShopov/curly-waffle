import { useEffect, useState, useCallback } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

import css from './Clients.module.css';
import Modal from 'react-modal';
import ModalAddClients from './ModalAddClients';
import { baseUrl } from '../../constants/GlobalConstants'

export default function Clients() {
  const [clients, setClients] = useState([]);
  const [skip, setSkip] = useState(0);
  const [isPending, setIsPending] = useState(false);
  const [viewMoreAvaliable, setViewMoreAvaliable] = useState(false);
  const [showModal, setShowModal] = useState(false);

  const cancelTokenSource = axios.CancelToken.source();
  const url = baseUrl + 'Administration/Clients/Portion';

  useEffect(() => {
    handleViewMore(0);
    setSkip(0);

    return () => {
      cancelTokenSource.cancel();
    }
  }, [])

  const handleClose = useCallback(() => {
    setShowModal(false)
  }, []);

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

    const json = await GetPartions(skip, cancelTokenSource);

    setIsPending(false);

    setClients(prevPortions => {
      return [...prevPortions, ...json.portions];
    });

    handleSkip(3);

    setViewMoreAvaliable(json.viewMoreAvaliable);
  }

  const GetPartions = async (skip, cancelTokenSource) => {
    const response = await axios.get(url + '?skip=' + skip, {
      cancelToken: cancelTokenSource.token
    });

    if (response.status !== 200) {
      throw new Error(response.Error)
    }

    return response.data;
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
                <Link to="" onClick={() => setShowModal(true)}>
                  <img src={"../../../add-client.ico"} alt="add-icon"></img>
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
            <tr id={css.pending}>
                {isPending &&
                  <h2>Loading...</h2>
                }
            </tr>
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

      <Modal
        style={{
          content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            width: '45%',
            bottom: 'auto',
            transform: 'translate(-50%, -50%)',
            padding: '0px',
          }
        }}
        isOpen={showModal}
        onRequestClose={handleClose}
        contentLabel="Example Modal"
      >
        <ModalAddClients handleClose={handleClose} handleSkip={handleSkip} handleClient={handleClient} />
      </Modal>
    </>
  );
}