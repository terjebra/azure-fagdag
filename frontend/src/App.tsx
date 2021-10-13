import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Main from "./Pages/Main";
import Flights from "./Pages/Flights";
import { useAuth } from "./useAuth";
import { Container } from "@mui/material";

const App = () => {
  const auth = useAuth();

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
  );
};

export default App;
