import { useQuery } from "react-query";
import { config } from "./config";
import { Airport } from "./types";
import { useAuth } from "./useAuth";

export const useGetAirports = () => {
  const auth = useAuth();

  return useQuery<Airport[], Error>("airports", async () => {
    const response = await fetch(`${config.flightAPI}/airports`, {
      headers: {
        Authorization: `Bearer ${auth.token}`,
      },
    });
    return await response.json();
  });
};
