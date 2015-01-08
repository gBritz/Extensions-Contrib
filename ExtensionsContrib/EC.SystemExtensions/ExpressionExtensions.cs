using System;
using System.Linq.Expressions;

namespace EC.SystemExtensions
{
    public static class ExpressionExtensions
    {
        private static String GetPropertyName(this String body)
        {
            return String.IsNullOrEmpty(body) ? String.Empty : body.Substring(body.IndexOf('.') + 1);
        }

        public static String PropertyName(this Expression exp)
        {
            var result = String.Empty;

            if (exp is MemberExpression)
                result = ((MemberExpression)exp).Member.Name;

            else if (exp is UnaryExpression)
                result = ((UnaryExpression)exp).Operand.ToString().GetPropertyName();

            else if (exp is ConstantExpression)
                result = ((ConstantExpression)exp).Value.ToString();

            else if (exp is MethodCallExpression)
                result = ((MethodCallExpression)exp).Arguments[0].ToString().GetPropertyName();

            else if (exp is LambdaExpression)
                result = (exp as LambdaExpression).Body.PropertyName();

            else
                throw new Exception("Parameter 'exp' is not of the expected type.");

            return result;
        }
    }
}