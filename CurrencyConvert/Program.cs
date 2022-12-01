string[,] currency = new string[,]
{
{"Код", "Наименование валюты"},
{"---", "--------------------"},
{"rub", "Российский рубль"},
{"usd", "Доллар США"},
{"eur", "Евро"},
{"chf", "Швейцарский франк"},
{"gbp", "Фунт стерлингов"},
{"jpy", "Японская йена"},
};

string[,] converter = new string[,]
{
{"", "rub", "usd", "eur", "chf", "gbp", "jpy"},
{"rub", "1", "0,016", "0,016", "0,016", "0,014", "2,27"},
{"usd", "61,07", "1", "0,96", "0,95", "0,83", "138,58"},
{"eur", "63,39", "1,04", "1", "0,99", "0,86", "143,36"},
{"chf", "64,16", "1,05", "1,01", "1", "0,87", "145,64"},
{"gbp", "73,53", "1,2", "1,16", "1,15", "1", "166,91"},
{"jpy", "0,44", "0,007", "0,007", "0,007", "0,006", "1"},
};

Console.WriteLine("Добро пожаловать в конвертер валют!");
Console.WriteLine("Для конвертирвания валюты введите convert");
Console.WriteLine("Для вывода списка, доступных для конвертации валют, наберите list");
Console.WriteLine("Для выхода из программы наберите exit");


string comExit = "exit";
string comConv = "convert";
string comList = "list";


while (true)
{
    string userCode = ReadStr("Введите команду: ");
    bool a = true;

    if (userCode.ToLower() == comExit)
    {
        Console.WriteLine("Спасибо, что выбрали наш конвертер. Рады будем видеть снова!");
        break;
    }

    if (userCode.ToLower() == comList)
    {
        a = false;
        PrintArray(currency);
    }

    if (userCode.ToLower() == comConv)
    {
        a = false;
        while (true)
        {
            bool b = true;
            int x = 0;
            int y = 0;
            double k = 0;

            string firstCurrent = ReadStr("Введите код валюты для конвертации: ");
            for (int i = 0; i < converter.GetLength(0); i++)
            {
                if (firstCurrent == converter[i, 0])
                {
                    y = i;
                    b = false;
                }
            }
            if (b)
            {
                Console.WriteLine("Вы ввели неверный код валюты!");
                b = true;
                break;
            }

            double firstValue = ReadDouble("Введите сумму: ");
            string secondCurrent = ReadStr("Введите код валюты, в которую нужно конвертировать: ");

            for (int i = 0; i < converter.GetLength(1); i++)
            {
                if (secondCurrent == converter[0, i])
                {
                    x = i;
                    b = false;
                }
            }
            if (b)
            {
                Console.WriteLine("Вы ввели неверный код валюты!");
                break;
            }
            k = Convert.ToDouble(converter[y, x]);
            Console.WriteLine($"{firstValue} {firstCurrent} эквивалентно {firstValue * k} {secondCurrent}");
            break;


        }

    }

    if (a)
    {
        Console.WriteLine("Вы ввели неверную команду!");
    }
}

string ReadStr(string msg)
{
    Console.Write(msg);
    return Console.ReadLine();
}

double ReadDouble(string msg)
{
    Console.Write(msg);
    return Convert.ToDouble(Console.ReadLine());
}

void PrintArray(string[,] matr)
{
    Console.WriteLine();
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]}    ");
        }
        Console.WriteLine();
    }
}