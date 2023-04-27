const Form = require('../models/form.model');

module.exports.findAllForm = (req, res) => {
    Form.find()
        .then((allForms) => {
            res.json({ Form: allForms })
        })
        .catch((err) => {
            res.json({ message: 'Something went wrong', error: err })
        });
},

module.exports.createNewForm = (req, res) => {
    Form.create(req.body)
        .then(newlyCreatedForm => {
            res.json({ Form: newlyCreatedForm })
        })
        .catch((err) => {
            res.json({ message: 'Something went wrong', error: err })
        });
    },


module.exports.updateExistingForm = (req, res) => {
    Form.findOneAndUpdate(
        { _id: req.params.id },
        req.body,
        { new: true, runValidators: false }
    )
        .then(updatedForm => {
            res.json({ Form: updatedForm })
        })
        .catch((err) => {
            res.json({ message: 'Something went wrong', error: err })
        });
},


module.exports.deleteAnExistingForm = (req, res) => {
    Form.deleteOne({ _id: req.params.id })
        .then(result => {
            res.json({ result: result })
        })
        .catch((err) => {
            res.json({ message: 'Something went wrong', error: err })
        });
};