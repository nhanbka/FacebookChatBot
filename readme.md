# Facebook Chat Bot Application
----
## Requirement
- [NodeJS 10.16.3](https://nodejs.org/download/release/v10.16.3/)
- [ngrok](https://ngrok.com/download)

## Dependencies
### 1. webhook-server
- socket.io
- nodemon
- express
- mysql
- nconf
- uuid
- request
```bash
npm install --save socket.io
npm install --save nodemon
npm install --save express
npm install --save mysql
npm install --save nconf
npm install --save uuid
npm install --save request
```
### 2. io_server
- socket.io
- nodemon
- express
```bash
npm install --save socket.io
npm install --save nodemon
npm install --save express
```
### 3. ManagerChatBox
- [SocketIOClient](https://github.com/doghappy/socket.io-client-csharp)
- [NewtonSoft.Json](https://www.newtonsoft.com/json)

## Running Instruction

```bash
cd webhook-server
npm run start
```

**Now we need to make application accessible from Internet**
```bash
cd ..
./ngrok authtoken [your_authtoken]
# Get your authtoken at https://dashboard.ngrok.com/get-started/setup (need to sign in)
./ngrok http 1337 # Tunnel with port 1337
```
Read the Forwarding IP (with https protocol) => Add setup webhook url with random string VERIFY_TOKEN.

**Enable socket.io server**
```bash
cd io_server
npm run start
```