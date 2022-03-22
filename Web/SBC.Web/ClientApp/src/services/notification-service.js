import axios from "axios";

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

export const LoadNotifications = async (email) => {
  const response = await axios.get(baseUrl + 'api/Notifications/All', {
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