from flask_app import app
from flask import render_template, redirect, request, session
# from flask_bcrypt import Bcrypt        
# bcrypt = Bcrypt(app)   
from flask import flash

@app.route("/")
def index():
    return render_template('home.html')

@app.route("/songs")
def activity():
    return render_template('songs.html')



@app.route('/player')
def player():
    return render_template('player.html')