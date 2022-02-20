import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

export const LoadClientData = async (skip, cancelTokenSource) => {
  const response = await axios.get(baseUrl + 'Administration/Client/Portion?skip=' + skip, {
    cancelToken: cancelTokenSource.token,
    headers: {
      Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error(response.Error)
  }

  return response.data;
}

export const AddClient = async (client) => {
  const response = await axios.post(baseUrl + 'Administration/Client', client,
    {
      headers: {
        Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
      },
    });

    if (response.status !== 200 || response.status !== 201) {
      throw new Error(response.Error);
    }

  return response;
}