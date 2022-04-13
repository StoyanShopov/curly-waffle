import { Link } from 'react-router-dom';

import styles from './NotificationModal.module.css';

export default function NotificationModal(props) {
  return (
    <div className={styles.notificationContainer}>
      {props.notifications.map(notification => (
        <div key={notification.id} className={styles.headerDiv}>
              <h3 className={styles.hThree}>Notification:<span className={styles.hSpan}> {notification.message}</span> </h3>
          <Link to="" onClick={() => props.removeNotification(notification.id)}>X</Link>
        </div>
      ))}
      {props.notifications.length > 0 ?
        <div>
          <button className={styles.clearBtn} onClick={props.removeNotifications}>Clear All</button>
        </div>
        : <div className={styles.HeaderDiv}>No messages</div>}
    </div>
  )
}
