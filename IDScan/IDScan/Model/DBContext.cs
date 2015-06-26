﻿namespace IDScan.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class MembershipIDScanEntities : DbContext
    {
        public MembershipIDScanEntities()
            : base("name=MembershipIDScanEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<club> clubs { get; set; }
        public DbSet<@event> events { get; set; }
        public DbSet<memberattendance> memberattendances { get; set; }
        public DbSet<membership> memberships { get; set; }
        public DbSet<picklist> picklists { get; set; }
        public DbSet<scantag> scantags { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<scandata> scandatas { get; set; }
        //public DbSet<SessionData> sessindata { get; set; }
    }
}
