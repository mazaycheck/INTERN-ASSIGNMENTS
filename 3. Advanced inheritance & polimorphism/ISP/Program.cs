using System;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BankAccount acc1 = new ParentAccount(1000);
        }
    }

    public interface IBankAccount
    {
        public void withdrawMoney(int money);
        public void depositMoney(int money);
        public void activateAccount();
        public void closeAccount();        
    }

    public abstract class BankAccount 
    {
        public int Balance { get; protected set; }
        public bool Active { get; protected set; }

        public BankAccount(int initBalance)
        {
            Balance = initBalance;                        
        }        
    }

    public class ParentAccount : BankAccount, IBankAccount
    {
        public ParentAccount(int initbalance) : base(initbalance) { }
        public void activateAccount()
        {
            Active = true;
        }

        public void closeAccount()
        {
            Active = false;
        }

        public void depositMoney(int money)
        {
            if (Active) Balance += money;
        }

        public void withdrawMoney(int money)
        {
            if (Active) Balance -= money;
        }
    }

    public class KidAccount : BankAccount, IBankAccount
    {

        public KidAccount(int initbalance) : base(initbalance) { }
        public void activateAccount()
        {
            throw new NotImplementedException();
        }

        public void closeAccount()
        {
            throw new NotImplementedException();
        }

        public void depositMoney(int money)
        {
            if (Active) Balance += money;
        }

        public void withdrawMoney(int money)
        {
            if (Active) Balance -= money;
        }
    }


    public interface IControlBalanceBankAccout
    {
        public void withdrawMoney(int money);
        public void depositMoney(int money);
    }

    public interface IManageBankAccount
    {
        public void activateAccount();
        public void closeAccount();
    }

    public class KidAccountISP : BankAccount, IControlBalanceBankAccout
    {
        public KidAccountISP(int initBalance) : base(initBalance)
        {

        }

        public void depositMoney(int money)
        {
            if (Active) Balance += money;
        }

        public void withdrawMoney(int money)
        {
            if (Active) Balance -= money;
        }
    }

    public class ParentAccountISP : BankAccount, IControlBalanceBankAccout, IManageBankAccount
    {
        public ParentAccountISP(int initBalance) : base(initBalance)
        {

        }

        public void activateAccount()
        {
            Active = true;
        }

        public void closeAccount()
        {
            Active = false;
        }

        public void depositMoney(int money)
        {
            if (Active) Balance += money;
        }

        public void withdrawMoney(int money)
        {
            if (Active) Balance -= money;
        }
    }




}
