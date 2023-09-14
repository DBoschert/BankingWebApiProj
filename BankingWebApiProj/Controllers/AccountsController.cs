using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingWebApi.Models;
using BankingWebApiProj.Data;
using BankingWebApiProj.Models;

namespace BankingWebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly BankingWebApiProjContext _context;

        public AccountsController(BankingWebApiProjContext context)
        {
            _context = context;
        }
        
        // Show Transactions

        // GET: api/Accounts/Transactions/{id}
        [HttpGet("transactions/{id}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int id)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            var transactions = await _context.Transactions.Where(x => x.AccountId == id).ToListAsync();
            return transactions;
        }
        
        // GET: api/Accounts/Balance/{id}
        [HttpGet("balance/{id}")]
        public async Task<ActionResult<decimal>> GetBalance(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if(account == null)
            {
                return NotFound();
            }
            return account.Balance;
        }


        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        //transfer withdraw from one account and make that withdrawed amount go into another account
        
        // PUT: api/Accounts/Transfer/{amount}/{id1}/{id2}

        [HttpPut("transfer/{amount}/{id1}/{id2}")]
        public async Task<IActionResult> Transfer(decimal amount, int id1, int id2, Account account)
        {
            var account1 = await _context.Accounts.FindAsync(id1);
            var account2 = await _context.Accounts.FindAsync(id2);
            if (account1 == null || account2 == null)
            {
                return NotFound();
            }

            account1.Balance -= amount;
            
            account2.Balance += amount;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        

        // PUT: api/Accounts/Deposit/{amount}
        [HttpPut("deposit/{amount}/{id}")]
        public async Task<IActionResult> Deposit(decimal amount, int id, Account account)
        {
            account.Balance += amount;
            return await PutAccount(id, account);
        }

        //PUT: api/Accounts/Withdraw/{amount}
        [HttpPut("withdraw/{amount}/{id}")]
        public async Task<IActionResult> Withdraw(decimal amount, int id, Account account)
        {
            account.Balance -= amount;
            return await PutAccount(id, account);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
          if (_context.Accounts == null)
          {
              return Problem("Entity set 'BankingWebApiProjContext.Account'  is null.");
          }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
