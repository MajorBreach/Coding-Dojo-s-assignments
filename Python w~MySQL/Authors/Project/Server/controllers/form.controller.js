const author = require('../models/form.model');

module.exports.findAll = (req, res) => {
    author.find()
        .then((allauthors) => {
            res.json({ author: allauthors })
        })
        .catch((err) => {
            res.status(400).json({ message: 'Something went wrong', error: err })
        });
},

module.exports.create = (req, res) => {
    author.create(req.body)
        .then((newauthor) => {
            res.json({ newauthor })
        })
        .catch((err) => {
            res.status(400).json({ message: 'Something went wrong', error: err })
        });
    },

module.exports.findOne = (req, res) =>{
    console.log(req.params.id)
    author.findOne(
        {_id:req.params.id}
    )
    .then((author) =>res.json({author}))

    .catch((err) => {
        res.status(400).json({ message: 'Something went wrong', error: err })
    });
},

module.exports.update = (req, res) => {
    author.findOneAndUpdate(
        { _id: req.params.id },
        req.body,
        { new: true, runValidators: true }
    )
        .then((updatedauthor) => {
            res.json({ updatedauthor })
        })
        .catch((err) => {
            res.status(400).json({ message: 'Something went wrong', error: err })
        });
},


module.exports.delete = (req, res) => {
    console.log(req.params.id)
    author.deleteOne({ _id: req.params.id })
        .then((author) => {
            res.json({ author })
        })
        .catch((err) => {
            res.status(400).json({ message: 'Something went wrong', error: err })
        });
};