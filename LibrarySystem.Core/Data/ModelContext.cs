using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibrarySystem.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutuspage> Aboutuspages { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookReview> BookReviews { get; set; } = null!;
        public virtual DbSet<Borrowedbook> Borrowedbooks { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Contactuspage> Contactuspages { get; set; } = null!;
        public virtual DbSet<Homepage> Homepages { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Testimonialpage> Testimonialpages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522))(CONNECT_DATA=(SID=xe)));User Id=C##FINALPROJECTAPI;Password=Test321;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##FINALPROJECTAPI")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Aboutuspage>(entity =>
            {
                entity.ToTable("ABOUTUSPAGE");

                entity.Property(e => e.AboutuspageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTUSPAGE_ID");

                entity.Property(e => e.FooterComponent1)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT1");

                entity.Property(e => e.FooterComponent2)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT2");

                entity.Property(e => e.FooterComponent3)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT3");

                entity.Property(e => e.HeaderComponent1)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT1");

                entity.Property(e => e.HeaderComponent2)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT2");

                entity.Property(e => e.HeaderComponent3)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT3");

                entity.Property(e => e.ImagePath1)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH1");

                entity.Property(e => e.ImagePath2)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH2");

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.Paragraph1)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH1");

                entity.Property(e => e.Paragraph2)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH2");

                entity.Property(e => e.Paragraph3)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH3");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.CardId)
                    .HasName("PK_BANK_CARD_ID");

                entity.ToTable("BANK");

                entity.Property(e => e.CardId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARD_ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("FLOAT")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.CardNo)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CARD_NO");

                entity.Property(e => e.CardholderName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDER_NAME");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CVV");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOKS");

                entity.Property(e => e.BookId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOK_ID");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AUTHOR");

                entity.Property(e => e.AvgRating)
                    .HasColumnType("FLOAT")
                    .HasColumnName("AVG_RATING");

                entity.Property(e => e.BookImgPath)
                    .IsUnicode(false)
                    .HasColumnName("BOOK_IMG_PATH");

                entity.Property(e => e.BookPdfPath)
                    .IsUnicode(false)
                    .HasColumnName("BOOK_PDF_PATH");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.PricePerDay)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE_PER_DAY");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PUBLICATION_DATE");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BookReview>(entity =>
            {
                entity.ToTable("BOOK_REVIEW");

                entity.Property(e => e.BookReviewId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOK_REVIEW_ID");

                entity.Property(e => e.BookId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BOOK_ID");

                entity.Property(e => e.BorrowId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BORROW_ID");

                entity.Property(e => e.Rating)
                    .HasColumnType("FLOAT")
                    .HasColumnName("RATING");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REVIEW_DATE");

                entity.Property(e => e.ReviewText)
                    .IsUnicode(false)
                    .HasColumnName("REVIEW_TEXT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookReviews)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Borrow)
                    .WithMany(p => p.BookReviews)
                    .HasForeignKey(d => d.BorrowId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookReviews)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Borrowedbook>(entity =>
            {
                entity.HasKey(e => e.BorrowId)
                    .HasName("PK_BORROWEDBOOKS_BORROW_ID");

                entity.ToTable("BORROWEDBOOKS");

                entity.Property(e => e.BorrowId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BORROW_ID");

                entity.Property(e => e.BookId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BOOK_ID");

                entity.Property(e => e.BorrowDateFrom)
                    .HasColumnType("DATE")
                    .HasColumnName("BORROW_DATE_FROM");

                entity.Property(e => e.BorrowDateTo)
                    .HasColumnType("DATE")
                    .HasColumnName("BORROW_DATE_TO");

                entity.Property(e => e.FinePercentage)
                    .HasColumnType("FLOAT")
                    .HasColumnName("FINE_PERCENTAGE");

                entity.Property(e => e.IsfinePaid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ISFINE_PAID");

                entity.Property(e => e.ReturnedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RETURNED_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Borrowedbooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Borrowedbooks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.LibraryId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LIBRARY_ID");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.ContactusId)
                    .HasName("PK_CONTACTUS_CONTACTUS_ID");

                entity.ToTable("CONTACTUS");

                entity.Property(e => e.ContactusId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUS_ID");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.PhoneNumber)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Subject)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Contactuspage>(entity =>
            {
                entity.ToTable("CONTACTUSPAGE");

                entity.Property(e => e.ContactuspageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUSPAGE_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FooterComponent1)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT1");

                entity.Property(e => e.FooterComponent2)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT2");

                entity.Property(e => e.FooterComponent3)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT3");

                entity.Property(e => e.HeaderComponent1)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT1");

                entity.Property(e => e.HeaderComponent2)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT2");

                entity.Property(e => e.HeaderComponent3)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT3");

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Paragraph1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH1");

                entity.Property(e => e.Paragraph2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH2");

                entity.Property(e => e.Paragraph3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH3");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Homepage>(entity =>
            {
                entity.ToTable("HOMEPAGE");

                entity.Property(e => e.HomepageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOMEPAGE_ID");

                entity.Property(e => e.FooterComponent1)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT1");

                entity.Property(e => e.FooterComponent2)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT2");

                entity.Property(e => e.FooterComponent3)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT3");

                entity.Property(e => e.HeaderComponent1)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT1");

                entity.Property(e => e.HeaderComponent2)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT2");

                entity.Property(e => e.HeaderComponent3)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT3");

                entity.Property(e => e.ImagePath1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH1");

                entity.Property(e => e.ImagePath2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH2");

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.Paragraph1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH1");

                entity.Property(e => e.Paragraph2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH2");

                entity.Property(e => e.Paragraph3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH3");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("LIBRARIES");

                entity.Property(e => e.LibraryId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LIBRARY_ID");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.ImagePath1)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH1");

                entity.Property(e => e.ImagePath2)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH2");

                entity.Property(e => e.LocationLatitude)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_LATITUDE");

                entity.Property(e => e.LocationLongitude)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_LONGITUDE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialsId)
                    .HasName("PK_TESTIMONIALS_TESTIMONIALS_ID");

                entity.ToTable("TESTIMONIALS");

                entity.Property(e => e.TestimonialsId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALS_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUBMISSION_DATE");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Testimonialpage>(entity =>
            {
                entity.ToTable("TESTIMONIALPAGE");

                entity.Property(e => e.TestimonialpageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALPAGE_ID");

                entity.Property(e => e.FooterComponent1)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT1");

                entity.Property(e => e.FooterComponent2)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT2");

                entity.Property(e => e.FooterComponent3)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_COMPONENT3");

                entity.Property(e => e.HeaderComponent1)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT1");

                entity.Property(e => e.HeaderComponent2)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT2");

                entity.Property(e => e.HeaderComponent3)
                    .IsUnicode(false)
                    .HasColumnName("HEADER_COMPONENT3");

                entity.Property(e => e.ImagePath1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH1");

                entity.Property(e => e.ImagePath2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH2");

                entity.Property(e => e.Paragraph1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH1");

                entity.Property(e => e.Paragraph2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH2");

                entity.Property(e => e.Paragraph3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH3");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.IsActivated)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IS_ACTIVATED");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LocationLatitude)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_LATITUDE");

                entity.Property(e => e.LocationLongitude)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_LONGITUDE");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.ProfileImgPath)
                    .IsUnicode(false)
                    .HasColumnName("PROFILE_IMG_PATH");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REGISTRATION_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
