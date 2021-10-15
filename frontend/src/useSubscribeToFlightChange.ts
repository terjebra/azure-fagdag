import { useMutation } from "react-query";
import { config } from "./config";

type Data = {
  airport: string;
  flightId: string;
};

export const useSubscribeToFlightChange = () => {
  return useMutation<any, Error, Data>((data) => {
    return fetch(
      `${config.flightAPI}/airports/${data.airport}/flights/${data.flightId}/subscriptions`,
      {
        method: "POST",
        headers: {
          "x-user-id": config.userId,
        },
      }
    );
  });
};
