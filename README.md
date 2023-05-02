
# Smart Alert Api

This is the backend API and it was developed using C#.NET 6 with Identity and Entity Framework Core for authenticating users and managing data. It uses a SQLite database to store reports and integrates geolocation coordinates from the Android Location API to provide accurate location data. The API acts as an interface between the Android app, website, and database, enabling efficient communication and streamlined data management.


## Features

- REST api
- Authentication
- Authorization
- Database connection


## API Reference

### Auth

<details><summary>Register</summary>
<p>

```http
  GET /auth/register
```

| Parameter |
| :-------- |
| none      |

| Body      | Type |
| :-------- |:---- |
| yes       |`json`|

Example 

```json
{
  "email": "string",
  "phone": "string",
  "password": "string"
}
```
</p>
</details>

<details><summary>Login</summary>
<p>

```http
  POST /auth/login
```

| Parameter |
| :-------- |
| none      |

| Body      | Type |
| :-------- |:---- |
| yes       |`json`|

Example 

```json
{
  "email": "string",
  "password": "string"
}
```
</p>
</details>

<details><summary>Logout</summary>
<p>

```http
  POST /auth/logout
```

| Parameter |
| :-------- |
| none      |

| Body      | Type |
| :-------- |:---- |
| yes       |`json`|

Example 

```json
{
  "email": "string",
}
```
</p>
</details>

<br />

### Events

<details><summary>All</summary>
<p>

```http
  GET /events/all
```

| Parameter |
| :-------- |
| none      |

| Body      |
| :-------- |
| none      |
</p>
</details>

<details><summary>Event</summary>
<p>

```http
  GET /events/{id}
```

| Parameter |  Type  | Required |
| :-------- |:------ |:---------|
| `id`      |`string`|  yes     |

| Body      |
| :-------- |
| none      |
</p>
</details>

<details><summary>Delete</summary>
<p>

```http
  DELETE /events/{id}
```

| Parameter |  Type  | Required |
| :-------- |:------ |:---------|
| `id`      |`string`|  yes     |

| Body      |
| :-------- |
| none      |
</p>
</details>

<details><summary>Important</summary>
<p>

```http
  GET /events/important
```

| Parameter |
| :-------- |
| none      |

| Body      |
| :-------- |
| none      |
</p>
</details>

<details><summary>Stats</summary>
<p>

```http
  GET /events/stats
```

| Parameter |
| :-------- |
| none      |

| Body      |
| :-------- |
| none      |
</p>
</details>

## Authors

- [@0x-2FA](https://www.github.com/0x-2FA)
- [@SophiaNikolia](https://github.com/SophiaNikolia)
- [@spentzaris](https://github.com/spentzaris)



