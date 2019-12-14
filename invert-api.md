# Invert API
### /api/LoginMessage/all

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/LoginMessage/update

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

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /api/Messages/select

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
| data | string |  | No |

#### Request[Int64]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | long |  | No |

#### Request[MESSAGE]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | [MESSAGE](#message) |  | No |

#### MESSAGE

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| id | long |  | No |
| type | integer |  | No |
| active | boolean |  | No |
| urgent | boolean |  | No |
| istargeted | boolean |  | No |
| title | string |  | No |
| body | string |  | No |
| link | string |  | No |
| image | string |  | No |
| startdate | dateTime |  | No |
| enddate | dateTime |  | No |
| created | dateTime |  | No |
| modified | dateTime |  | No |

#### Request[TargetRequest]

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| deviceID | string |  | No |
| deviceName | string |  | No |
| osVersion | string |  | No |
| appVersion | string |  | No |
| platform | string |  | No |
| data | [TargetRequest](#targetrequest) |  | No |

#### TargetRequest

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| uids | [ string ] |  | No |
| messageId | long |  | No |