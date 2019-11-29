# invert-api
## 🚧 under active development 
Invert-API is an advertising platform to communicate with customers inside an application, it can be used to set maintenence notices, request app updates, or display cross-sell opportunities.

> Run docker-compose up or have a local SQL Server installed!

Running invert-api will launch into a Swagger API doc, and a connceted SQL Server instance will automatically have relevant tables created. 

There are four types of messages by default:

- 0 - Banners. Banners typically go at the top of the app/page, and may or may not exhibit a ticker-like format. In any case, these messages should be kept short and sweet with a link to additional content if needed.

- 1 - Popups. Popups are useful sometimes to convey messages that must be seen, such as changing terms of service.

- 2 - Marketing. Marketing messages are just ads, but first party ones (so they can sell you MORE stuff).

- 3 - Login. Login alerts are something you’ll see even before you authenticate into an app. These will let you know if the system is down for whatever reason, or force an upgrade from an older version.

These can be customized/extended to suit your needs.


The UI for managing these messages is currently under development at - [invert-ui](https://github.com/behoyh/invert-ui)


Uses the Detroit Labs login check format:

[LaunchGate](https://github.com/dtrenz/LaunchGate)

[Gandalf](https://github.com/btkelly/gandalf)
