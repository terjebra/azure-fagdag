import { useQuery } from "react-query";
import { config } from "./config";
import { Airport } from "./types";

export const useGetAirports = () => {
  return useQuery<Airport[], Error>("airports", async () => {
    const response = await fetch(`${config.flightAPI}/airports`);
    return await response.json();
  });
};
