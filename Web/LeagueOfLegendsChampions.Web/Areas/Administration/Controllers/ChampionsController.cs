namespace LeagueOfLegendsChampions.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LeagueOfLegendsChampions.Data;
    using LeagueOfLegendsChampions.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ChampionsController : AdministrationController
    {
        private readonly ApplicationDbContext db;

        public ChampionsController(ApplicationDbContext context)
        {
            this.db = context;
        }

        // GET: Administration/Champions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.db.Champions.Include(c => c.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Champions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var champion = await this.db.Champions
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champion == null)
            {
                return this.NotFound();
            }

            return this.View(champion);
        }

        // GET: Administration/Champions/Create
        public IActionResult Create()
        {
            this.ViewData["UserId"] = new SelectList(this.db.Users, "Id", "Id");
            return this.View();
        }

        // POST: Administration/Champions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageIconUrl,ImageFullSizeUrl,Nickname,Name,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Champion champion)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Add(champion);
                await this.db.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["UserId"] = new SelectList(this.db.Users, "Id", "Id", champion.UserId);
            return this.View(champion);
        }

        // GET: Administration/Champions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var champion = await this.db.Champions.FindAsync(id);
            if (champion == null)
            {
                return this.NotFound();
            }

            this.ViewData["UserId"] = new SelectList(this.db.Users, "Id", "Id", champion.UserId);
            return this.View(champion);
        }

        // POST: Administration/Champions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ImageIconUrl,ImageFullSizeUrl,Nickname,Name,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Champion champion)
        {
            if (id != champion.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.db.Update(champion);
                    await this.db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ChampionExists(champion.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["UserId"] = new SelectList(this.db.Users, "Id", "Id", champion.UserId);
            return this.View(champion);
        }

        // GET: Administration/Champions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var champion = await this.db.Champions
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champion == null)
            {
                return this.NotFound();
            }

            return this.View(champion);
        }

        // POST: Administration/Champions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var champion = await this.db.Champions.FindAsync(id);
            this.db.Champions.Remove(champion);
            await this.db.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ChampionExists(string id)
        {
            return this.db.Champions.Any(e => e.Id == id);
        }
    }
}
