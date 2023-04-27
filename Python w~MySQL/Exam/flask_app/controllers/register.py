from flask_app import app
from flask import render_template, redirect, request, session
from flask_app.models.User import User
from flask_bcrypt import Bcrypt        
bcrypt = Bcrypt(app)   
from flask import flash

@app.route("/")
def index():
    return render_template('home.html')




@app.route("/users/register" , methods = ['POST'])
def register():
    print(request.form)
    if not User.validate(request.form):
        return redirect("/")
    
    
    pw_hash = bcrypt.generate_password_hash(request.form['password'])
    
    data = {
        **request.form,
        'password' : pw_hash
    }
    
    user_id = User.new(data)
    session['user_id'] = user_id
    
    return redirect("/dashboard")






@app.route('/users/login', methods = ['post'])
def login():
    data = {
        "email": request.form['email']
        
    }
    registered_user = User.get_by_email(data)
    
    if not registered_user:
        flash('Your not in the system!')
        return redirect('/')
    
    if not bcrypt.check_password_hash(registered_user.password, request.form['password']):
        flash("Invalid Email/Password")
        return redirect('/')
    
    session['user_id'] = registered_user.id
    return redirect('/dashboard')

@app.route("/dashboard")
def welcome():
    data = {
        'id' : session['user_id']
    }
    users = User.get_by_id(data)
    
    return render_template("profile.html" , users = users)


@app.route('/logout')
def logout():
    session.clear
    return redirect('/')
