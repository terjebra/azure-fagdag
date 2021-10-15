import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
  HttpTransportType,
} from "@microsoft/signalr";
import { useEffect, useState } from "react";
import { config } from "./config";

export const useSignalR = (id: string) => {
  const [state, setState] = useState<HubConnection | null>(null);

  useEffect(() => {
    (async () => {
      const response = await fetch(config.signalrNegoiateUrl, {
        method: "post",
        headers: {
          "x-user-id": id,
        },
      });

      const data: any = await response.json();

      const connection = new HubConnectionBuilder()
        .withUrl(data.url, {
          transport: HttpTransportType.WebSockets,
          accessTokenFactory: () => data.accessToken,
        })
        .configureLogging(LogLevel.Error)
        .withAutomaticReconnect()
        .build();

      connection.start().then(() => {
        setState(connection);
      });
    })();
  }, [id]);

  return state;
};
