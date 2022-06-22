export class Message {

    userName: string;
    message: string;
    TranslatedMessage: string ;
    userId : number;
    id: number;
    createDate: Date;

    public constructor(b: Partial<Message> = {}) {
        Object.assign(this, b);
     }
}