const Controller = require('../controllers/form.controller');

module.exports = (app) =>{
    app.get('/api/author', Controller.findAll);
    app.post('/api/author', Controller.create);
    app.get('/api/author/:id', Controller.findOne);
    app.put('/api/author/:id', Controller.update);
    app.delete('/api/author/:id', Controller.delete);
};