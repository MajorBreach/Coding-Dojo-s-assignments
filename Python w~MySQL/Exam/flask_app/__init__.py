from flask import Flask
app = Flask(__name__)
app.secret_key = 'Not today'
DATABASE = 'log_reg'