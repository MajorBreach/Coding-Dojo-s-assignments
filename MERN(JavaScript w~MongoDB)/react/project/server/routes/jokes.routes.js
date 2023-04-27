const JokesController = require('../controllers/jokes.controller');

module.exports = (app) => {
    app.get('/api/Joke', JokesController.getjoke);
    app.post('/api/Jokes', JokesController.createjoke);
    app.get('/api/Jokes/:id', JokesController.getOnejoke);
    app.put('/api/Jokes/:id', JokesController.updateOnejoke);
    app.delete('/api/Jokes/:id', JokesController.deleteOnejoke);
};