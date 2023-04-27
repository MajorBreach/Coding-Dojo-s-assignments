# # Basic 0-150
# for x in range (150+1):
#     print(x)
    
# # Print all the multiples of 5 from 5 to 1,000
# for x in range(5, 1000+5 , 5):
#     print(x)

# Print integers 1 to 100. If divisible by 5, print "Coding" instead. If divisible by 10, print "Coding Dojo".

# for x in range(1,101,1):
#     print(x)
#     if x % 5 == 0:
#         print("coding")
#     if x % 10 == 0:
#         print('dojo')

# Whoa. That Sucker's Huge - Add odd integers from 0 to 500,000, and print the final sum.

# min = 0
# max = 500000
# Odd = 0

# for num in range(min, max):
#     print(num)
#     if(num % 2 != 0 ):
#         print(num)
#         Odd = Odd + num
#         print((min,max,Odd))


# Countdown by Fours - Print positive numbers starting at 2018, counting down by fours

for i in range(2018 , 2 , -4):
    print(i)