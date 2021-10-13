import { useQuery } from "react-query";
import { config } from "./config";
import { Flight } from "./types";

export const useGetFlights = (airport: string) => {
  return useQuery<Flight[], Error>(`airports_${airport}`, async () => {
    const response = await fetch(
      `${config.flightAPI}/airports/${airport}/flights`
    );
    return await response.json();
  });
};
