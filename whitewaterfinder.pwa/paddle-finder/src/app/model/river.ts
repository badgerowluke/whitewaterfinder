export interface River {
    name: string;
    riverId: string;
    riverData: RiverData[];
    latitude: string;
    longitude: string;
}
export interface RiverData {
    dateTime: Date;
    flow: string;
    level: string;
}
