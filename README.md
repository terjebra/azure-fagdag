# WebApp, API, Service Bus, SignalR og Azure Functions

Denne branchen fortsetter fra forrige. I denne branchen brukes Azure Service Bus, SignalR
Azure Functions (time, http, and service bus triggere) samt Azure Table Storage

### Azure konfigurasjon

### Portal

Logg inn i [Azure portal](https://portal.azure.com/#home). Forutsetter at
ressursgruppe og ressurser fra **01-webapp-and-webapi** er opprettet. Hvis ikke se README.

For navngiving se [her](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/resource-abbreviations)

- Opprett Azure SignalR Service (serverless)
- **sigr-`<navn>`**
  ![Signalr](signalr.png)
- Opprett Storage account
  - **st`<navn>`** (merk ikke tillatt med "-")
    ![Stb](stb.png)
- Opprett Service Bus ressurser

  - Namespace:
    - **sb-`<navn>`**
      ![Sb](sb.png)
  - Queue(flight-notifications-queue):
    ![queue](queue.png)

- Opprett Function App (**Hosting**: velg storage account-en som allerede er opprettet. **Monitoring**: velg Application insight som er oppprett tidligere)
  - **func-`<navn>`**
    ![func](func.png)

Dette gir da følgende innhold i ressurs-gruppen:

![Ressursgruppeinnhold](resource-group.png)

## Key-vault

Legge inn connection strings fra SignalR og Service Bus i Key-vault:
