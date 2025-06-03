
using System.Globalization;
using System.Numerics;

namespace ViolationsRecording.Infrastructure;


// Простейшая защита - выброс исключения при срабатывании условия,
// возврат передаваемого значения при несрабатывании условия
public static class Guard
{
	
	public static class Against {

		// проверка строки на пустоту
		public static string EmptyString (string value, string errMsg) => string.IsNullOrWhiteSpace(value)
			? throw new ArgumentException(errMsg)
			: value;


        // Проверка, является ли строка числом типа Int 
        public static int IsInt(string input, string errMsg) =>
            int.TryParse(input, out var result) 
                ? result
                : throw new Exception(errMsg);

        // Проверка, является ли строка числом типа Int 
        public static double IsDouble(string input, string errMsg) =>
            double.TryParse(input, CultureInfo.CurrentCulture, out var result)
                ? result
                : throw new Exception(errMsg);


        // проверка числового значения на отрицательность или равенство нулю
        public static T NegativeOrZero<T>(T value, string errMsg) where T: INumber<T>, IComparable<T> => 
            value.CompareTo(default) <= 0 
            ? throw new ArgumentException(errMsg)
            : value;


        // проверка числового значения на отрицательность
        public static T Negative<T>(T value, string errMsg) where T: INumber<T>, IComparable<T> => 
            value.CompareTo(default) < 0 
            ? throw new ArgumentException(errMsg)
            : value;


		// защита от значения value меньше некоторого значения bound
		public static T LessThan<T>(T value, T bound, string errMsg) where T: IComparable<T> => 
            value.CompareTo(bound) < 0
			? throw new ArgumentException(errMsg)
			: value;        


        // защита от значения value больше некоторого значения bound
        public static T GreaterThan<T>(T value, T bound, string errMsg) where T: IComparable<T> => 
            value.CompareTo(bound) > 0
			? throw new ArgumentException(errMsg)
			: value;

        // защита от значения value, не входящего в интервал [lo, hi]
        public static T NotInRange<T>(T value, T lo, T hi, string errMsg) where T : IComparable<T> =>
            value.CompareTo(lo) < 0 || value.CompareTo(hi) > 0
                ? throw new ArgumentException(errMsg)
                : value;

        // если значение переменной null - выбрасываем исключение
        public static T Null<T>(T value, string errMessage) =>
            value?? throw new ArgumentException(errMessage);

    } // class Against
} // class Guards
