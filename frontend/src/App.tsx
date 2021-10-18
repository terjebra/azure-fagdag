import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Main from "./Pages/Main";
import Flights from "./Pages/Flights";
import { useAuth } from "./useAuth";
import { Container, Snackbar } from "@mui/material";
import { useSignalR } from "./useSignalR";
import { useEffect, useState } from "react";
import { Flight } from "./types";

const App = () => {
  const auth = useAuth();

  const [notifications, setNotifications] = useState<Flight[]>([]);
  const [isOpen, setIsOpen] = useState<boolean>(true);

  const connection = useSignalR(auth.id!);

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
      setNotifications([]);
    }, 5000);
    return () => clearInterval(interval);
  }, []);

  const messages = notifications?.map((x) => {
    return <div key={x.flightId}>{`Changes for flight ${x.flightId}`}</div>;
  });

  if (!auth.isAuthenticated) {
    return (
      <Container
        sx={{
          display: "grid",
          placeItems: "center",
          height: "100vh",
          bgcolor: "primary.light",
          minWidth: "100%",
        }}
      ></Container>
    );
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
