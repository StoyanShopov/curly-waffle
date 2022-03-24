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

const deleteNotification = async (id) => {
  const response = await axios.delete(baseUrl + "api/Notifications?id=" + id, {
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
  deleteNotification,
}
