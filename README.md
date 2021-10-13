# WebApp og API med autentisering

Denne branchen fortsetter fra forrige. I denne branchen er Azure AD autentisering slått på.

## Autentisering

Det er blitt opprett to Azure AD app registrering-er, **Flight App Fagdag** og **Flight Api Fagdag** i forbindelese med fagdagen. Disse er opprettet på forhånd da disse krever en administrator godkjennelse på forhånd.

![App reg](app-reg.png)

App-en er følgende tillatelser:

![Perm app reg](permissions.png)

## Frontend

Hente ut **ClientId** og **TentantId** for **Flight App Fagdag**. Legg inn **REACT_APP_CLIENT_ID** og **REACT_APP_TENANT_ID** i Github-workflowen i dit private gitrepo for frontend-app (slik du gjorde i forrige steg for API-url)

Committ og push endringene (privat gitrepo som har Github action)

## Backend

Hente ut **TentantId** for **Flight Api Fagdag**. Og **ClientId** for **Flight App Fagdag**. Legg in **TentantId** i og **ClientId** (fra **Flight App Fagdag**) i Key Vault som hengholdsvis : **Azure--TentantId** og **Azure--Audience**.

Deploy ny versjon av API-et enten via Github-actions eller manuell deploy i Visual Studio 2019.
