import {Message} from '@/model/types/Message';
import axios from 'axios';

const development = 'development';

export const saveMessage = (obj: Message, callBack: () => void, callBackError: (err: any) => void): void => {
    const urlProduction = 'https://kevynklava.com/time-capsule';
    const urlDevelopment = 'http://localhost:44396';
    const url = process.env.NODE_ENV === development ? urlDevelopment : urlProduction;
    const urlMessage = `${url}/api/TimeCapsule/`;

    axios.post(urlMessage, obj)
        .then(callBack)
        .catch(callBackError);
};
