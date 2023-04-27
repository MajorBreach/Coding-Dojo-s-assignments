const mongoose = require('mongoose');

const JokesSchema = new mongoose.Schema(
    {
        Joke: {
            type: String,
            required: [true, 'Joke name is required'],
            minLength: [2, 'Joke name must be at least 2 characters'],
        },
    },
    { timestamps: true }
);

const Jokes = mongoose.model('Joke', JokesSchema);

module.exports = Jokes;