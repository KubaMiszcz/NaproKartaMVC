using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NaproKarta.Models;
using NaproKarta.Models.ObservationModel;
using NaproKarta.Models.UserModel;

namespace NaproKarta.DataAccessLayer
{
   public class NaproKartaDAL:DbContext
   {
      public DbSet<User> Users{ get; set; }
      public DbSet<Observation> Observations { get; set; }
      public DbSet<Marker> Markers { get; set; }
      public DbSet<Letter> Letters { get; set; }
      public DbSet<Cipher> Ciphers { get; set; }
      public DbSet<CipherCD> CiphersCD { get; set; }
      public DbSet<NumTimes> NumTimes { get; set; }
      public DbSet<Note> Notes { get; set; }
      public DbSet<Chart> Charts { get; set; }
      public DbSet<Cycle> Cycles { get; set; }
      public DbSet<Role> Roles { get; set; }
      public DbSet<Picture> Pictures { get; set; }

      //protected override void OnModelCreating(DbModelBuilder modelbuilder)
      //{
      //   //modelbuilder.Ignore<NodesTreeVM>();
      //   modelbuilder.Entity<Node>().ToTable("tblNodes");
      //   base.OnModelCreating(modelbuilder);
      //}
   }
}