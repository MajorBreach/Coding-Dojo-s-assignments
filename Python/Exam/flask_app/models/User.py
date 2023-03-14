from flask_app.config.mysql import connectToMySQL
from flask_app import DATABASE
from flask import flash
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$') 



class User:
    def __init__(self , data):
        self.id = data['id']
        self.first_name = data['first_name']
        self.last_name = data['last_name']
        self.email = data['email']
        self.password = data['password']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']
        
        
    @classmethod
    def new(cls, data):
        query = """
            INSERT INTO register (first_name , last_name , email , password)
            VALUES (%(first_name)s , %(last_name)s , %(email)s , %(password)s);
        """
        return connectToMySQL(DATABASE).query_db(query, data)
    
    @classmethod
    def get_by_id(cls, data):
        query  = """
        select * from register
        where id = %(id)s;
        """
        results = connectToMySQL(DATABASE).query_db(query , data)
        if not results:
            return False
        return results[0]
    
    @classmethod
    def get_by_email(cls, data):
        query = """
        SELECT * From register
        WHERE register.email = %(email)s;
        
        """
        results = connectToMySQL(DATABASE).query_db(query , data)
        print(results)
        if len(results) <1:
            return False
        
        return cls(results[0])
    
    
    
    
    @staticmethod 
    def validate(data):
            is_valid = True
            
            if len(data['first_name']) < 1:
                is_valid = False
                flash("first name needed")

            if len(data['last_name']) < 1:
                is_valid = False
                flash("last name needed")

            if len(data['email']) < 1:
                is_valid = False
                flash("email needed")
            elif not EMAIL_REGEX.match(data['email']):
                flash("Invalid email address!")
                is_valid = False
                
            if len(data['password']) < 1:
                is_valid = False
                flash("password needed")
            elif not data['password'] == data['confirm_password']:
                is_valid = False
                flash("Bruh passwords aren't the same!")

            return is_valid