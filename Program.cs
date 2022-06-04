using BankProjecktCMD.Class;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankProjecktCMD
{
    class Program
    {
        static public void Main(string[] args)
        {
            int x;
            string[] linev = File.ReadAllLines($"CardRegist.txt");
            Bank_CardAvailabilityearlier CardAvaible = new Bank_CardAvailabilityearlier();
            Bank_Card Card = new Bank_Card();
            List<Bank_Card> List_Cards = new List<Bank_Card>();
            Random random = new Random();
            Check check = new Check();
            Bank bank = new Bank();

            Register_Check();

            AccountIDverification();

            CreateBank_Card();

            Actions();

            void Register_Check()
            {
                Client client = new Client();
                Console.WriteLine("Вы зарегистрированы ? 1) да  2) нет ");
                int Byte_Register = int.Parse(Console.ReadLine());

                bool Bool_Register = false;
                bool CheckCycle = false;
                while (CheckCycle == false)
                {
                    if (Byte_Register == 1)
                    {
                        CheckCycle = true;
                        Bool_Register = true;
                        if (Bool_Register == true)
                        {
                            bool b = File.Exists("Data.txt");

                            if (b == true)
                            {
                                StreamReader sr = new StreamReader("Data.txt");
                                string[] line = File.ReadAllLines("Data.txt");

                                if (string.IsNullOrEmpty(line[0]) || string.IsNullOrWhiteSpace(line[1]) || string.IsNullOrWhiteSpace(line[2]) || string.IsNullOrWhiteSpace(line[3]))
                                {
                                    Console.WriteLine("Данные не найдены");
                                    Register_Check();

                                }

                                client.Client_ID = long.Parse(line[0]);
                                client.Client_Name = line[1];
                                client.Client_Age = int.Parse(line[2]);
                                client.Str_Client_Gender = line[3];

                                Console.WriteLine(client.Client_ID.ToString());
                                Console.WriteLine(client.Client_Name.ToString());
                                Console.WriteLine(client.Client_Age.ToString());
                                Console.WriteLine(client.Str_Client_Gender.ToString());
                            }
                            else
                            {

                                Console.WriteLine("Файла с данными не существует, зарегистрируйтесь ");

                                CheckCycle = true;
                                Bool_Register = false;

                                Console.WriteLine("Введите ваш ID: 16 чисел ");
                                client.Client_ID = long.Parse(Console.ReadLine());

                                while (client.Client_ID > 10000000000000000 || client.Client_ID < 1000000000000000)
                                {
                                    Console.WriteLine("Введите ID ещё раз: ");
                                    client.Client_ID = long.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Введите ваше имя: ");
                                client.Client_Name = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(client.Client_Name))
                                {
                                    Console.WriteLine("Введите ваше имя ещё раз");
                                    client.Client_Name = Console.ReadLine();
                                }

                                Console.WriteLine("Введите ваш возраст (полных лет): ");
                                client.Client_Age = int.Parse(Console.ReadLine());
                                while (client.Client_Age > 150 || client.Client_Age < 18)
                                {
                                    if (client.Client_Age < 18)
                                    {
                                        Console.WriteLine("Вы не достигли 18 лет ");
                                    }
                                    Console.WriteLine("Введите ваш возраст ещё раз: ");
                                    client.Client_Age = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Введите ваш гендер 1) мужчина, 2) женщина ");
                                client.Int_Client_Gender = int.Parse(Console.ReadLine());// от введённого числа зависит гендер
                                if (client.Int_Client_Gender == 1)
                                {
                                    client.Str_Client_Gender = "мужчина";
                                }
                                else if (client.Int_Client_Gender == 2)
                                {
                                    client.Str_Client_Gender = "женщина";
                                }

                                while (client.Int_Client_Gender != 1 && client.Int_Client_Gender != 2)
                                {
                                    Console.WriteLine("Введите ваш гендер ешё раз 1) мужчина, 2) женщина ");
                                    client.Int_Client_Gender = int.Parse(Console.ReadLine());// от введённого числа зависит гендер
                                }
                                Console.WriteLine();

                                StreamWriter SW = new StreamWriter("Data.txt", false);

                                SW.WriteLine(client.Client_ID.ToString());
                                SW.WriteLine(client.Client_Name.ToString());
                                SW.WriteLine(client.Client_Age.ToString());
                                SW.WriteLine(client.Str_Client_Gender.ToString());
                                SW.Close();

                                Console.WriteLine("Готово");

                            }
                        }
                    }
                    else if (Byte_Register == 2)
                    {
                        CheckCycle = true;
                        Bool_Register = false;

                        Console.WriteLine("Введите ваш ID: 16 чисел ");
                        client.Client_ID = long.Parse(Console.ReadLine());

                        while (client.Client_ID > 10000000000000000 || client.Client_ID < 1000000000000000)
                        {
                            Console.WriteLine("Введите ID ещё раз: ");
                            client.Client_ID = long.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Введите ваше имя: ");
                        client.Client_Name = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(client.Client_Name))
                        {
                            Console.WriteLine("Введите ваше имя ещё раз");
                            client.Client_Name = Console.ReadLine();
                        }

                        Console.WriteLine("Введите ваш возраст (полных лет): ");
                        client.Client_Age = int.Parse(Console.ReadLine());
                        while (client.Client_Age > 150 || client.Client_Age < 18)
                        {
                            if (client.Client_Age < 18)
                            {
                                Console.WriteLine("Вы не достигли 18 лет ");
                            }
                            Console.WriteLine("Введите ваш возраст ещё раз: ");
                            client.Client_Age = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Введите ваш гендер 1) мужчина, 2) женщина ");
                        client.Int_Client_Gender = int.Parse(Console.ReadLine());// от введённого числа зависит гендер
                        if (client.Int_Client_Gender == 1)
                        {
                            client.Str_Client_Gender = "мужчина";
                        }
                        else if (client.Int_Client_Gender == 2)
                        {
                            client.Str_Client_Gender = "женщина";
                        }

                        while (client.Int_Client_Gender != 1 && client.Int_Client_Gender != 2)
                        {
                            Console.WriteLine("Введите ваш гендер ешё раз 1) мужчина, 2) женщина ");
                            client.Int_Client_Gender = int.Parse(Console.ReadLine());// от введённого числа зависит гендер
                        }
                        Console.WriteLine();

                        StreamWriter SW = new StreamWriter("Data.txt", false);

                        SW.WriteLine(client.Client_ID.ToString());
                        SW.WriteLine(client.Client_Name.ToString());
                        SW.WriteLine(client.Client_Age.ToString());
                        SW.WriteLine(client.Str_Client_Gender.ToString());
                        SW.Close();

                        Console.WriteLine("Готово");
                    }
                    else
                    {
                        CheckCycle = false;
                        Console.WriteLine("Введите ещё раз 1) да  2) нет ");
                        Byte_Register = int.Parse(Console.ReadLine());
                    }
                }
            }

            void Actions()
            {
                while (true)
                {
                    Console.WriteLine("Выберете действие: 1) Транзакция  2) Сменить аккаунт 3) Вклад 4) Кредит 5) Добавить банковскую карту 6) Отвязать банковскую карту 7) Сменить пин-код 8) информация о картах 9) Очистить консоль ");

                    int type = int.Parse(Console.ReadLine());
                    while (type != 1 || type != 2 || type != 3 || type != 4 || type != 5 || type != 6 || type != 7 || type != 8 || type != 9)
                    {
                        switch (type)
                        {
                            case 1:
                                {
                                    Transfer();
                                    break;
                                }
                            case 2:
                                {
                                    Register_Check();
                                    Actions();
                                    break;
                                }
                            case 3:
                                {
                                    Contribution();
                                    break;
                                }
                            case 4:
                                {
                                    Credit();
                                    break;
                                }
                            case 5:
                                {
                                    CreateBank_Card();
                                    break;
                                }
                            case 6:
                                {
                                    DeleteBank_Card();
                                    break;
                                }
                            case 7:
                                {
                                    NewPinCode();
                                    break;
                                }
                            case 8:
                                {
                                    Card_Info();
                                    break;
                                }
                            case 9:
                                {
                                    Console.Clear();
                                    Actions();
                                    break;
                                }
                            default:
                                {

                                    Console.WriteLine("Действие выбрано не правильно, введите ещё раз");
                                    type = int.Parse(Console.ReadLine());
                                    Actions();
                                    break;
                                }
                        }
                    }
                }
            }

            void Transfer()
            {
                if (List_Cards.Count < 1)
                {
                    Console.WriteLine("У вас не привязано не единой карты");
                    Actions();
                }
                else
                {
                    Transfer tr = new Transfer();

                    tr.Transfer_ID = random.Next(0, 10000000);
                    StreamWriter Sw = new StreamWriter($"TransferHistory{tr.Transfer_ID}.txt", false);

                    TestPinCode();

                    Console.WriteLine("Введите тип опериции 1) пополнение 2) списывание");
                    tr.TypeOfTransfer = int.Parse(Console.ReadLine());

                    if (tr.TypeOfTransfer == 1)
                    {
                        Console.WriteLine("Введите сумму транзакции");
                        tr.Transfer_Money = decimal.Parse(Console.ReadLine());
                        while (tr.Transfer_Money < 0)
                        {
                            Console.WriteLine("Введите сумму заново");
                            tr.Transfer_Money = decimal.Parse(Console.ReadLine());
                        }

                        if (tr.Transfer_Money < 1000)
                        {
                            bank.Bank_Percent = 30;
                        }
                        else if (tr.Transfer_Money > 1000)
                        {
                            bank.Bank_Percent = tr.Transfer_Money * 0.05m;
                        }
                        else
                        {
                            bank.Bank_Percent = tr.Transfer_Money * 0.04m;
                        }

                        check.Check_Money = check.Check_Money + tr.Transfer_Money - bank.Bank_Percent;
                        bank.Bank_Money = bank.Bank_Money - tr.Transfer_Money + bank.Bank_Percent;

                        Console.WriteLine($"Вы пополнили счёт на {tr.Transfer_Money} и комиссия {bank.Bank_Percent}");
                        Console.WriteLine($"На вашем счету {check.Check_Money}");

                        Sw.WriteLine(tr.Transfer_ID.ToString());
                        Sw.WriteLine(tr.TypeOfTransfer.ToString());
                        Sw.WriteLine(tr.Transfer_Money.ToString());
                        Sw.Close();

                        Actions();
                    }
                    else if (tr.TypeOfTransfer == 2)
                    {
                        Console.WriteLine("Введите сумму транзакции");
                        tr.Transfer_Money = decimal.Parse(Console.ReadLine());
                        while (tr.Transfer_Money < 0 || tr.Transfer_Money > check.Check_Money)
                        {
                            Console.WriteLine("Введите сумму заново");
                            tr.Transfer_Money = decimal.Parse(Console.ReadLine());
                        }
                        if (tr.Transfer_Money < 1000)
                        {
                            bank.Bank_Percent = 30;
                        }
                        else if (tr.Transfer_Money > 1000)
                        {
                            bank.Bank_Percent = tr.Transfer_Money * 0.05m;
                        }
                        else
                        {
                            bank.Bank_Percent = tr.Transfer_Money * 0.04m;
                        }

                        check.Check_Money = check.Check_Money - tr.Transfer_Money + bank.Bank_Percent;
                        bank.Bank_Money = bank.Bank_Money + tr.Transfer_Money + bank.Bank_Percent;

                        Console.WriteLine($"Вы списали денег на сумму {tr.Transfer_Money} комиссия {bank.Bank_Percent}");
                        Console.WriteLine($"На вашем счету {check.Check_Money}");

                        Sw.WriteLine(tr.Transfer_ID.ToString());
                        Sw.WriteLine(tr.TypeOfTransfer.ToString());
                        Sw.WriteLine(tr.Transfer_Money.ToString());
                        Sw.Close();

                        Actions();
                    }
                    else
                    {
                        Transfer();
                    }
                }


            }

            void Contribution()
            {
                Contribution Cont = new Contribution();

                Console.WriteLine("Введите сумму вклада: ");
                Cont.Cont_Money = decimal.Parse(Console.ReadLine());
                while (check.Check_Money < Cont.Cont_Money || Cont.Cont_Money < 0)
                {
                    Console.WriteLine("Введите сумму вклада ещё раз :");
                    Cont.Cont_Money = decimal.Parse(Console.ReadLine());
                }

                Console.WriteLine("Введите время в годах");
                Cont.Cont_Time = int.Parse(Console.ReadLine());
                while (Cont.Cont_Time < 0 || Cont.Cont_Time > 50)
                {
                    Console.WriteLine("Введите время ещё раз");
                    Cont.Cont_Time = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Введите проценты годовых");
                Cont.Cont_percent = int.Parse(Console.ReadLine());
                while (Cont.Cont_percent < 0 || Cont.Cont_percent > 100)
                {
                    Console.WriteLine("Введите проценты ещё раз");
                    Cont.Cont_percent = int.Parse(Console.ReadLine());
                }

                Cont.Cont_pay = Cont.Cont_Money * Cont.Cont_percent * Cont.Cont_Time / 100;

                Console.WriteLine($"По истечению срока вклада вы получите  {Cont.Cont_pay}");

                check.Check_Money = check.Check_Money + Cont.Cont_pay;

                Console.WriteLine($"На вашем счету {check.Check_Money}");
                Cont.Cont_ID = random.Next(0, 10000000);

                StreamWriter Sw = new StreamWriter($"ContributionHistory{Cont.Cont_ID}.txt", false);

                Sw.WriteLine(Cont.Cont_ID.ToString());
                Sw.WriteLine(Cont.Cont_Money.ToString());
                Sw.WriteLine(Cont.Cont_percent.ToString());
                Sw.WriteLine(Cont.Cont_Time.ToString());
                Sw.WriteLine(Cont.Cont_pay.ToString());
                Sw.Close();

                Actions();
            }

            void Credit()
            {
                Credit Cr = new Credit();

                Console.WriteLine("Введите сумму кредита ");
                Cr.Cr_Money = decimal.Parse(Console.ReadLine());

                check.Check_Money = check.Check_Money + Cr.Cr_Money;
                Console.WriteLine($"У вас будет {check.Check_Money} ");


                Console.WriteLine("Введите процент по кредиту ");
                Cr.Cr_percent = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите время на выплату кредита в месяцах ");
                Cr.Cr_Time = int.Parse(Console.ReadLine());

                Cr.Cr_Pay = ((Cr.Cr_Money * Cr.Cr_percent * 30 / 366 / 100)) + (Cr.Cr_Money / Cr.Cr_Time);
                Console.WriteLine($"Вы должны выплачивать примерно по {decimal.Round(Cr.Cr_Pay)} в месяц");
                Console.WriteLine("Всего вы выплатите около ");
                Console.WriteLine(decimal.Round(Cr.Cr_Pay + Cr.Cr_Money));

                bank.Bank_Money = bank.Bank_Money + Cr.Cr_Money + Cr.Cr_Pay;

                check.Check_Money = check.Check_Money - Cr.Cr_Money + Cr.Cr_Pay;
                Console.WriteLine($"У вас будет {decimal.Round(check.Check_Money)} ");

                Cr.Cr_ID = random.Next(1, 10000000);
                StreamWriter Sw = new StreamWriter($"ContributionHistory{Cr.Cr_ID}.txt", false);

                Sw.WriteLine(Cr.Cr_ID.ToString());
                Sw.WriteLine(Cr.Cr_Money.ToString());
                Sw.WriteLine(Cr.Cr_percent.ToString());
                Sw.WriteLine(Cr.Cr_Time.ToString());
                Sw.WriteLine(Cr.Cr_Pay.ToString());
                Sw.Close();
                Actions();
            }

            void CreateBank_Card()
            {
                int a = 0;

                List_Cards.Add(Card);
                List_Cards[a] = Card;

                Console.WriteLine("У вас есть зарегистрированная карта ?  1) да 2) нет ");
                CardAvaible.Int_Availabilityearlier = int.Parse(Console.ReadLine());
                while (CardAvaible.Int_Availabilityearlier > 2 || CardAvaible.Int_Availabilityearlier <= 0)
                {
                    if (CardAvaible.Int_Availabilityearlier == 1)
                    {
                        CardAvaible.Bool_Availabilityearlier = true;

                        bool v = File.Exists($"CardRegist.txt");

                        if (v == true)
                        {
                            string[] linev = File.ReadAllLines($"CardRegist.txt");
                            Card.Card_serial_number = int.Parse(linev[0]);
                            Card.Card_Number = long.Parse(linev[1]);
                            Card.Card_Name = linev[2];
                            Card.Card_Pin_Code = int.Parse(linev[3]);
                        }
                    }
                    else if (CardAvaible.Int_Availabilityearlier == 2)
                    {

                        CardAvaible.Bool_Availabilityearlier = false;

                    }
                    else
                    {
                        Console.WriteLine("Введите ещё раз у вас есть зарегистрированные карты ?  1) да 2) нет ");
                        CardAvaible.Int_Availabilityearlier = int.Parse(Console.ReadLine());
                    }

                    /*
                     *  StreamReader srv = new StreamReader("CheckID.txt");
                    string[] linev = File.ReadAllLines("CheckID.txt");
                    check.Check_ID = long.Parse(linev[0]);
                    Console.WriteLine(check.Check_ID.ToString());
                    check.Check_Money = decimal.Parse(linev[1]);

                     *  Swr.WriteLine(Card.Card_serial_number.ToString());
                Swr.WriteLine(Card.Card_Number.ToString());
                Swr.WriteLine(Card.Card_Name.ToString());
                Swr.WriteLine(Card.Card_Pin_Code.ToString());
                Swr.Close();
                      */
                }

                if (CardAvaible.Int_Availabilityearlier == 1)
                {
                    CardAvaible.Bool_Availabilityearlier = true;

                    Card.Card_serial_number = int.Parse(linev[0]);
                    Card.Card_Number = long.Parse(linev[1]);
                    Card.Card_Name = linev[2];
                    Card.Card_Pin_Code = int.Parse(linev[3]);

                }
                else if (CardAvaible.Int_Availabilityearlier == 2)
                {

                    CardAvaible.Bool_Availabilityearlier = false;

                    Console.WriteLine("Введите название карты");
                    Card.Card_Name = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(Card.Card_Name))
                    {
                        Console.WriteLine("Введите название карты ещё раз ");
                        Card.Card_Name = Console.ReadLine();
                    }

                    Console.WriteLine("Введите номер карты");
                    Card.Card_Number = long.Parse(Console.ReadLine());
                    while (Card.Card_Number > 10000000000000000 || Card.Card_Number < 1000000000000000)
                    {
                        Console.WriteLine("Введите номер ещё раз: ");
                        Card.Card_Number = long.Parse(Console.ReadLine());
                    }

                    a++;
                    Card.Card_serial_number = a;

                    Console.WriteLine("Введите новый пин-код ");
                    Card.Card_Pin_Code = int.Parse(Console.ReadLine());
                    while (Card.Card_Pin_Code > 9999 || Card.Card_Pin_Code < 1000)
                    {
                        Console.WriteLine("Введите новый пин-код ");
                        Card.Card_Pin_Code = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("Подтвердите пин-код");
                    int CheckPinCode = int.Parse(Console.ReadLine());

                    StreamWriter Swr = new StreamWriter($"CardRegist.txt");
                    Swr.WriteLine(Card.Card_serial_number.ToString());
                    Swr.WriteLine(Card.Card_Number.ToString());
                    Swr.WriteLine(Card.Card_Name.ToString());
                    Swr.WriteLine(Card.Card_Pin_Code.ToString());
                    Swr.Close();



                    Actions();

                }
                else
                {
                    Console.WriteLine("Введите ещё раз у вас есть зарегистрированные карты ?  1) да 2) нет ");
                    CardAvaible.Int_Availabilityearlier = int.Parse(Console.ReadLine());
                }

            }

            void DeleteBank_Card()
            {
                Console.WriteLine("Введите порядковый номер карты для удаления ");
                x = int.Parse((Console.ReadLine()));
                if (List_Cards.Count > 1)
                {
                    Console.WriteLine("У вас нет карт для удаления ");
                }

                List_Cards.Remove(List_Cards[--x]);

                Actions();
            }

            void NewPinCode()
            {

                Console.WriteLine("Введите новый пин-код ");
                Card.Card_Pin_Code = int.Parse(Console.ReadLine());
                while (Card.Card_Pin_Code > 9999 || Card.Card_Pin_Code < 1000)
                {
                    Console.WriteLine("Введите новый пин-код ");
                    Card.Card_Pin_Code = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Подтвердите пин-код");
                int CheckPinCode = int.Parse(Console.ReadLine());
                if (CheckPinCode != Card.Card_Pin_Code)
                {
                    Console.WriteLine("Пин-коды не совпадают");

                    Actions();
                }
                linev[3] = Card.Card_Pin_Code.ToString();

                Console.WriteLine("Пин-код изменён");
                Actions();
            }

            void TestPinCode()
            {
                Console.WriteLine("Введите пин-код");
                int CheckPinCode = int.Parse(Console.ReadLine());
                if (CheckPinCode != Card.Card_Pin_Code)
                {
                    Console.WriteLine("Пин-коды не совпадают");
                    NewPinCode();
                    Actions();
                }

            }

            void Card_Info()
            {

                for (int x = 0; x < List_Cards.Count; x++)
                {

                    Bank_Card c = List_Cards[x];
                    Console.WriteLine();
                    Console.WriteLine(c.Card_serial_number.ToString());
                    Console.WriteLine(c.Card_Name.ToString());
                    Console.WriteLine(c.Card_Number.ToString());
                    Console.WriteLine(c.Card_Pin_Code.ToString());
                    Console.WriteLine();

                }

                Actions();

            }

            void AccountIDverification()
            {
                bool u = File.Exists("CheckID.txt");


                Console.WriteLine("У вас зарегистрирован счёт ? 1) да 2) нет ");
                check.Int_Register = int.Parse(Console.ReadLine());
                while (check.Int_Register > 2 || check.Int_Register <= 0)
                {
                    if (check.Int_Register == 1)
                    {
                        check.Bool_Register = true;
                    }
                    else if (check.Int_Register == 2)
                    {
                        check.Bool_Register = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите ещё раз у вас зарегистрирован счёт ? 1) да 2) нет ");
                        check.Int_Register = int.Parse(Console.ReadLine());
                    }
                }

                if (check.Int_Register == 1)
                {
                    check.Bool_Register = true;
                }
                else if (check.Int_Register == 2)
                {
                    check.Bool_Register = false;
                }

                if (check.Bool_Register == true)
                {
                    //считывать
                    StreamReader srv = new StreamReader("CheckID.txt");
                    string[] linev = File.ReadAllLines("CheckID.txt");
                    check.Check_ID = long.Parse(linev[0]);
                    Console.WriteLine(check.Check_ID.ToString());
                    check.Check_Money = decimal.Parse(linev[1]);
                }
                else if (check.Bool_Register == false)
                {
                    StreamWriter SWv = new StreamWriter("CheckID.txt");
                    Console.WriteLine("Введите ID счёта, 10 цифр ");
                    check.Check_ID = long.Parse(Console.ReadLine());
                    while (check.Check_ID >= 10000000000 || check.Check_ID < 1000000000)
                    {
                        Console.WriteLine("Введите ID счёта ещё раз");
                        check.Check_ID = long.Parse(Console.ReadLine());

                    }
                    Console.WriteLine("Введите количество денег на вашем счету");
                    check.Check_Money = long.Parse(Console.ReadLine());
                    while (check.Check_Money < 0)
                    {
                        Console.WriteLine("На вашем счету не может быть меньше 0 ");
                    }
                    SWv.WriteLine(check.Check_ID.ToString());
                    SWv.WriteLine(check.Check_Money.ToString());
                    SWv.Close();

                }
            }
        }
    }
}

