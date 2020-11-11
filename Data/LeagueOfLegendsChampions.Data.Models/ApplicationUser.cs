// ReSharper disable VirtualMemberCallInConstructor
namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections.Generic;

    using LeagueOfLegendsChampions.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Champions = new HashSet<Champion>();
            this.Builds = new HashSet<Build>();
            this.Items = new HashSet<Item>();
            this.Runes = new HashSet<Rune>();
            this.RuneParts = new HashSet<RunePart>();
            this.SkillsSets = new HashSet<SkillsSet>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Champion> Champions { get; set; }
        public virtual ICollection<Build> Builds { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Rune> Runes { get; set; }
        public virtual ICollection<RunePart> RuneParts { get; set; }
        public virtual ICollection<SkillsSet> SkillsSets { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
