# invert-api
## 🚧 under active development - please contribute! 🚧
Invert-API is an advertising platform to communicate with customers inside an application, it can be used to set maintenence notices, request app updates, or display cross-sell opportunities.
### Docs
Can be found [here](https://docs.invert.dev/).

### Quickstart
> `git clone https://github.com/behoyh/invert-api.git`

> Run `docker-compose up`

>  Navigate to https://localhost:44336/swagger

### Marketing Samples
* [Marketing Ad](https://gist.github.com/behoyh/8dd42e853ca2a5cf369dc9e0da7ad1d9) (web)

Running invert-api will launch into a Swagger API doc, and a connceted SQL Server instance will automatically have relevant tables created. 

There are four types of messages by default:

- 0 - Banners. Banners typically go at the top of the app/page, and may or may not exhibit a ticker-like format. In any case, these messages should be kept short and sweet with a link to additional content if needed.

- 1 - Popups. Popups are useful sometimes to convey messages that must be seen, such as changing terms of service.

- 2 - Marketing Ads.

- 3 - Login. Login alerts are something you’ll see even before you authenticate into an app. These will let you know if the system is down for whatever reason, or force an upgrade from an older version.

This list can be customized/extended to suit your needs.


The UI for managing these messages is currently under development at - [invert-ui](https://github.com/behoyh/invert-ui)


Uses the Detroit Labs login check format:

[LaunchGate](https://github.com/dtrenz/LaunchGate)

[Gandalf](https://github.com/btkelly/gandalf)
