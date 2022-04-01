import axios from 'axios';

import { TokenManagement } from '../helpers';
import { baseUrl } from '../constants/GlobalConstants';

const loadClientData = async (skip, cancelTokenSource) => {
  const response = await axios.get(baseUrl + 'Administrator/Clients/Portion?skip=' + skip, {
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

export const addClient = async (client) => {
  const response = await axios.post(baseUrl + 'Administrator/Clients', client,
    {
      headers: {
        Authorization: `Bearer ${TokenManagement.getLocalAccessToken()}`,
      },
    });

  if (response.status !== 200) {
    throw new Error(response.Error);
  }

  return response;
}

export const ClientService = {
  loadClientData,
  addClient
}