namespace Cec.Barcode.Extensions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ImageResultHelper
    {
        public static string Image<T>(this IHtmlHelper helper, Expression<Action<T>> action, int width, int height)
                where T : Controller
        {
            return ImageResultHelper.Image<T>(helper, action, width, height, string.Empty);
        }

        public static string Image<T>(this IHtmlHelper helper, Expression<Action<T>> action, int width, int height, string alt)
                where T : Controller
        {
            var expression = action.Body as MethodCallExpression;
            string actionMethodName = string.Empty;
            if (expression != null)
            {
                actionMethodName = expression.Method.Name;
            }
            var myHelper = new UrlHelper(helper.ViewContext);
            var url = myHelper.Action(actionMethodName, typeof(T).Name.Remove(typeof(T).Name.IndexOf("Controller"))).ToString();

            //string url = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection).Action(actionMethodName, typeof(T).Name.Remove(typeof(T).Name.IndexOf("Controller"))).ToString();
            //string url = LinkBuilder.BuildUrlFromExpression<T>(helper.ViewContext.RequestContext, helper.RouteCollection, action);
            return string.Format("<img src=\"{0}\" width=\"{1}\" height=\"{2}\" alt=\"{3}\" />", url, width, height, alt);
        }
    }
}