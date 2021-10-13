export type Airport = {
  code: string;
  name: string;
};

export type Flight = {
  airline: string;
  scheduleTime: string;
  direction: Direction;
  statusCode: string;
  flightId: string;
  airport: string;
};

export enum Direction {
  Arrival = "Arrival",
  Departure = "Departure",
}
