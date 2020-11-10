using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main(string[] args)
    {
        string mes = null;
        Console.WriteLine("Аллоха, я записная книжка!\nВот, что я умею:\nДобавить контакт: создать\nИзменить контакт: изменить\nУдалить контакт: удалить\nНайти контакт: найти\nСписок контактов: список\nЗакрыть Записную книжку: выход");
        mes = Console.ReadLine();
        while (mes != "выход")
        {
            if (mes == "создать")
            {
                Console.Clear();
                Zapis.CreateHuman();
            }
            else if (mes == "изменить")
            {
                Console.Clear();
                Zapis.Editer();
            }
            else if (mes == "удалить")
            {
                Console.Clear();
                Zapis.Deleter();
            }
            else if (mes == "найти")
            {
                Console.Clear();
                Zapis.Abonent();
            }
            else if (mes == "список")
            {
                Console.Clear();
                Zapis.AllAbonents();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Йа НЕ ПАНИМАТ!!!!");
            }
            Console.WriteLine("Вот, что я умею:\nДобавить контакт: создать\nИзменить контакт: изменить\nУдалить контакт: удалить\nНайти контакт: найти\nСписок контактов: список\nЗакрыть Записную книжку: выход");
            Console.WriteLine("Что дальше?");
            mes = Console.ReadLine();
            Console.Clear();

        }

    }
}
public static class Notebook
{
    public static Dictionary<int, Zapis> catalog = new Dictionary<int, Zapis>();
}
public class Zapis
{
    public string Firstname { get; set; }
    public string Midname { get; set; }
    public string Lastname { get; set; }
    public string Numberphone { get; set; }
    public string Country { get; set; }
    public string Date { get; set; }
    public string Organization { get; set; }
    public string Position { get; set; }
    public string Anytext { get; set; }
    public static int Id { get; set; } = 1;
    public static void CreateHuman()
    {
        string message;
        Zapis human = new Zapis();


        Console.WriteLine("Как его зовут?");
        message = Console.ReadLine();
        while (String.IsNullOrEmpty(message) == true)
        {
            Console.WriteLine("Ты ошибся ");
            message = Console.ReadLine();
        }
        human.Firstname = message;


        Console.WriteLine("Как его фамилия?");
        message = Console.ReadLine();
        while (String.IsNullOrEmpty(message) == true)
        {
            Console.WriteLine("Ты ошибся ");
            message = Console.ReadLine();
        }
        human.Lastname = message;


        Console.WriteLine("Как его отчество?");
        message = Console.ReadLine();
        if (String.IsNullOrEmpty(message) == true)
        {
            human.Midname = "Не введено";
        }
        else
        {
            human.Midname = message;
        }


        Console.WriteLine("Его телефон");
        message = Console.ReadLine();
        while (String.IsNullOrEmpty(message) == true)
        {
            Console.WriteLine("Ты ошибся ");
            message = Console.ReadLine();
        }
        human.Numberphone = message;


        Console.WriteLine("Страна");
        message = Console.ReadLine();
        while (String.IsNullOrEmpty(message) == true)
        {
            Console.WriteLine("Ты ошибся ");
            message = Console.ReadLine();
        }
        human.Country = message;


        Console.WriteLine("Дата");
        message = Console.ReadLine();
        if (String.IsNullOrEmpty(message) == true)
        {
            human.Date = "Не введено";
        }
        else
        {
            human.Date = message;
        }


        Console.WriteLine("Организация");
        message = Console.ReadLine();
        if (String.IsNullOrEmpty(message) == true)
        {
            human.Organization = "Не введено";
        }
        else
        {
            human.Organization = message;
        }


        Console.WriteLine("Должность");
        message = Console.ReadLine();
        if (String.IsNullOrEmpty(message) == true)
        {
            human.Position = "Не введено";
        }
        else
        {
            human.Position = message;
        }


        Console.WriteLine("Любая информация");
        message = Console.ReadLine();
        if (String.IsNullOrEmpty(message) == true)
        {
            human.Anytext = "Не введено";
        }
        else
        {
            human.Anytext = message;
        }


        Console.Clear();
        Console.WriteLine("Его ID - " + Zapis.Id + "\n\n\n");
        Notebook.catalog.Add(Zapis.Id, human);
        Zapis.Id++;
    }
    public static void Editer()
    {
        string message;
        Console.WriteLine("Кого выберем? Введите Id");
        int isq = int.Parse(Console.ReadLine());
        if (isq >= Zapis.Id || isq < 1)

        {
            Console.Clear();
            Console.WriteLine("Похоже он находится только у тебя в голове!\n\n\n");
            return;
        }
        Zapis chelik = Notebook.catalog[isq];
        if (chelik != null)
        {
            Console.WriteLine("Мы нашли - " + chelik.Firstname + "\nЧто будем менять(имя, фамилия, отчество, телефон, страна, дата, организация, должность, инфо или ничего");
            message = Console.ReadLine();
            while (message != "ничего")
            {
                if (message == "имя")
                {
                    Console.WriteLine("Как теперь его зовут?");
                    message = Console.ReadLine();
                    while (String.IsNullOrEmpty(message) == true)
                    {
                        Console.WriteLine("Ты ошибся ");
                        message = Console.ReadLine();
                    }
                    chelik.Firstname = message; // поставить фильтры на ввод не корректной информации в овремя исправления
                }
                else if (message == "фамилия")
                {
                    Console.WriteLine("Как теперь его фамилия?");
                    message = Console.ReadLine();
                    chelik.Lastname = message;
                }
                else if (message == "отчество")
                {
                    Console.WriteLine("Как теперь его зовут?");
                    message = Console.ReadLine();
                    chelik.Midname = message;
                }
                else if (message == "телефон")
                {
                    Console.WriteLine("Какой теперь у него телефон?");
                    message = Console.ReadLine();
                    chelik.Numberphone = message;
                }
                else if (message == "страна")
                {
                    Console.WriteLine("Где теперь он?");
                    message = Console.ReadLine();
                    chelik.Country = message;
                }
                else if (message == "организация")
                {
                    Console.WriteLine("Где теперь он работает?");
                    message = Console.ReadLine();
                    chelik.Organization = message;
                }
                else if (message == "должность")
                {
                    Console.WriteLine("Кем теперь он работает?");
                    message = Console.ReadLine();
                    chelik.Position = message;
                }
                else if (message == "инфо")
                {
                    Console.WriteLine("Ну рассказывай");
                    message = Console.ReadLine();
                    chelik.Anytext = message;
                }
                Console.WriteLine("Что-то еще?");
                message = Console.ReadLine();
            }

        }
        else { Console.WriteLine("Пупа, Лупа и ты все перепутали! Он умер!"); }
    }
    public static void Deleter()
    {

        Console.WriteLine("Ты кого-то решил удалить, введи его ID");
        int isq = int.Parse(Console.ReadLine());
        Notebook.catalog[isq] = null;
        Console.Clear();
        Console.WriteLine("Мы его удалили!\n\n\n");

    }
    public static void Abonent()
    {
        Console.WriteLine("Давай поищем! Давай его ID, а я найду его!");
        int isq = int.Parse(Console.ReadLine());
        Zapis chelik = new Zapis();
        chelik = Notebook.catalog[isq];
        Console.WriteLine($"Фамилия - {chelik.Lastname} / Имя - {chelik.Firstname} / Отчество - {chelik.Midname}\nТелефон - {chelik.Numberphone} / Дата - {chelik.Date} / Страна - {chelik.Country}\nРабота - {chelik.Organization} / Должность - {chelik.Position}\nИнформация: {chelik.Anytext}");

    }
    public static void AllAbonents()
    {
        Console.WriteLine("Начинаю выводить...\n\n\n");
        foreach (KeyValuePair<int, Zapis> keyValue in Notebook.catalog)
        {
            ; Zapis chelik = new Zapis();
            chelik = keyValue.Value;
            if (chelik == null)
            {
                continue;
            }
            Console.WriteLine(chelik);
        }
        Console.WriteLine("\n\n\nЯ закончил");


    }
    public override string ToString()
    {
        return $"Фамилия - {Lastname} / Имя - {Firstname} / Телефон - {Numberphone}\n";
    }
}
