# Facebook Chat Bot Application
----
## Requirement
- [NodeJS 10.16.3](https://nodejs.org/download/release/v10.16.3/)
- [ngrok](https://ngrok.com/download)

## Running Instruction
<!-- ```bash
cd original-coast-clothing
```
Setup in .env with 4 fields:
- PAGE_ID
- APP_ID
- PAGE_ACCESS_TOKEN
- APP_SECRET
- **VERIFY_TOKEN** (This is required to ensure your webhook is authentic and working)
```bash
node app.js
``` -->
<!-- *Application can now be accessed at http://localhost:3000* -->

```bash
cd webhook-server
node index.js
```

**Now we need to make application accessible from Internet**
```bash
cd ..
./ngrok authtoken [your_authtoken]
node ./webhook-server   # Run webhook server on 1337 port
# Get your authtoken at https://dashboard.ngrok.com/get-started/setup (need to sign in)
./ngrok http 1337 # Tunnel with port 1337
```
Read the Forwarding IP (with https protocol) => Add setup webhook url with random string VERIFY_TOKEN.
