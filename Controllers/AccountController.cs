using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_vinnik.Models;

namespace wt_lab4_4mvc_vinnik.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<Account> Accounts = new()
        {
            new Account
            {
                Id = 1,
                Owner = "Иван Иванов",
                AccountNumber = "BY001",
                Balance = 2500,
                AccountType = "Сберегательный",
                IsActive = true
            },
            new Account
            {
                Id = 2,
                Owner = "Анна Петрова",
                AccountNumber = "BY002",
                Balance = 5000,
                AccountType = "Кредитный",
                IsActive = true
            },
            new Account
            {
                Id = 3,
                Owner = "Петр Сидоров",
                AccountNumber = "BY003",
                Balance = 1200,
                AccountType = "Сберегательный",
                IsActive = false
            },
            new Account
            {
                Id = 4,
                Owner = "Мария Козлова",
                AccountNumber = "BY004",
                Balance = 7800,
                AccountType = "Сберегательный",
                IsActive = true
            },
            new Account
            {
                Id = 5,
                Owner = "Алексей Смирнов",
                AccountNumber = "BY005",
                Balance = 3500,
                AccountType = "Кредитный",
                IsActive = true
            }
        };

        public IActionResult Index()
        {
            return View(Accounts);
        }

        public IActionResult Details(int id)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
        
[HttpGet]
public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Account account)
{
    if (!ModelState.IsValid)
    {
        return View(account);
    }

    account.Id = Accounts.Max(a => a.Id) + 1;

    Accounts.Add(account);

    return RedirectToAction("Index");
}


[HttpGet]
public IActionResult Edit(int id)
{
    var account = Accounts.FirstOrDefault(a => a.Id == id);

    if (account == null)
    {
        return NotFound();
    }

    return View(account);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Account updatedAccount)
{
    if (id != updatedAccount.Id)
    {
        return BadRequest();
    }

    if (!ModelState.IsValid)
    {
        return View(updatedAccount);
    }

    var account = Accounts.FirstOrDefault(a => a.Id == id);

    if (account == null)
    {
        return NotFound();
    }

    account.Owner = updatedAccount.Owner;
    account.AccountNumber = updatedAccount.AccountNumber;
    account.Balance = updatedAccount.Balance;
    account.AccountType = updatedAccount.AccountType;
    account.IsActive = updatedAccount.IsActive;

    return RedirectToAction("Index");
}

    }
}
