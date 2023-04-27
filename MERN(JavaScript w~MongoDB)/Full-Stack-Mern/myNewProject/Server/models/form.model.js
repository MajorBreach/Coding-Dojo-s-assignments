const mongoose = require('mongoose');

const Cluster = new mongoose.Schema(
    {
        Title: {
            type: String,
            required: [true, 'Title name is required'],
            minLength: [2, 'Species name must be at least 2 characters'],
        },
        Price: {
            type: Number,
            required: [true, 'Number is required'],
            min: [0, 'Number must be greater than 0'],
        },
        Description: {
            type: String,
            required: [true, 'Description is required'],
            minLength: [2, 'Description must be at least 2 characters'],
        }
    });
const Form = mongoose.model('Form', Cluster);

module.exports = Form;