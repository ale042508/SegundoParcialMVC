using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SegundoParcialAPI.Models;

public partial class CreditContext : DbContext
{
    public CreditContext()
    {
    }

    public CreditContext(DbContextOptions<CreditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BasicMember> BasicMembers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Charge> Charges { get; set; }

    public virtual DbSet<ChargeWide> ChargeWides { get; set; }

    public virtual DbSet<CorpMember> CorpMembers { get; set; }

    public virtual DbSet<Corporation> Corporations { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Member2> Member2s { get; set; }

    public virtual DbSet<Overdue> Overdues { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentWide> PaymentWides { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Statement> Statements { get; set; }

    public virtual DbSet<StatementWide> StatementWides { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Test2> Test2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALEJANDRO_ROSA; Database=Credit; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BasicMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("basic_member");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryNo).HasName("category_ident");

            entity.ToTable("category");

            entity.Property(e => e.CategoryNo).HasColumnName("category_no");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("category_code");
            entity.Property(e => e.CategoryDesc)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("category_desc");
        });

        modelBuilder.Entity<Charge>(entity =>
        {
            entity.HasKey(e => e.ChargeNo).HasName("ChargePK");

            entity.ToTable("charge");

            entity.HasIndex(e => e.CategoryNo, "charge_category_link");

            entity.HasIndex(e => e.ProviderNo, "charge_provider_link");

            entity.HasIndex(e => e.StatementNo, "charge_statement_link");

            entity.Property(e => e.ChargeNo).HasColumnName("charge_no");
            entity.Property(e => e.CategoryNo).HasColumnName("category_no");
            entity.Property(e => e.ChargeAmt)
                .HasColumnType("money")
                .HasColumnName("charge_amt");
            entity.Property(e => e.ChargeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("charge_code");
            entity.Property(e => e.ChargeDt)
                .HasColumnType("datetime")
                .HasColumnName("charge_dt");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.ProviderNo).HasColumnName("provider_no");
            entity.Property(e => e.StatementNo).HasColumnName("statement_no");

            entity.HasOne(d => d.CategoryNoNavigation).WithMany(p => p.Charges)
                .HasForeignKey(d => d.CategoryNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("charge_category_link");

            entity.HasOne(d => d.MemberNoNavigation).WithMany(p => p.Charges)
                .HasForeignKey(d => d.MemberNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("charge_member_link");

            entity.HasOne(d => d.ProviderNoNavigation).WithMany(p => p.Charges)
                .HasForeignKey(d => d.ProviderNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("charge_provider_link");
        });

        modelBuilder.Entity<ChargeWide>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("charge_wide");

            entity.Property(e => e.CategoryDesc)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("category_desc");
            entity.Property(e => e.CategoryNo).HasColumnName("category_no");
            entity.Property(e => e.ChargeAmt)
                .HasColumnType("money")
                .HasColumnName("charge_amt");
            entity.Property(e => e.ChargeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("charge_code");
            entity.Property(e => e.ChargeDt)
                .HasColumnType("datetime")
                .HasColumnName("charge_dt");
            entity.Property(e => e.ChargeNo).HasColumnName("charge_no");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("provider_name");
            entity.Property(e => e.ProviderNo).HasColumnName("provider_no");
            entity.Property(e => e.RegionName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("region_name");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
        });

        modelBuilder.Entity<CorpMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("corp_member");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CorpCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("corp_code");
            entity.Property(e => e.CorpName)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("corp_name");
            entity.Property(e => e.CorpNo).HasColumnName("corp_no");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Corporation>(entity =>
        {
            entity.HasKey(e => e.CorpNo).HasName("corporation_ident");

            entity.ToTable("corporation");

            entity.HasIndex(e => e.RegionNo, "corporation_region_link");

            entity.Property(e => e.CorpNo).HasColumnName("corp_no");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CorpCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("corp_code");
            entity.Property(e => e.CorpName)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("corp_name");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.RegionNoNavigation).WithMany(p => p.Corporations)
                .HasForeignKey(d => d.RegionNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("corporation_region_link");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberNo).HasName("member_ident");

            entity.ToTable("member");

            entity.HasIndex(e => e.CorpNo, "member_corporation_link");

            entity.HasIndex(e => e.RegionNo, "member_region_link");

            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CorpNo).HasColumnName("corp_no");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.CurrBalance)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("curr_balance");
            entity.Property(e => e.ExprDt)
                .HasDefaultValueSql("(dateadd(year,1,getdate()))")
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.IssueDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("issue_dt");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.Photograph)
                .HasColumnType("image")
                .HasColumnName("photograph");
            entity.Property(e => e.PrevBalance)
                .HasDefaultValue(0m)
                .HasColumnType("money")
                .HasColumnName("prev_balance");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.CorpNoNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.CorpNo)
                .HasConstraintName("member_corporation_link");

            entity.HasOne(d => d.RegionNoNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.RegionNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("member_region_link");
        });

        modelBuilder.Entity<Member2>(entity =>
        {
            entity.HasKey(e => e.MemberNo)
                .HasName("member2PK")
                .IsClustered(false);

            entity.ToTable("member2");

            entity.HasIndex(e => new { e.Lastname, e.Firstname, e.Middleinitial }, "member2Cl").IsClustered();

            entity.HasIndex(e => e.CorpNo, "member2CorpFK");

            entity.HasIndex(e => e.RegionNo, "member2RegionFK");

            entity.Property(e => e.MemberNo)
                .ValueGeneratedNever()
                .HasColumnName("member_no");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CorpNo).HasColumnName("corp_no");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.CurrBalance)
                .HasColumnType("money")
                .HasColumnName("curr_balance");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.IssueDt)
                .HasColumnType("datetime")
                .HasColumnName("issue_dt");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.Photograph)
                .HasColumnType("image")
                .HasColumnName("photograph");
            entity.Property(e => e.PrevBalance)
                .HasColumnType("money")
                .HasColumnName("prev_balance");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Overdue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("overdue");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.DueDt)
                .HasColumnType("datetime")
                .HasColumnName("due_dt");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("region_name");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.StatementAmt)
                .HasColumnType("money")
                .HasColumnName("statement_amt");
            entity.Property(e => e.StatementCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("statement_code");
            entity.Property(e => e.StatementDt)
                .HasColumnType("datetime")
                .HasColumnName("statement_dt");
            entity.Property(e => e.StatementNo).HasColumnName("statement_no");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentNo)
                .HasName("payment_ident")
                .IsClustered(false);

            entity.ToTable("payment");

            entity.HasIndex(e => e.MemberNo, "payment_member_link");

            entity.Property(e => e.PaymentNo).HasColumnName("payment_no");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.PaymentAmt)
                .HasColumnType("money")
                .HasColumnName("payment_amt");
            entity.Property(e => e.PaymentCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("payment_code");
            entity.Property(e => e.PaymentDt)
                .HasColumnType("datetime")
                .HasColumnName("payment_dt");
            entity.Property(e => e.StatementNo)
                .HasDefaultValue(0)
                .HasColumnName("statement_no");

            entity.HasOne(d => d.MemberNoNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.MemberNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_member_link");
        });

        modelBuilder.Entity<PaymentWide>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("payment_wide");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PaymentAmt)
                .HasColumnType("money")
                .HasColumnName("payment_amt");
            entity.Property(e => e.PaymentCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payment_code");
            entity.Property(e => e.PaymentDt)
                .HasColumnType("datetime")
                .HasColumnName("payment_dt");
            entity.Property(e => e.PaymentNo).HasColumnName("payment_no");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("region_name");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderNo).HasName("provider_ident");

            entity.ToTable("provider");

            entity.HasIndex(e => e.RegionNo, "provider_region_link");

            entity.Property(e => e.ProviderNo).HasColumnName("provider_no");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.ExprDt)
                .HasDefaultValueSql("(dateadd(year,1,getdate()))")
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.IssueDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("issue_dt");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("provider_code");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("provider_name");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.RegionNoNavigation).WithMany(p => p.Providers)
                .HasForeignKey(d => d.RegionNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provider_region_link");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionNo).HasName("region_ident");

            entity.ToTable("region");

            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("region_code");
            entity.Property(e => e.RegionName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("region_name");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Statement>(entity =>
        {
            entity.HasKey(e => e.StatementNo).HasName("statement_ident");

            entity.ToTable("statement");

            entity.HasIndex(e => e.MemberNo, "statement_member_link");

            entity.Property(e => e.StatementNo).HasColumnName("statement_no");
            entity.Property(e => e.DueDt)
                .HasColumnType("datetime")
                .HasColumnName("due_dt");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.StatementAmt)
                .HasColumnType("money")
                .HasColumnName("statement_amt");
            entity.Property(e => e.StatementCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("  ")
                .IsFixedLength()
                .HasColumnName("statement_code");
            entity.Property(e => e.StatementDt)
                .HasColumnType("datetime")
                .HasColumnName("statement_dt");

            entity.HasOne(d => d.MemberNoNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.MemberNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statement_member_link");
        });

        modelBuilder.Entity<StatementWide>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("statement_wide");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.DueDt)
                .HasColumnType("datetime")
                .HasColumnName("due_dt");
            entity.Property(e => e.ExprDt)
                .HasColumnType("datetime")
                .HasColumnName("expr_dt");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MailCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mail_code");
            entity.Property(e => e.MemberCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("member_code");
            entity.Property(e => e.MemberNo).HasColumnName("member_no");
            entity.Property(e => e.Middleinitial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("middleinitial");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.RegionName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("region_name");
            entity.Property(e => e.RegionNo).HasColumnName("region_no");
            entity.Property(e => e.StateProv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state_prov");
            entity.Property(e => e.StatementAmt)
                .HasColumnType("money")
                .HasColumnName("statement_amt");
            entity.Property(e => e.StatementCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("statement_code");
            entity.Property(e => e.StatementDt)
                .HasColumnType("datetime")
                .HasColumnName("statement_dt");
            entity.Property(e => e.StatementNo).HasColumnName("statement_no");
            entity.Property(e => e.Street)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusCode).HasName("status_ident");

            entity.ToTable("status");

            entity.Property(e => e.StatusCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status_code");
            entity.Property(e => e.StatusDesc)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasColumnName("status_desc");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("test");

            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MemberNo)
                .ValueGeneratedOnAdd()
                .HasColumnName("member_no");
        });

        modelBuilder.Entity<Test2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("test2");

            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.MemberNo)
                .ValueGeneratedOnAdd()
                .HasColumnName("member_no");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
