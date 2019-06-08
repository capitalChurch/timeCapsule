import {TypeMessageEnum} from '@/model/types/TypeMessageEnum';

export interface Message {
    email: string;
    dateRegister: Date;
    yearsToSend: number;
    text: string;
    type: TypeMessageEnum;
}
