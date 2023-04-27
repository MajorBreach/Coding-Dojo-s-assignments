class BankAccount():

    instances = []

    def __init__(self, int_rate, balance = 0):
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
        print(self.balance)
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
            print(x.display_account_info())


Checking = BankAccount(.02, 200)
Savings = BankAccount(0.01,1000)

BankAccount.print_instances()

Checking.deposit(100).deposit(100).deposit(100).withdraw(200)


