
from flask_app import app
from flask_app.controllers import register , sighting_con



if __name__ == "__main__":
    app.run(debug=True, port=5001)