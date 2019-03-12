namespace BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public partial class BookStoreModel : DbContext
    {
        public BookStoreModel()
            : base("name=BookStoreModel")
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<book_shopping_cart> book_shopping_cart { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<discounts_shopping_cart> discounts_shopping_cart { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Shopping_Cart> Shopping_Cart { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Book)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.author_id);

            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.book_shopping_cart)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.book_id);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Review)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.book_id);

            modelBuilder.Entity<Discounts>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Discounts>()
                .HasMany(e => e.discounts_shopping_cart)
                .WithOptional(e => e.Discounts)
                .HasForeignKey(e => e.discounts_id);

            modelBuilder.Entity<Genre>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Book)
                .WithOptional(e => e.Genre)
                .HasForeignKey(e => e.genre_id);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Book)
                .WithOptional(e => e.Publisher)
                .HasForeignKey(e => e.publisher_id);

            modelBuilder.Entity<Review>()
                .Property(e => e.review1)
                .IsUnicode(false);

            modelBuilder.Entity<Shopping_Cart>()
                .HasMany(e => e.book_shopping_cart)
                .WithOptional(e => e.Shopping_Cart)
                .HasForeignKey(e => e.cart_id);

            modelBuilder.Entity<Shopping_Cart>()
                .HasMany(e => e.discounts_shopping_cart)
                .WithOptional(e => e.Shopping_Cart)
                .HasForeignKey(e => e.cart_id);

            modelBuilder.Entity<Warehouse>()
                .Property(e => e.row)
                .IsUnicode(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(e => e.Book)
                .WithOptional(e => e.Warehouse)
                .HasForeignKey(e => e.warehause_id);
        }


     

    }

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            Book = new HashSet<Book>();
        }

        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string firstname { get; set; }

        [Required]
        [StringLength(255)]
        public string lastname { get; set; }

        [Required]
        [StringLength(255)]
        public string country { get; set; }

        public DateTime birthdate { get; set; }

        public DateTime? deathdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }
    }

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            book_shopping_cart = new HashSet<book_shopping_cart>();
            Review = new HashSet<Review>();
        }

        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public double price { get; set; }

        public long? genre_id { get; set; }

        public long? publisher_id { get; set; }

        public long? warehause_id { get; set; }

        public long? author_id { get; set; }

        public virtual Author Author { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book_shopping_cart> book_shopping_cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }
    }

    public partial class book_shopping_cart
    {
        [Key]
        public long id { get; set; }

        public long? book_id { get; set; }

        public long? cart_id { get; set; }

        public virtual Book Book { get; set; }

        public virtual Shopping_Cart Shopping_Cart { get; set; }
    }

    public partial class Discounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discounts()
        {
            discounts_shopping_cart = new HashSet<discounts_shopping_cart>();
        }
        [Key]
        public long id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public double rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discounts_shopping_cart> discounts_shopping_cart { get; set; }
    }

    public partial class discounts_shopping_cart
    {
        [Key]
        public long id { get; set; }

        public long? discounts_id { get; set; }

        public long? cart_id { get; set; }

        public virtual Discounts Discounts { get; set; }

        public virtual Shopping_Cart Shopping_Cart { get; set; }
    }

    [Table("Genre")]
    public partial class Genre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }
    }

    [Table("Publisher")]
    public partial class Publisher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        public DateTime? publishdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }
    }

    [Table("Review")]
    public partial class Review
    {
        [Key]
        public long id { get; set; }

        [Column("review")]
        [Required]
        [StringLength(255)]
        public string review1 { get; set; }

        public DateTime? dateReview { get; set; }

        [StringLength(128)]
        public string user_id { get; set; }

        public long? book_id { get; set; }

        public virtual Book Book { get; set; }
    }

    public partial class Shopping_Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shopping_Cart()
        {
            book_shopping_cart = new HashSet<book_shopping_cart>();
            discounts_shopping_cart = new HashSet<discounts_shopping_cart>();
        }
        [Key]
        public long id { get; set; }

        public DateTime? date_of_order { get; set; }

        public double? total_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book_shopping_cart> book_shopping_cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discounts_shopping_cart> discounts_shopping_cart { get; set; }
    }

    [Table("Warehouse")]
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            Book = new HashSet<Book>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long id { get; set; }

        public int? quantity { get; set; }

        [StringLength(255)]
        public string row { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Book { get; set; }
    }
}
