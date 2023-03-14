# Anthony Helped

class BankAccount(object):

    instances = []

    def __init__(self, int_rate, balance):
        self.int_rate = int_rate
        self.balance = balance
        BankAccount.instances.append(self)

    def deposit(self, amount):
        self.balance += amount
        return self

    def withdraw(self, amount):
        if (self.balance >= amount) > 0:
            self.balance -= amount
        else:
            print(f"broke {self.balance}")
            return self

    def display_account_info(self):
        print(f"${self.balance}")
        return self

    def yield_interest(self):
        if self.balance > 0:
            self.balance += (self.balance * self.int_rate)
        else:
            print("oof Negative")
        return self

    @classmethod
    def print_instances(cls):
        for x in cls.instances:
            x.display_account_info()


class User:

    def __init__(self, Name, Email):
        self.Name = Name
        self.Email = Email
        self.account = BankAccount(int_rate=.01, balance=100)

    def make_deposit(self, amount):
        self.account.deposit(amount)
        return self

    def make_withdraw(self, amount):
        if (self.balance >= amount) > 0:
            self.balance -= amount
        else:
            print(f"broke {self.balance}")
            return self

    def display_user_balance(self):
        print(f"hello {self.Name}, your Spending balance is")
        self.account.display_account_info()
        
        return self




devin = User("Devin", "None")

devin.make_deposit(10).make_deposit(10).make_deposit(10).display_user_balance()
