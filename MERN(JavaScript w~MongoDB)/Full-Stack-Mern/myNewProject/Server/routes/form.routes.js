const FormController = require('../controllers/form.controller');

module.exports = (app) =>{
    app.get('/api/form', FormController.findAllForm);
    app.post('/api/form', FormController.createNewForm);
    app.put('/api/form/:id', FormController.updateExistingForm);
    app.delete('/api/form/:id', FormController.deleteAnExistingForm);
};