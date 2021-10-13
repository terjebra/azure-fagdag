import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Main from "./Pages/Main";
import Flights from "./Pages/Flights";

const App = () => {
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
