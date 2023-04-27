const mongoose = require('mongoose');

const AuthorSchema = new mongoose.Schema(
    {
        name: {
            type: String,
            required: [true, 'Author name is required'],
            minLength: [2, 'Author name must be at least 2 characters'],
        },
    });
const author = mongoose.model('author', AuthorSchema);

module.exports = author;