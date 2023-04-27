require('dotenv').config();
const express = require('express');
const app = express();
const port = 8000;
require('./config/mongoose.config');
const cors = require('cors')
app.use(cors())

app.use(express.json(), express.urlencoded({ extended: true }));
const routes = require('./routes/form.routes');
routes(app);
    
app.listen(port, () => console.log(`Listening on port: ${port}`) );