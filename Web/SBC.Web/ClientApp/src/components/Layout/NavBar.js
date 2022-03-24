import { useEffect, useState } from 'react';
import Modal from 'react-modal';
import { NavLink, Link } from 'react-router-dom';

import styles from "./NavBar.module.css";

import { notificationService } from '../../services/notification-service';
import NotificationModal from './NotificationModal';

const NavBar = (props) => {
  const [notifications, setNotofications] = useState([]);
  const [modalIsOpen, setModalIsOpen] = useState(false);

  const email = localStorage?.userData?.split(',')[1]?.split(':')[1]?.replace('"', "")?.replace('"', "");

  useEffect(() => {
    async function fun() {
      await addNotifications();
    }

    fun();
  }, [])

  const addNotifications = async () => {
    const json = await notificationService.getNotifications(email);

    setNotofications([...json])
  }

  const removeNotification = async (id) => {
    await notificationService.deleteNotification(id);

    setNotofications(prevNotifications => [...prevNotifications.filter(n => n.id !== id)])
  }

  const removeNotifications = async () => {
    notifications.forEach(async (notification) => {
      await notificationService.deleteNotification(notification.id);
    });

    setNotofications([])
  }

  function openModal() {
    setModalIsOpen(true);
  }

  function afterOpenModal() {
    subtitle.color = '#000';
  }

  function closeModal() {
    setModalIsOpen(false);
  }

  let subtitle = {
    content: {
      top: '55%',
      left: '50%',
      right: 'auto',
      width: '30%',
      height: '300px',
      bottom: 'auto',
      marginTop: '-5%',
      marginRight: '-50%',
      transform: 'translate(+65%, -70%)',
      padding: '0px',
    },
    color: '#000'
  };

  return (
    <header className={styles.headerC}>
      <div className={styles.headerContainer}>
        < div className={styles.logoContainer}>
          <img src="/assets/images/Group 5.svg" className={styles.arrow} alt="" />
          < div className={styles.upskillContainer}>
            <NavLink to="/" className={styles.upskillLink}>upskill</NavLink>
          </div>
        </div>
        <div className={styles.testedLinks}>
        </div>
        <div className={styles.homePageButtons}>
          {props.auth.user != null
            ? null
            : unLogged}
        </div>
        <div className={styles.coursesCoaches}>
          <ul>
            <li>
              <NavLink
                to="/courses"
                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
              >
                Courses
              </NavLink>
            </li>
            <li>
              <NavLink
                to="/coaches"
                className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
              >
                Coaches
              </NavLink>
            </li>
            <li>
              {email && (notifications.length > 0 ?
                <Link
                  to="" onClick={() => openModal()}>
                  <i className="fa fa-bell fa-shake fa-lg fa-spin"></i>
                </Link>
                :
                <div>
                  <Link
                    to="" onClick={() => openModal()}>
                    <i className="fa fa-bell fa-lg rotate"></i>
                  </Link>
                </div>)
              }
            </li>
          </ul>
        </div>
        <div className={styles.greenCircle}>
          A
        </div>
        {props.auth.user != null
          ?
          <div className={styles.greenCircle}>
            <NavLink tag={Link} to="profile">{props.auth.user.fullname[0]}</NavLink>
          </div>
          : null}
      </div>

      <Modal
        style={subtitle}
        isOpen={modalIsOpen}
        onAfterOpen={afterOpenModal}
        onRequestClose={closeModal}
        ariaHideApp={false}
      >
        <NotificationModal removeNotifications={removeNotifications} removeNotification={removeNotification} notifications={notifications} email={email} closeModal={closeModal} />
      </Modal>
    </header>
  )
}

export default NavBar;
const courses = (
  <ul>

    <li>
      <NavLink
        to="admin/courses"
        className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
      >
        Courses
      </NavLink>
    </li>
    <li>
      <NavLink
        to="admin/coaches"
        className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
      >
        Coaches
      </NavLink>
    </li>
  </ul>
);
const unLogged = (<ul>
  <li>
    <Link to="/login" ><button className={styles.loginButton}>Login</button></Link>
  </li>
  <li>
    <Link to="/request-a-demo" ><button className={styles.requestDemoBtn}>Request a Demo</button></Link>
  </li>
</ul>);
