/*Программа с реализацией РЕГИСТРАЦИИ, АВТОРИЗАЦИИ
 * ВЫВОДОМ информации о пользователе.
 * 
 * 
 */


using System;

class USER // класс Пользователь, имеет 3 переменные, функции: создания нового объекта путем ввода в консоль,
    //        вывод данных о пользователе с использованием скрытия пароля под '*'
    //        возврат значений заданных членов -классов;
{
    private int id = -1;
    private string name = "";
    private string password = "";

    public void create_new(int a) // инициализация нового пользователя;
    {
        Console.WriteLine("Введите ваш логин и пароль: ");
        Console.Write("Логин: ");
        name = Convert.ToString(Console.ReadLine());
        Console.Write("Пароль: ");
        password = readonly_pass(password);
        id = a;
    }
    public void create_new() // инициализация нового пользователя;
    {
        Console.WriteLine("Введите ваш логин и пароль: ");
        Console.Write("Логин: ");
        name = Convert.ToString(Console.ReadLine());
        Console.Write("Пароль: ");
        password = readonly_pass(password);
    }

    public void out_inf() // вывод информации о пользователе;
    {
        Console.WriteLine(id);
        Console.WriteLine(name);
        Console.WriteLine(password) ;
    }

    private string readonly_pass(string a) // Ввод и скрытие при вводе пароля
    {
        while(true)
        {
            ConsoleKeyInfo i = Console.ReadKey(true);
            if (i.Key == ConsoleKey.Enter) {
                Console.Write('\n');
                break;
            } else if (i.Key == ConsoleKey.Backspace) {
                a = a.Remove(a.Length - 1);
                Console.Write("\b \b");
            } else {
                a += i.KeyChar;
                Console.Write("*");
            }
        }
        return a;
    }

    public string rtrn_name()
    {
        return name;
    }
    public string rtrn_pass()
    {
        return password;
    }
    public int watch_id()
    {
        return id;
    }
}



class Registering
{
    static void registretion(USER[] arg, int id) // регистрирует новый объект заданного массива, выводит о нем информацию
    {
        arg[id] = new USER();
        arg[id].create_new(id);
        arg[id].out_inf();
    }

    static int avtorization(USER[] bufu,int id) // запрашивает данные(логин и пароль) и вводит их в временный объект, сверяет эти данные временного объекта с существующими объектами
    {
        USER temp = new USER();
        temp.create_new();
        int false_id = -1;
        for(bool res = true; res != false;)
        {
            for(int i = 0; i == 0 || i < id; i++)
            {
                string tmpstr = bufu[i].rtrn_name();
                string tmppass = bufu[i].rtrn_pass();
                if(tmpstr.Equals(temp.rtrn_name()))
                {
                    if (tmppass.Equals(temp.rtrn_pass()))
                    {
                        Console.WriteLine("Добро пожаловать!");
                        Console.WriteLine("Вы вошли как " + bufu[i].watch_id());
                        return bufu[i].watch_id();
                    }
                }
            }
            res = false;
        }
        return false_id;
    }
    static int choice(USER[] buf, int id) // функция меню. Реализует основную часть программы, выбор между регистрацией и авторизацией
    {
        A:
        int voice = 0;
        Console.Write("Меню:\n Выберите пункт:\n 1)Регистрация нового пользователя\n 2)Авторизация" );
        voice = Convert.ToInt32(Console.ReadLine());
        switch (voice)
        {
            case 1:
                {
                    Console.WriteLine("Вы выбрали Регистраци нового пользователя!");
                    registretion(buf, id);
                    if (id <= 9)
                        return id + 1;
                    else
                        return -1;
                }
            case 2:
                {
                    Console.WriteLine("Вы выбрали АВТОРИЗАЦИЯ!");
                    int a = avtorization(buf, id);
                    if(a == - 1)
                    {
                        Console.WriteLine("Логин или пароль не верны!");
                    }
                    return id;
                }
            default:
                {
                    Console.WriteLine("Попробуйте снова");
                    goto A;
                }
        }

    }


    static void Main()
    {
        int id = 0; // текущее состояние массива, сколько объектов существует
        USER[] all_user = new USER[10];
        while (id != -1 && id <= 10) 
        {
            id = choice(all_user, id);
            Console.WriteLine("next step " + id);
        }


        Console.ReadKey();
    }


}