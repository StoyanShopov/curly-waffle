import { Link } from 'react-router-dom';

import css from './NotificationModal.module.css';

export default function EditProfile(props) {
  return (
    <div className={css.NotificationContainer}>
      {props.notifications.map(notification => (
        <div key={notification.id} className={css.HeaderDiv}>
          <h3>Notification:<span> {notification.message}</span> </h3>
          <Link to="" onClick={() => props.removeNotification(notification.id)}>X</Link>
        </div>
      ))}
      {props.notifications.length > 0 ?
        <div>
          <button className={css.clearBtn} onClick={props.removeNotifications}>Clear All</button>
        </div>
        : <div className={css.HeaderDiv}>No messages</div>}
    </div>
  )
}