# GGPWD_API // A secure password hasher #
> [!NOTE]
> This repository is an attempt for me to learn ASP.NET and .NET 9 as I rebuild the wheel. Not a product for a final client 

The idea behind this API is to create an endpoint whose sole purpose is to generate hashes given an input password.
This could be expanded with a lot more funcionality.
A use case for this API is a password manager. The logic for securing the password is outside of the final software, enhancing the security. 

## Method available out of the box ##
**GET**/PasswordItem

**Input values**
`
"username":string
"passowrd":string  
`
```
curl -X 'GET' 'https://localhost:7015/PasswordItem?username=username&plainText=plainText' -H 'accept: text/plain'
```

<br/>

**POST**/PasswordItem

**Input values**
`
{
  "username": "string",
  "password": "string"
}
`

```
curl -X 'POST' 'https://localhost:7015/PasswordItem' -H 'accept: */*' -H 'Content-Type: application/json' -d '{
  "username": "string",
  "password": "string"
}''
```
<br/>
