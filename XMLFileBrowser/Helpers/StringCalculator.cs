using System;
using System.Data;

namespace XMLFileBrowser.Helpers
{
    /// <summary>
    /// Рассчитывает числовые выражения в типе данных string
    /// </summary>
    public static class StringCalculator
    {
        /// <summary>
        /// Возвращает результат числового выражения
        /// </summary>
        public static string ColculateNumExpression(string expression)
        {
            string repExpression = expression.Replace(",", ".");
            object result = new DataTable().Compute(repExpression, null);
            double roundPositionQuantityFx = Math.Round(double.Parse(result.ToString()), 3);

            return roundPositionQuantityFx.ToString();
        }
    }
}
