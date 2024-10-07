using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BankManagementProject
{
    public class AccountMemoryRepo : IAccountRepo
    {
        private static AccountMemoryRepo _instance;
        public ObservableCollection<AccountModel> accounts = new ObservableCollection<AccountModel>()
        {
            new AccountModel
            {
                AccNo = 1234465553,
                Name = "Anurag",
                Balance = 0,
                AccType = "savings",
                Email = "anurag@gmail.com",
                PhNo = "7894561231",
                Address = "Shanti, street2",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            },
            new AccountModel
            {
                AccNo = 456733543,
                Name = "Sid",
                Balance = 100,
                AccType = "current",
                Email = "Sid@gmail.com",
                PhNo = "4561233345",
                Address = "Pavithram, street1",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            },
            new AccountModel
            {
                AccNo = 456733543,
                Name = "Rahul",
                Balance = 1000,
                AccType = "current",
                Email = "Rahul@gmail.com",
                PhNo = "6791233345",
                Address = "Swasthi, trivandrum",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 456733578,
                Name = "kiran",
                Balance = 250,
                AccType = "savings",
                Email = "kiran@gmail.com",
                PhNo = "7912333456",
                Address = "Ayodhya, trivandrum",
                IsActive = false,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 896733543,
                Name = "Visakh",
                Balance = 500,
                AccType = "savings",
                Email = "visakh@gmail.com",
                PhNo = "7912373345",
                Address = "thiruvonam, trivandrum",
                IsActive = false,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 678733543,
                Name = "Abhishek",
                Balance = 600,
                AccType = "current",
                Email = "Abhishek@gmail.com",
                PhNo = "6701233345",
                Address = "abhibhavan, trivandrum",
                IsActive = false,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 46733553,
                Name = "Gokul",
                Balance = 90,
                AccType = "current",
                Email = "Rahul@gmail.com",
                PhNo = "8191233345",
                Address = "gokulbhavan, trivandrum",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 456733543,
                Name = "Arjun",
                Balance = 10,
                AccType = "savings",
                Email = "arjun@gmail.com",
                PhNo = "9891233345",
                Address = "arjunbhavan, trivandrum",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 956733543,
                Name = "Abin",
                Balance = 5,
                AccType = "current",
                Email = "Abin@gmail.com",
                PhNo = "9791233345",
                Address = "abinmanzil, trivandrum",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            },
            new AccountModel
            {
                AccNo = 856733543,
                Name = "Ashik",
                Balance = 2000,
                AccType = "current",
                Email = "ashik@gmail.com",
                PhNo = "6891233345",
                Address = "mannath, trivandrum",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,
            }
        };

        public ObservableCollection<AccountModel> activeaccounts = new ObservableCollection<AccountModel>();
        public ObservableCollection<AccountModel> inactiveaccounts = new ObservableCollection<AccountModel>();

        public static AccountMemoryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountMemoryRepo();
                }
                return _instance;
            }
        }

        public void Create(AccountModel accModel)
        {
            try
            {
                accounts.Add(accModel);
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error in creating account");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateAccount(AccountModel accModel)
        {
            try
            {
                var existingAccount = accounts.FirstOrDefault(a => a.AccNo == accModel.AccNo);
                if (existingAccount != null)
                {
                    existingAccount.Address = accModel.Address;
                }
                else
                {
                    throw new AccountException("Account doesn't exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ObservableCollection<AccountModel> ReadAllAccount()
        {
            try
            {
                return accounts;
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteAccount(AccountModel accModel)
        {

            try
            {
                foreach (var ac in accounts)
                {
                    if (ac.AccNo == accModel.AccNo)
                    {
                        ac.IsActive = false;
                    }
                }
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deposit(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    account.Balance = account.Balance + Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Withdraw(int acNo, int Amount)
        {
            try
            {
                var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
                if (account != null)
                {
                    if (account.Balance < Amount)
                    {
                        // throw new AccountException("Insufficient balance");
                        var result = MessageBox.Show(messageBoxText: "Insufficient Balance",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Warning);
                        return;
                    }
                    account.Balance = account.Balance - Amount;
                    account.LastTransactionDate = DateTime.Now;
                    account.TransactionCount = account.TransactionCount + 1;

                }
                else
                {
                    throw new AccountException("Account Not Found , Please input valid account number");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<AccountModel> ReadActiveAccount()
        {
            try
            {
                foreach (var ac in accounts)
                {
                    if (ac.IsActive == true)
                    {
                        activeaccounts.Add(ac);
                    }
                }
                return activeaccounts;
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<AccountModel> ReadInactiveAccount()
        {
            try
            {
                foreach (var ac in accounts)
                {
                    if (ac.IsActive == false)
                    {
                        inactiveaccounts.Add(ac);
                    }
                }
                return inactiveaccounts;
            }
            catch (AccountException ae)
            {
                throw new AccountException("Error reading accounts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
