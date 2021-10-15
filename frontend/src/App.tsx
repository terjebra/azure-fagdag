import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Main from "./Pages/Main";
import Flights from "./Pages/Flights";
import { useAuth } from "./useAuth";

const App = () => {
  const auth = useAuth();

  if (!auth.isAuthenticated) {
    return <div>Auth..</div>;
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
