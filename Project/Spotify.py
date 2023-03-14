
# import requests
# from urllib.parse import urlencode
# import base64
# import webbrowser
# import json


# method = 'POST'
# client_id = "749f4b7f939340f2b6a7be4f865d6864"
# client_secret = "c1eae3c5f96246ed93589feb9784d31f"

# auth_headers = {
#     "client_id": client_id,
#     "response_type": "code",
#     "redirect_uri": "http://localhost:5001/callback",
#     "scope": "user-library-read"
# }

# # webbrowser.open("https://accounts.spotify.com/authorize?" + urlencode(auth_headers))

# code = "AQCT5VqFbkYlr4A4nTo7u0Y1uixd0So0LhpkAvrK9xdW4yypX2zSJleQvGQUT35xR2fNJevMU_D_zUXmrQJuqGJyDRwL40iGUZ4A5Q2oLgCBM_1VXahfTpnhq8q-gVJ_yvUy901ccggsr7pQWw0tLtaq4ymIkpjrO71V2pYi3rtAVLsUJSBG8TQMj1z12lR5vMiqsts"

# encoded_credentials = base64.b64encode(client_id.encode() + b':' + client_secret.encode()).decode("utf-8")

# token_headers = {
#     "Authorization": "Basic " + encoded_credentials,
#     "Content-Type": "application/x-www-form-urlencoded"
# }

# token_data = {
#     "grant_type": "authorization_code",
#     "code": code,
#     "redirect_uri": "http://localhost:5001/callback"
# }

# w =requests.post("https://accounts.spotify.com/api/token", data=token_data, headers=token_headers)


# token = w.json()["BQCMe7eVpbg1CpqGYfqqz70jbRG_ywgmrxEVCbGC2vgjk_JSHM36W5n3_X0__2Q9HT50V7bwhSH-HOOldHKsEMGBU_6r80MGIf-lnVXAiJ7lbn4HbnU9q9GwldYTfimyVHcwKhXHS9zwAgWLa30j8JTzvzzjZO1tFQ_lhH6PxfCU0ga2kTXO9XxuK9a6-aGy"]

# print(token)

# users_token = 'BQCMe7eVpbg1CpqGYfqqz70jbRG_ywgmrxEVCbGC2vgjk_JSHM36W5n3_X0__2Q9HT50V7bwhSH-HOOldHKsEMGBU_6r80MGIf-lnVXAiJ7lbn4HbnU9q9GwldYTfimyVHcwKhXHS9zwAgWLa30j8JTzvzzjZO1tFQ_lhH6PxfCU0ga2kTXO9XxuK9a6-aGy'

# user = {
#     "Authorization": "Bearer " + users_token,
#     "Content-Type": "application/json"
# }
# users_par ={
#     'limit':10
# }
# users_libary_call = requests.get("https://api.spotify.com/v1/me/top/{tracks}")

# print(users_libary_call.json())