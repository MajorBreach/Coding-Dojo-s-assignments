const Jokes = require('../models/jokes.model');

module.exports = {
    getjoke: (req, res) => {
        Jokes.find()
            .then((jokes) => {
                res.json({ alljokes: jokes });
            })
            .catch((err) =>
                res.json({ message: 'Try again.', error: err })
            );
    },

    createjoke: (req, res) => {

        Jokes.create(req.body)
            .then((Createdjoke) => {
                res.json({ newjoke: Createdjoke });
            })
            .catch((err) =>
                res.json({ message: 'Try again', error: err })
            );
    },
    
    getOneJoke: (req, res) => {
        Jokes.findOne({ _id: req.params.id })
            .then((onejoke) => {
                res.json({ getOnejoke : onejoke });
            })
            .catch((err) =>
                res.json({ message: 'try again.', error: err })
            );
    },

    updateOnejoke: (req, res) => {
        Jokes.findOneAndUpdate({ _id: req.params.id }, req.body, {
            new: true,
            runValidators: true,
        })
            .then((updatedjoke) => {
                res.json({ updatejoke: updatedjoke });
            })
            .catch((err) =>
                res.json({ message: 'try again.', error: err })
            );
    },
    deleteOnejoke: (req, res) => {
        Jokes.deleteOne({ _id: req.params.id })
            .then((result) => {
                res.json({ result });
            })
            .catch((err) =>
                res.json({ message: 'try again.', error: err })
            );
    },
};
