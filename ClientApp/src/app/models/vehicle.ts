export interface keyValuePair{
    id:number;
    name:string;
}
export interface contact{
    name:string;
    phone:string;
    email:string;
}

export interface Vehicle{
    id:number,
    model:keyValuePair;
    make:keyValuePair;
    isRegistered:boolean;
    features:keyValuePair[];
    contact:contact;
    lastUpdate:string

}
export interface SaveVehicle{
    id:number,
    modelId:number;
    makeId:number;
    isRegistered:boolean;
    features:number[];
    contact:contact;

}