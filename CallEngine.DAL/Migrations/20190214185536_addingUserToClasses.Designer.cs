﻿// <auto-generated />
using System;
using CallEngine.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CallEngine.DAL.Migrations
{
    [DbContext(typeof(CallAppContext))]
    [Migration("20190214185536_addingUserToClasses")]
    partial class addingUserToClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CallEngine.Models.BaseActionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("EngagementId");

                    b.Property<bool>("Initial");

                    b.Property<int?>("SoundFileId");

                    b.Property<int>("Type");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EngagementId");

                    b.HasIndex("SoundFileId");

                    b.HasIndex("UserId");

                    b.ToTable("BaseActionModels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseActionModel");
                });

            modelBuilder.Entity("CallEngine.Models.CallSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ANI");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DNIS");

                    b.Property<int?>("EngagementId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EngagementId");

                    b.HasIndex("UserId");

                    b.ToTable("CallSchedules");
                });

            modelBuilder.Entity("CallEngine.Models.Digit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BaseActionModelId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Key");

                    b.Property<int>("NextActionId");

                    b.Property<int>("ParentActionId");

                    b.Property<int?>("UserId");

                    b.Property<string>("someField");

                    b.HasKey("Id");

                    b.HasIndex("BaseActionModelId");

                    b.HasIndex("NextActionId")
                        .IsUnique();

                    b.HasIndex("ParentActionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Digits");
                });

            modelBuilder.Entity("CallEngine.Models.Engagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Engagements");
                });

            modelBuilder.Entity("CallEngine.Models.IncomingCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ANI");

                    b.Property<string>("CallSid");

                    b.Property<int>("CallStatus");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DNIS");

                    b.Property<int>("Duration");

                    b.Property<int>("EngagementId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EngagementId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("IncomingCalls");
                });

            modelBuilder.Entity("CallEngine.Models.Mailbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoxNumber");

                    b.Property<DateTime>("Created");

                    b.Property<string>("PIN");

                    b.Property<int?>("SoundFileId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SoundFileId");

                    b.HasIndex("UserId");

                    b.ToTable("MailBoxes");
                });

            modelBuilder.Entity("CallEngine.Models.SoundFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("FileType");

                    b.Property<string>("TTS");

                    b.Property<string>("Uri");

                    b.Property<int?>("UserId");

                    b.Property<bool>("isTTS");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SoundFiles");
                });

            modelBuilder.Entity("CallEngine.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<bool>("Enabled");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName");

                    b.Property<string>("Phonenumber");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CallEngine.Models.PlayFileAction", b =>
                {
                    b.HasBaseType("CallEngine.Models.BaseActionModel");

                    b.Property<string>("TerminationKey");

                    b.HasDiscriminator().HasValue("PlayFileAction");
                });

            modelBuilder.Entity("CallEngine.Models.RecordFileAction", b =>
                {
                    b.HasBaseType("CallEngine.Models.PlayFileAction");

                    b.Property<int>("MaxLength");

                    b.Property<bool>("PlayBeep");

                    b.HasDiscriminator().HasValue("RecordFileAction");
                });

            modelBuilder.Entity("CallEngine.Models.BaseActionModel", b =>
                {
                    b.HasOne("CallEngine.Models.Engagement", "Engagement")
                        .WithMany("Actions")
                        .HasForeignKey("EngagementId");

                    b.HasOne("CallEngine.Models.SoundFile", "SoundFile")
                        .WithMany()
                        .HasForeignKey("SoundFileId");

                    b.HasOne("CallEngine.Models.User")
                        .WithMany("BaseActionModels")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CallEngine.Models.CallSchedule", b =>
                {
                    b.HasOne("CallEngine.Models.Engagement", "Engagement")
                        .WithMany()
                        .HasForeignKey("EngagementId");

                    b.HasOne("CallEngine.Models.User", "User")
                        .WithMany("CallSchedules")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CallEngine.Models.Digit", b =>
                {
                    b.HasOne("CallEngine.Models.BaseActionModel")
                        .WithMany("Digits")
                        .HasForeignKey("BaseActionModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CallEngine.Models.BaseActionModel", "NextAction")
                        .WithOne()
                        .HasForeignKey("CallEngine.Models.Digit", "NextActionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CallEngine.Models.BaseActionModel", "ParentAction")
                        .WithOne()
                        .HasForeignKey("CallEngine.Models.Digit", "ParentActionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CallEngine.Models.User")
                        .WithMany("Digits")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CallEngine.Models.Engagement", b =>
                {
                    b.HasOne("CallEngine.Models.User", "User")
                        .WithMany("Engagements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CallEngine.Models.IncomingCall", b =>
                {
                    b.HasOne("CallEngine.Models.Engagement", "Engagement")
                        .WithOne()
                        .HasForeignKey("CallEngine.Models.IncomingCall", "EngagementId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CallEngine.Models.User", "User")
                        .WithMany("IncomingCalls")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CallEngine.Models.Mailbox", b =>
                {
                    b.HasOne("CallEngine.Models.SoundFile", "SoundFile")
                        .WithMany()
                        .HasForeignKey("SoundFileId");

                    b.HasOne("CallEngine.Models.User", "User")
                        .WithMany("MailBoxes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CallEngine.Models.SoundFile", b =>
                {
                    b.HasOne("CallEngine.Models.User", "User")
                        .WithMany("SoundFiles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
