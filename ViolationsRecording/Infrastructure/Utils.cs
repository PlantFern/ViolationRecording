using System.Globalization;

namespace ViolationsRecording.Infrastructure;

// вспомогательные методы и объекты - статический класс, т.е. класс,
// содержащий только статические члены и методы
public static class Utils
{
    public static string Format = "dd.MM.yyyy";

    public static string NormalizeDecimalSeparator(string input)=>
        input.Replace(',', '.');

    // формирование случайных вещественных чисел в диапазоне от lo до hi
    public static double GetRandom(double lo, double hi)
        => lo + (hi - lo)*Random.Shared.NextDouble();

    // формирование случайных целых чисел в заданном диапазоне (lo, hi),
    public static int GetRandom(int lo, int hi) => Random.Shared.Next(lo, hi + 1);

   
    // перемешивание коллекции по алгоритму "Тасование Фишера-Йетса"
    // https://vscode.ru/prog-lessons/kak-peremeshat-massiv-ili-spisok.html
    public static void Shuffle<T>(List<T> data) {
        // просматриваем массив с конца
        for (int i = data.Count - 1; i >= 1; i--) {

            // определяем элемент, с которым меняем элемент с индексами i
            int j = GetRandom(0, i);

            // меняем местами элементы коллекции при помощи кортежа
            (data[i], data[j]) = (data[j], data[i]);
        } // for i
    } // Shuffle 

} // class Utils
