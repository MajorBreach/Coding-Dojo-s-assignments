const JokesController = require('../controllers/jokes.controller');

module.exports = (app) => {
    app.get('/api/Joke', JokesController.getjoke);
    app.post('/api/Jokes', JokesController.createjoke);
    app.get('/api/animals/:id', JokesController.getOnejoke);
    app.put('/api/animals/:id', JokesController.updateOnejoke);
    app.delete('/api/animals/:id', JokesController.deleteOnejoke);
};