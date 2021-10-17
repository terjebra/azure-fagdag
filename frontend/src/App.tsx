import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Main from "./Pages/Main";
import Flights from "./Pages/Flights";
import { useAuth } from "./useAuth";
import { Snackbar } from "@mui/material";
import { useSignalR } from "./useSignalR";
import { useEffect, useState } from "react";
import { config } from "./config";
import { Flight } from "./types";

const App = () => {
  const auth = useAuth();

  const [notifications, setNotifications] = useState<Flight[]>([]);
  const [isOpen, setIsOpen] = useState<boolean>(true);
  const connection = useSignalR(config.userId);

  useEffect(() => {
    connection?.on("flights", (data: string) => {
      var flight: Flight = JSON.parse(data);
      setNotifications((notifications) => {
        return [...notifications, flight];
      });
    });
  }, [connection]);

  useEffect(() => {
    const interval = setInterval(() => {
      console.log("clear");
      setNotifications([]);
    }, 5000);
    return () => clearInterval(interval);
  }, []);

  const messages = notifications?.map((x) => {
    return <div key={x.flightId}>{`Changes for flight ${x.flightId}`}</div>;
  });

  if (!auth.isAuthenticated) {
    return <div>Auth..</div>;
  }
  return (
    <div>
      <Router>
        <Switch>
          <Route path="/" exact>
            <Main />
          </Route>
          <Route path="/airports/:airport/flights">
            <Flights />
          </Route>
        </Switch>
      </Router>
      {notifications.length > 0 && (
        <Snackbar
          anchorOrigin={{ vertical: "top", horizontal: "left" }}
          open={isOpen}
          autoHideDuration={5000}
          onClose={() => {
            setIsOpen(!isOpen);
          }}
          message={<div>{messages}</div>}
        />
      )}
    </div>
  );
};

export default App;
