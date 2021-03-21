# Invert API

<p align="center">
  <img src="https://raw.githubusercontent.com/Mentors4EDU/Images/master/spaces_-Lvv5ZdlY65NsFAqv-z0_avatar.png">
</p>

## 🚧 under active development - please contribute! 🚧
Invert-API is an advertising platform to communicate with customers inside an application, it can be used to set maintenance notices, request app updates, or display cross-sell opportunities.
### Docs
Can be found [here](https://docs.invert.dev/).

### Quickstart
`git clone https://github.com/behoyh/invert-api.git`

Run `docker-compose up`

Navigate to [https://localhost:44336/swagger](https://localhost:44336/swagger)

### Development
It is recommended you create a appsettings.Local.json file in /src to put in your desired values for database connection strings and file storage.

Otherwise you may inadvertently expose the connection string through a PR or the like. Be careful.

[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/behoyh/invert-api)

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
