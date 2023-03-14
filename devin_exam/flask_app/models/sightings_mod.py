from flask_app.config.mysql import connectToMySQL
from flask import flash
from flask_app import DATABASE
from flask_app.models import User




class Sighting:
    def __init__(self, data):
        self.id = data['id']
        self.name = data['name']
        self.description = data['description']
        self.under = data['under']
        self.date = data['date']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        self.reg_id = data['reg_id']


        
        
        
        
    @classmethod
    def create(cls, data):
        query = """INSERT INTO sightings (name, under, description, date, reg_id) 
        VALUES (%(name)s,%(under)s,%(description)s,%(date)s,%(reg_id)s);"""
        return connectToMySQL(DATABASE).query_db(query, data)
    

    @classmethod
    def get_all(cls):
        query = """
        Select * from sightings
        join register
        on register.id = sightings.reg_id;
        """
        results = connectToMySQL(DATABASE).query_db(query)
        print(results)
        all_sighting = []
        if results:
            for row in results:
                this_sighting = cls(row)
                user_data = {
                    **row,
                    'reg_id':row['reg_id'],
                    'created_at':row['register.created_at'],
                    'updated_at':row['register.updated_at'],
                    
                }
                this_user = User.User(user_data)
                this_sighting.host = this_user
                all_sighting.append(this_sighting)
        return all_sighting
    

    @classmethod
    def get_by_id(cls, data):
        query  = """
            select * from sightings
            join register
            on register.id = sightings.reg_id
            where sightings.id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query , data)
        print(results)
        this_sighting = cls(results[0])
        row = results[0]
        reg_data ={
            **row,
            'reg_id' : row['reg_id'],
            'created_at' : row['register.created_at'],
            'created_at' : row['register.updated_at']
        }
        this_user = User.User(reg_data)
        this_sighting.host = this_user
        return this_sighting
        
        return False
        
        
        
    @classmethod
    def update(cls, data):
        query = "UPDATE sightings SET name=%(name)s, description=%(description)s, under=%(under)s, date=%(date)s WHERE id = %(id)s;"
        return connectToMySQL(DATABASE).query_db(query, data)

    @classmethod
    def pwn(cls,data):
        query = "DELETE FROM sightings WHERE id = %(id)s;"
        return connectToMySQL(DATABASE).query_db(query, data)


    @staticmethod
    def validate(form_data):
        is_valid = True
        if len(form_data['name']) < 3:
            is_valid = False
            flash("Name to short")
        if len(form_data['description']) < 3:
            is_valid = False
            flash("Description To short")
        if  form_data['date'] == "":
            is_valid = False
            flash("Try again, Enter a date!")
        if  form_data['under'] <= "0":
            is_valid = False
            flash('Sightings must be greater than 0!')
        return is_valid