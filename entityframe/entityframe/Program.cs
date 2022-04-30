using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace entityframe
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=entitydb;Trusted_Connection=True;");
        }
    }
    class Program
    {
        public static void Create()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                int age;
                string name;
                Console.Write("Введите имя: ");
                name = Console.ReadLine();
                while (name == "")
                {
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();
                }
                Console.Write("Введите возраст: ");
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.Write("Требуется ввести натуральное число, попробуйте ещё раз: ");
                }
                User user = new User { Name = name, Age = age };
                db.Users.Add(user);
                db.SaveChanges();
            }
            Console.WriteLine("\nЗапись успешно добавлена \nНажмите любую клавишу, чтобы вернуться к выбору операции");
            Console.ReadKey();
            Main();
        }
        public static void Read()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться к выбору операции");
            Console.ReadKey();
            Main();
        }
        public static void Update()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                int id;
                Console.Write("Введите id записи, которую хотите изменить: ");
                while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || db.Users.Find(id) == null)
                {
                    Console.Write("Запись с таким id не найдена, попробуйте ещё раз: ");
                }
                User user = db.Users.Find(id);
                    string name = user.Name;
                    int age = user.Age;
                    Console.WriteLine("Изменить имя?\n1- Да\n2- Нет");
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case '1':
                            Console.Write("Введите имя: ");
                            name = Console.ReadLine();
                            while (name == "")
                            {
                                Console.Write("Введите имя: ");
                                name = Console.ReadLine();
                            }
                            break;
                        default: break;
                    }
                    Console.WriteLine("Изменить возраст?\n1- Да\n2- Нет");
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case '1':
                            Console.Write("Введите возраст: ");
                            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                            {
                                Console.Write("Требуется ввести натуральное число, попробуйте ещё раз: ");
                            }
                            break;
                        default: break;
                    }
                    user.Name = name;
                    user.Age = age;
                    db.SaveChanges();
            }
            Console.WriteLine("\nЗапись успешно обновлена \nНажмите любую клавишу, чтобы вернуться к выбору операции");
            Console.ReadKey();
            Main();
        }
        public static void Delete()
        {
            Console.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                int id;
                Console.Write("Введите id записи, которую хотите удалить: ");
                while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || db.Users.Find(id) == null)
                {
                    Console.Write("Запись с таким id не найдена, попробуйте ещё раз: ");
                }
                db.Users.Remove(db.Users.Find(id));
                db.SaveChanges();
            }
            Console.WriteLine("\nЗапись успешно удалена \nНажмите любую клавишу, чтобы вернуться к выбору операции");
            Console.ReadKey();
            Main();
        }
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Операции с базой данных:\n1 – Добавить запись\n2 – Изменить запись\n3 – Удалить запись\n4 - Вывести данные из таблицы \n0 - Выход из программы");
            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': Create(); break;
                    case '2': Update(); break;
                    case '3': Delete(); break;
                    case '4': Read(); break;
                    case '0': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}
