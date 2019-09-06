import { SharedConstants } from './shared-constants';

export class AccountCard{
    id: string;
    name: string;

    constructor(name: string, id?: string) {
        this.name = name;   
        this.id = id || SharedConstants.GUID_TEMPLATE; 
    }
}