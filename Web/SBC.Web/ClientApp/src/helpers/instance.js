import axios from 'axios';
import { TokenManagement } from './index';
import { baseUrl } from '../constants/GlobalConstants';

export const instance = axios.create({
    baseURL: baseUrl,
    headers: {
        "Content-Type": "application/json",
    },
});

//request handler
instance.interceptors.request.use(
    (config) => {
        const token = TokenManagement.getLocalAccessToken();

        if(token) {
            config.headers['www-authenticate'] = token;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

//response handler
instance.interceptors.response.use(
    (response) => {
        return response;
    },
    async (error) => {
        const baseConfig = error.config;

        if(baseConfig.url !== "/api/Identity/login" && error.response){
            // Expired Token
            if(error.response.status === 401 && !baseConfig._retry) {
                baseConfig._retry = true;

                try {
                    const newToken = await instance.post('/check url', {
                        refreshToken: TokenManagement.getLocalRefreshToken(),
                    });

                    const { accessToken } = newToken.data;
                    TokenManagement.updateLocalAccessToken(accessToken);

                    return instance(baseConfig);
                } catch (_error) {
                    return Promise.reject(_error);
                }
            }
        }

        return Promise.reject(error);
    }
);

