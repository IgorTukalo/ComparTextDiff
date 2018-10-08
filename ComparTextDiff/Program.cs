using System;
using System.Linq;
using System.Text;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace ComparTextDiff
{
    class Program
    {
        private static string FinalText = string.Empty;

        private static string OldText =
    @"                             №  20              длиной        ~      52  м              в  г/т  25/19        длиной      ~      2  м
 -      1  шт.                                              №  21              длиной        ~      49  м              в  г/т
 25/19        длиной      ~      2  м                                        -      1  шт.                                №  22              длиной
 ~      46  м              в  г/т  25/19        длиной      ~      2  м                                        -      1  шт.
                             №  23              длиной        ~      43  м              в  г/т
 25/19        длиной      ~      2  м                                        -      1  шт.                                  №  25              длиной
 ~      41  м              в  г/т  25/19        длиной      ~      2  м                                        -      1  шт.    
 №  30              длиной        ~      45  м                          -      1  шт..                            №  86              длиной
 ~      40  м                          -      1  шт.                                №  89              длиной        ~      35  м
 -    1  шт..                                          Порядок      заготовки    кабелей:        1.    Подготовить    комплект    материалов
 согласно    чертежу    и    транспортировать  на    рабочее    место    вручную.          2.      Установить      бухту      на      приспособление
 для      размотки      кабеля.              3.    Отмотать  с    бухты  (барабана)    кабель  требуемой    длины,  отметить    место    реза.  Отрезать
 кабель.            4.    Отмерить,    отрезать    гофротрубу      полипропиленовую    с    металлической    протяжкой    внутри          5.
 Завести    кабель    в    гофротрубу      с    помощью    металлической    протяжки                    Примечание.                  Пункты  4  и  5
 для    кабелей    с  номерами      вводов    30,  86  и  89    не  выполнять.                  6.    Смотать    предварительно    кабель    в    бухту,
 увязать    в    3-х    местах    обрезками    проводов          7.    Снять    с      приспособления      бухту      кабеля      и    транспортировать
 к      рабочему      месту.        8.      Поочередно      с    двух    сторон    кабеля      отмерить,      разрезать    и    снять    оболочку
 на    требуемой    длине              9.    Произвести      разделку    концов    кабеля,      сняв      изоляцию    с    жил    на    длине    20..22
 мм    10.    Заготовить    бирки    из    трубки      305  белой,    первого    сорта    ГОСТ  19034-82    длиной    25-5  мм    
 Нанести    маркировку    на    бирки    согласно    схеме  краской      ВИКА  черной    НПО  028.000    шрифтом    4-Пр3            ГОСТ  26.020-80.
 11.    Маркировать,    предварительно    прозвонив,      жилы    соответствующими      маркировочными    трубками      12.    Завернуть    кольца
 согласно    схеме.
";

        private static string NewText =
            @"                             №  20              длиной        ~      54  м              в  г/т  25/19        длиной      ~    2  м
 -      1  шт.                                              №  21              длиной        ~      51  м              в  г/т  25/19        длиной
 ~    2  м                    -      1  шт.                                №  22              длиной        ~      48  м              в  г/т  25/19
 длиной      ~    2  м                    -      1  шт.                                                                                      
 №  23              длиной        ~      45  м              в  г/т  25/19        длиной      ~    2  м                    -      1  шт.
                             №  25              длиной        ~      41  м              в  г/т  25/19        длиной      ~      2  м                  -
 1  шт.                                №  30         testtt      длиной        ~      45  м                          -      1  шт..
 №  86              длиной        ~      40  м                          -      1  шт.                                №  89              длиной
 ~      35  м                          -    1  шт...                                          Порядок      заготовки    кабелей:        1.
 Подготовить    комплект    материалов      согласно    чертежу    и    транспортировать  на    рабочее    место    вручную.          2.      Установить
 бухту      на      приспособление    для      размотки      кабеля.              3.    Отмотать  с    бухты  (барабана)    кабель  требуемой
 длины,  отметить    место    реза.  Отрезать    кабель.            4.    Отмерить,    отрезать    гофротрубу      полипропиленовую    с    металлической
 протяжкой    внутри          5.    Завести    кабель    в    гофротрубу      с    помощью    металлической    протяжки    
 Примечание.                  Пункты  4  и  5    для    кабелей    с  номерами      вводов    30,  86  и  89    не  выполнять.                  6.
 Смотать    предварительно    кабель    в    бухту,    увязать    в    3-х    местах    обрезками    проводов          7.    Снять    с
 приспособления      бухту      кабеля      и    транспортировать      к      рабочему      месту.        8.      Поочередно      с    двух    сторон
 кабеля      отмерить,      разрезать    и    снять    оболочку    на    требуемой    длине              9.    Произвести      разделку    концов
 кабеля,      сняв      изоляцию    с    жил    на    длине    20..22  мм    10.    Заготовить    бирки    из    трубки      305  белой,    первого
 сорта    ГОСТ  19034-82    длиной    25-5  мм                    Нанести    маркировку    на    бирки    согласно    схеме  краской      ВИКА  черной
 НПО  028.000    шрифтом    4-Пр3            ГОСТ  26.020-80.  11.    Маркировать,    предварительно    прозвонив,      жилы    соответствующими
 маркировочными    трубками      12.    Завернуть    кольца    согласно    схеме. terst testtt
";

        private static void Main(string[] args)
        {
            OldText = CorrectWordnewLine(CorrectInLine(CorrectSpace(OldText)));
            NewText = CorrectWordnewLine(CorrectInLine(CorrectSpace(NewText)));

            var diffBuilder = new InlineDiffBuilder(new Differ());
            var diff = diffBuilder.BuildDiffModel(OldText, NewText);

            foreach (var line in diff.Lines)
            {
                switch (line.Type)
                {
                    case ChangeType.Inserted:
                        FinalText += " {" + line.Text + "}";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+ ");
                        break;
                    case ChangeType.Deleted:
                        FinalText += " <" + line.Text + ">";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("- ");
                        break;
                    default:
                        FinalText += " " + line.Text;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        break;
                }
                Console.WriteLine(line.Text);
            }
            Console.WriteLine(CorrectSpace(FinalText).Replace("} {", " ").Replace("> <"," ").Replace("<>","").Replace("{}",""));
            Console.ReadKey();
        }

        /// <summary>
        /// Убрать подряд идущие пробелы
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns></returns>
        private static string CorrectSpace(string s)
        {
            string z = "";
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
                try
                {
                    if (s[i] == ' ')
                    {
                        if (z[z.Length - 1] != ' ')
                            z += ' ';
                    }
                    else
                        z += s[i];
                }
                catch (Exception e) { Console.WriteLine(e); }
            s = z;
            return s;
        }

        /// <summary>
        /// Сделать все символы в одну строку
        /// </summary>
        /// <param name="oldString">Строка</param>
        /// <returns></returns>
        private static string CorrectInLine(string oldString)
        {
            //            oldString = @"Слоны, жирафы 
            //    и что-то там ещё...
            //Ну и ещё строчку...";
            char[] denied = new[] { '\n', '\t', '\r' };
            StringBuilder newString = new StringBuilder();
            foreach (var ch in oldString)
                if (!denied.Contains(ch))
                    newString.Append(ch);
            return newString.ToString();
        }

        /// <summary>
        /// Перенести все слова на отдельную строку
        /// </summary>
        /// <param name="oldString">Строка</param>
        /// <returns></returns>
        private static string CorrectWordnewLine(string oldString)
        {
            return oldString.Replace(' ', '\r');
        }
    }
}
