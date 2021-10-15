import { useQuery } from "react-query";
import { config } from "./config";
import { Flight } from "./types";
import { useAuth } from "./useAuth";

export const useGetFlights = (airport: string) => {
  const auth = useAuth();
  return useQuery<Flight[], Error>(`airports_${airport}`, async () => {
    const response = await fetch(
      `${config.flightAPI}/airports/${airport}/flights`,
      {
        headers: {
          Authorization: `Bearer ${auth.token}`,
        },
      }
    );

    return await response.json();
  });
};
