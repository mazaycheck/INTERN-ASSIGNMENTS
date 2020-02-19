using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            IBank<Account> bank1 = new Bank<Account>();
            IBank<Account> bank2 = new Bank<DepositAccount>();
            Account acc1 = bank1.CreateAccount();
            Account acc2 = bank2.CreateAccount();
        }



        public class Account
        {
            public virtual void TransferMoney(int money) { Console.WriteLine($"Transfered {money}"); }
        }

        public class DepositAccount : Account
        {
            public override void TransferMoney(int money) { Console.WriteLine($"Transfered in deposit {money}"); }
        }

        //public interface IBank<T>
        public interface IBank<out T>
        {
            T CreateAccount();
            //void TransferMoneyTo(T account);
        }

        public class Bank<T> : IBank<T> where T : Account, new()
        {
            public T CreateAccount()
            {
                T acc = new T();
                acc.TransferMoney(1000);
                return acc;
            }
        }



    }
}
