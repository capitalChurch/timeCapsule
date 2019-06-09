import {Message} from '@/model/types/Message';
import axios from 'axios';

const development = 'development';

export const saveMessage = (obj: Message, callBack: () => void, callBackError: (err: any) => void): void => {
    const urlProduction = 'http://cartaparaofuturo.azurewebsites.net/';
    const urlDevelopment = 'http://localhost:44396/';
    const urlBase = process.env.NODE_ENV === development ? urlDevelopment : urlProduction;
    const url = `${urlProduction}api`;
    const urlMessage = `${url}/TimeCapsule/`;

    axios.post(urlMessage, obj)
        .then(callBack)
        .catch(callBackError);
};

