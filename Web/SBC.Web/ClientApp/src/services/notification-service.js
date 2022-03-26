import axios from "axios";

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

const getNotifications = async (email) => {
  const response = await axios.get(baseUrl + 'api/Notifications/All?email=' + email, {
    // cancelToken: cancelTokenSource.token,
    headers: {
      Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error(response.Error)
  }

  return response.data;
}

const addNotification = async (uniquegroupkey, userEmail, message) => {
  const response = await axios.post(
    baseUrl 
    + "api/Notifications?useremail=" + userEmail
    + '&message=' + message
    + "&uniquegroupkey=" + uniquegroupkey, {
    headers: {
      Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
    },
  })

  if (response.status !== 200) {
    throw new Error(response.Error)
  }

  return response.data;
}

const deleteNotification = async (id) => {
  console.log(id)
  const response = await axios.delete(baseUrl + "api/Notifications/" + id, {
    headers: {
      Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
    },
  })

  if (response.status !== 200) {
    throw new Error(response.Error)
  }

  return response.data;
}

const deleteNotificationByKeyAndEmail = async (uniqueGroupKey, email) => {
  const response = await axios.delete(baseUrl 
    + "api/Notifications?uniqueGroupKey=" + uniqueGroupKey
    + "&userEmail=" + email, {
    headers: {
      Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
    },
  })

  if (response.status !== 200) {
    throw new Error(response.Error)
  }

  return response.data;
}

export const notificationService = {
  getNotifications,
  addNotification,
  deleteNotification,
  deleteNotificationByKeyAndEmail,
}
