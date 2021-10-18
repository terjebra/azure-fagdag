import { useMutation } from "react-query";
import { config } from "./config";
import { useAuth } from "./useAuth";

type Data = {
  airport: string;
  flightId: string;
};

export const useSubscribeToFlightChange = () => {
  const auth = useAuth();
  return useMutation<any, Error, Data>((data) => {
    return fetch(
      `${config.flightAPI}/airports/${data.airport}/flights/${data.flightId}/subscriptions`,
      {
        method: "POST",
        headers: {
          Authorization: `Bearer ${auth.token}`,
        },
      }
    );
  });
};
