using Microsoft.EntityFrameworkCore;
using WebAPITest.Model;
namespace WebAPITest
{
    public class ContextDatabase : DbContext
    {
        public DbSet<People>? People { get; set; }

        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasData(new[] { new People() {
                Id = 1,
                SurName="Алимов",
                Name="Расим",
                LastName="Надырович",
                BirthDate=DateOnly.Parse("2020-02-02"),
            },
            new People()
            {
                Id = 2,
                SurName="Зарипов",
                Name="Роман",
                LastName="Айдарович",
                BirthDate=DateOnly.Parse("2010-04-04"),
            },
             new People()
            {
                Id = 3,
                SurName="Якупов",
                Name="Айнур",
                LastName="Айдарович",
                BirthDate=DateOnly.Parse("2002-07-01"),
            },
              new People()
            {
                Id = 4,
                SurName="Валиуллин",
                Name="Ранис",
                LastName="Хайдарович",
                BirthDate=DateOnly.Parse("2001-11-24"),
            },
              new People()
            {
                Id = 5,
                SurName = "Иванов",
                Name = "Алексей",
                LastName = "Петрович",
                BirthDate = DateOnly.Parse("1995-03-15"),
            },
            new People()
            {
                Id = 6,
                SurName = "Смирнова",
                Name = "Елена",
                LastName = "Игоревна",
                BirthDate = DateOnly.Parse("1988-12-20"),
            },
            new People()
            {
                Id = 7,
                SurName = "Козлов",
                Name = "Иван",
                LastName = "Сергеевич",
                BirthDate = DateOnly.Parse("1976-09-10"),
            },
            new People()
            {
                Id = 8,
                SurName = "Петров",
                Name = "Михаил",
                LastName = "Александрович",
                BirthDate = DateOnly.Parse("1985-05-25"),
            },
            new People()
            {
                Id = 9,
                SurName = "Соколов",
                Name = "Татьяна",
                LastName = "Павловна",
                BirthDate = DateOnly.Parse("2000-08-02"),
            },
            new People()
            {
                Id = 10,
                SurName = "Кузнецов",
                Name = "Дмитрий",
                LastName = "Иванович",
                BirthDate = DateOnly.Parse("1992-02-17"),
            },
            new People()
            {
                Id = 11,
                SurName = "Павлов",
                Name = "Ольга",
                LastName = "Андреевна",
                BirthDate = DateOnly.Parse("1980-07-29"),
            },
            new People()
            {
                Id = 12,
                SurName = "Никитин",
                Name = "Артем",
                LastName = "Викторович",
                BirthDate = DateOnly.Parse("1998-04-08"),
            },
            new People()
            {
                Id = 13,
                SurName = "Морозова",
                Name = "Анна",
                LastName = "Сергеевна",
                BirthDate = DateOnly.Parse("1993-11-14"),
            },
            new People()
            {
                Id = 14,
                SurName = "Зайцев",
                Name = "Владимир",
                LastName = "Анатольевич",
                BirthDate = DateOnly.Parse("1987-06-03"),
            },
            new People()
            {
                Id = 15,
                SurName = "Федорова",
                Name = "Мария",
                LastName = "Александровна",
                BirthDate = DateOnly.Parse("1990-09-27"),
            },
            new People()
            {
                Id = 16,
                SurName = "Борисов",
                Name = "Андрей",
                LastName = "Петрович",
                BirthDate = DateOnly.Parse("1974-03-21"),
            },
            new People()
            {
                Id = 17,
                SurName = "Андреева",
                Name = "Екатерина",
                LastName = "Игоревна",
                BirthDate = DateOnly.Parse("2003-01-05"),
            },
            new People()
            {
                Id = 18,
                SurName = "Сергеев",
                Name = "Игорь",
                LastName = "Александрович",
                BirthDate = DateOnly.Parse("1989-12-12"),
            },
            new People()
            {
                Id = 19,
                SurName = "Попова",
                Name = "Оксана",
                LastName = "Валерьевна",
                BirthDate = DateOnly.Parse("1996-08-23"),
            },
            new People()
            {
                Id = 20,
                SurName = "Карпов",
                Name = "Сергей",
                LastName = "Иванович",
                BirthDate = DateOnly.Parse("1983-07-11"),
            },
            new People()
            {
                Id = 21,
                SurName = "Григорьева",
                Name = "Лариса",
                LastName = "Андреевна",
                BirthDate = DateOnly.Parse("1997-10-09"),
            },
            new People()
            {
                Id = 22,
                SurName = "Максимов",
                Name = "Александр",
                LastName = "Сергеевич",
                BirthDate = DateOnly.Parse("1982-05-18"),
            },
            new People()
            {
                Id = 23,
                SurName = "Семенов",
                Name = "Николай",
                LastName = "Анатольевич",
                BirthDate = DateOnly.Parse("2005-02-02"),
            },
            new People()
            {
                Id = 24,
                SurName = "Дмитриева",
                Name = "Ангелина",
                LastName = "Ивановна",
                BirthDate = DateOnly.Parse("1994-04-28"),
            },
            new People()
            {
                Id = 25,
                SurName = "Егоров",
                Name = "Артур",
                LastName = "Павлович",
                BirthDate = DateOnly.Parse("2004-06-12"),
            },
            new People()
            {
                Id = 26,
                SurName = "Захарова",
                Name = "Евгения",
                LastName = "Александровна",
                BirthDate = DateOnly.Parse("1999-09-07"),
            },
            new People()
            {
                Id = 27,
                SurName = "Савельев",
                Name = "Максим",
                LastName = "Андреевич",
                BirthDate = DateOnly.Parse("2006-03-19"),
            },
            new People()
            {
                Id = 28,
                SurName = "Орлов",
                Name = "Денис",
                LastName = "Сергеевич",
                BirthDate = DateOnly.Parse("1991-08-31"),
            },
            new People()
            {
                Id = 29,
                SurName = "Гаврилова",
                Name = "Надежда",
                LastName = "Игоревна",
                BirthDate = DateOnly.Parse("2008-11-05"),
            },
            new People()
            {
                Id = 30,
                SurName = "Белов",
                Name = "Антон",
                LastName = "Александрович",
                BirthDate = DateOnly.Parse("2007-12-24"),
            }
            });  
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
