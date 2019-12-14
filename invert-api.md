# Invert API
### /api/LoginMessage/all
> Get a list of all login messages.
#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/LoginMessage/update
> Updates a login message.
#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| message | body |  | No | [Request[LoginMessage]](#request[loginmessage]) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/user
> Gets an object for messages to be displayed to a particular user.
#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| uid | body |  | No | [Request[String]](#request[string]) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/all
> Get a list of all marketing messages, for listing purposes.
#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/select
> Returns a singular marketing message. Used to display and edit.
#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| request | body |  | No | [Request[Int64]](#request[int64]) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/update
> Updates a marketing message.
#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| message | body |  | No | [Request[MESSAGE]](#request[message]) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/add-list
> Adds a list of targeted users for a particular marketing message.
#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| targetedList | body |  | No | [Request[TargetRequest]](#request[targetrequest]) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### Models


#### Request[LoginMessage]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | [LoginMessage](#loginmessage) |  | No |

#### LoginMessage

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| alert | [alert](#alert) |  | No |
| optionalUpdate | [optionalUpdate](#optionalupdate) |  | No |
| requiredUpdate | [requiredUpdate](#requiredupdate) |  | No |

#### alert

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| message | string |  | No |
| blocking | boolean |  | No |

#### optionalUpdate

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| optionalVersion | string |  | No |
| message | string |  | No |

#### requiredUpdate

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| minimumVersion | string |  | No |
| message | string |  | No |

#### Request[String]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | string |  | Yes |

#### Request[Int64]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | long |  | Yes |

#### Request[MESSAGE]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | [MESSAGE](#message) |  | Yes |

#### MESSAGE

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | long |  | Yes |
| type | integer |  | Yes |
| active | boolean |  | No |
| urgent | boolean |  | No |
| istargeted | boolean |  | No |
| title | string |  | Yes |
| body | string |  | No |
| link | string |  | No |
| image | string |  | No |
| startdate | dateTime |  | Yes |
| enddate | dateTime |  | Yes |
| created | dateTime |  | Yes |
| modified | dateTime |  | Yes |

#### Request[TargetRequest]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | [TargetRequest](#targetrequest) |  | Yes |

#### TargetRequest

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| uids | [ string ] |  | Yes |
| messageId | long |  | Yes |
