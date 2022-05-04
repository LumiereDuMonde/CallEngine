using CallEngine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CallEngine.DAL
{
	// initial migration string:
	// dotnet ef migrations add InitialCreate --project CallEngine.DAL  --startup-project CallEngine.API
	// dotnet ef database update --project CallEngine.DAL  --startup-project CallEngine.API

	// if after add but before delete you want to delete a migration.
	// ** this step might is wrong for simple reversion ** dotnet ef database update <previous Migration name> --project CallEngine.DAL  --startup-project CallEngine.API ** this step might be wrong **
	// delete new migration from Migrations folder.
	// dotnet ef migrations remove --project CallEngine.DAL  --startup-project CallEngine.API
	public partial class CallAppContext : DbContext
	{
		public CallAppContext(DbContextOptions<CallAppContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BaseActionModel>()
				.HasMany(d => d.Digits)
				.WithOne()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Engagement>()
				.HasMany(c => c.Actions)
				.WithOne(e => e.Engagement);

			modelBuilder.Entity<Digit>()
				.HasOne(d => d.ParentAction).WithMany()				
				.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Digit>() 
				.HasOne(x => x.NextAction)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Engagement> Engagements { get; set; }
		public virtual DbSet<Digit> Digits { get; set; }				
		public virtual DbSet<PlayFileAction> PlayFileActions { get; set; }
		public virtual DbSet<SoundFile> SoundFiles { get; set; }
		public virtual DbSet<RecordFileAction> RecordFileActions { get; set; }
		public virtual DbSet<BaseActionModel> BaseActionModels { get; set; }
		public virtual DbSet<IncomingCall> IncomingCalls { get; set; }
		public virtual DbSet<CallSchedule> CallSchedules { get; set; }
		public virtual DbSet<Mailbox> MailBoxes { get; set; }
		public virtual DbSet<OperatorAction> OperatorActions { get; set; }
		public virtual DbSet<Operator> Operators { get; set; }
		public virtual DbSet<OperatorGroupTracker> OperatorGroupTrackers { get; set; }
		public virtual DbSet<OperatorGroup> OperatorGroups { get; set; }
		public virtual DbSet<CallEngineParamsLog> CallEngineParamsLog { get; set; }
		public virtual DbSet<DNIS> DNIS { get; set; }
		public virtual DbSet<IncomingSMS> IncomingSMS { get; set; }
	}
}
