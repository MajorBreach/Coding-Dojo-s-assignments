from flask import render_template,redirect,session,request, flash
from flask_app import app
from flask_app.models.sightings_mod import Sighting
from flask_app.models.User import User




@app.route('/new/sighting')
def sighting():
    if 'reg_id' not in session:
        return redirect('/logout')
    data ={
        'reg_id':session['reg_id']
    }
    main_data ={
        "id":session['reg_id']
    }
    main_user = User.get_by_id(main_data)
    return render_template('Add.html', user = User.get_by_id(data) ,main_user = main_user)


@app.route('/create/sighting' ,  methods=["post"])
def create():
    if 'reg_id' not in session:
        return redirect('/logout')
    print(request.form)
    if not Sighting.validate(request.form):
        return redirect('/new/sighting')
    
    sighting_data = {
        **request.form,
        'reg_id' : session['reg_id']
    }
    Sighting.create(sighting_data)
    
    return redirect('/dashboard')

@app.route('/show/<int:id>')
def show_one(id):
    if 'reg_id' not in session:
        return redirect('/logout')
    sighting_data = {
        'id' : id
    }
    reg_data = {
        "id":session['reg_id']
    }
    this_user = User.get_by_id(reg_data)
    this_sighting =Sighting.get_by_id(sighting_data)
    return render_template('show.html', this_sighting = this_sighting , this_user=this_user)


@app.route('/edit/<int:id>')
def edit(id):
    if 'reg_id' not in session:
        return redirect('/logout')
    this_sighting = Sighting.get_by_id({'id':id})
    return render_template('edit.html', this_sighting = this_sighting)

@app.route('/update/<int:id>' , methods = ['post'])
def update(id):
    if 'reg_id' not in session:
        return redirect('/logout')
    if not Sighting.validate(request.form):
        return redirect(f"/recipe/{id}/edit")
    
    update_data = {
        **request.form,
        'id' : id
    }
    Sighting.update(update_data)
    
    return redirect('/dashboard')
    
@app.route('/delete/<int:id>')
def delete(id):
    if 'reg_id' not in session:
        return redirect('/logout')
    Sighting.pwn({'id' : id})
    return redirect('/dashboard')