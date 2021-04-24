import { BookingsHistory } from "./bookings-history";

export interface CabTypes{

    id: number;
    name: string;
    bookings: BookingsHistory[];
    
}