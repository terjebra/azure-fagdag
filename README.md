# Azure fagdag

Dette repoet kan brukes som et utgangspunkt for fagdagen "Praktisk bruk av Azure".

Azure tjenester som benyttes i dette repo-et:

- Azure App registration
- Azure Static Web app
- Azure App Service
- Azure Application Insight
- Azure Function
- Azure Key Vault
- Azure Service Bus
- Azure SignalR Service
- Azure Table Storage

# Azure arkitektur

Nedefor vises Azure-tjenestene som er i bruk og samspilltet dem i mellom:

![Azure arkitektur](azure.png)

## Kode

Repo-et inneholder backend- og frontendkode. Koden er først og fremst tenkt som eksempelkode som kan deployes på fagdagen for å vise ulike tjenester i Azure og er ikke ment for produksjon.

## Backend

### Flight.Api

API for å hente ut flyplasser, statuser og flyinformasjon. Benytter [Avinors Api](https://avinor.no/en/corporate/services/flydata/flydata-i-xml-format). Dette API-et benyttes av web-appen.

Tilbyr også et endepunkt for å få notifikasjoner når en flight endrer seg

### Weather.Api

API for å hente ut værvarsel for gitt lokasjon (lat, long). Benytter [Yrs Api](https://developer.yr.no/doc/GettingStarted/)

### Notification

Inneholder Azure functioner

#### negotiate (Http-triggered)

Benyttes for å få tilgang til Azure SignalR Serice

#### notifications-queue (servie bus triggered)

Kjøres når nye meldinger kommer. Lagre subscription data (flyplass, flight og brukerid) i Azure Table Storage. Benytter Azure SignalR Service for å registrere flight og bruker-id og dermed få notifikasjoner når en flight endres (mutlicast)

#### flight-monitor (time triggered)

Kjøres hvert 3. minutt og sjekker endring (per nå kun mocket). Henter opp subscription informasjon fra Azure Table Storage og sender ut notfikasjoner via Azure SignalR Service.

## Frontend

En enkel webapp skrevet i ReactJS og TypeScript. Benytter Azure SignalR Service for notifikasjoner og Flight API for å hente flyplasser og flights.

## Ressurser

[Microsofts learning paths](https://docs.microsoft.com/en-us/learn/browse) er en godt start. Ellers finner man bra dokumentasjon generalt på Microsoft sine sider.
