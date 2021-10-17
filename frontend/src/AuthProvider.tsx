import React, { useEffect } from "react";
import { useAccount, useIsAuthenticated, useMsal } from "@azure/msal-react";
import { config } from "./config";

type Dispatch = (action: Action) => void;

export type State = {
  isAuthenticated: boolean;
  token: string | null;
};

const AuthContext = React.createContext<State>({
  isAuthenticated: false,
  token: null,
});

const AuthDispatchContext = React.createContext<Dispatch | undefined>(
  undefined
);

export enum ActionType {
  Authenticate = "Authenticate",
  Unauthenticated = "Unauthenticated",
}

type AuthenticateAction = {
  token: string;
  type: ActionType.Authenticate;
};
type UnauthenticatedAction = {
  type: ActionType.Unauthenticated;
};

type Action = AuthenticateAction | UnauthenticatedAction;

const authReducer = (_state: State, action: Action) => {
  switch (action.type) {
    case ActionType.Authenticate:
      return { isAuthenticated: true, token: action.token };
    case ActionType.Unauthenticated: {
      return { isAuthenticated: false, token: "" };
    }
    default:
      return { isAuthenticated: false, token: "" };
  }
};

const AuthProvider: React.FC = (props) => {
  const { instance, accounts, inProgress } = useMsal();
  const isAuthenticated = useIsAuthenticated();
  const account = useAccount(accounts[0] || {});
  useEffect(() => {
    if (!isAuthenticated && inProgress === "none") {
      const login = async () => {
        await instance.loginRedirect({
          scopes: ["User.Read"],
        });
      };

      login();
    }
  }, [isAuthenticated, inProgress, instance]);

  useEffect(() => {
    if (account) {
      instance
        .acquireTokenSilent({
          scopes: [config.apiScope],
          account: account,
        })
        .then((response) => {
          console.log(response.accessToken);
          dispatch({
            token: response.accessToken,
            type: ActionType.Authenticate,
          });
        });
    }
  }, [account, instance]);

  const [state, dispatch] = React.useReducer(authReducer, {
    isAuthenticated: false,
    token: "",
  });

  return (
    <AuthContext.Provider value={state}>
      <AuthDispatchContext.Provider value={dispatch}>
        {props.children}
      </AuthDispatchContext.Provider>
    </AuthContext.Provider>
  );
};

export { AuthProvider, AuthContext, AuthDispatchContext };
