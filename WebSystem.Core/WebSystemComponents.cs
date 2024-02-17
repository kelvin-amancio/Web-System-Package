
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSystem.Core
{
    public static class WebSystemComponents
    {
        public static IHtmlContent WSLabel<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string? placeHolder = null, string css = "", bool readOnly = false)
        {
           var html = string.Empty;

           using(StringWriter ws = new StringWriter())
           {
              var div = new TagBuilder("div");
              div.AddCssClass("mb-3");

              var label = HtmlHelperLabelExtensions.LabelFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control {css}", @placeholder = placeHolder } });
              div.InnerHtml.AppendHtml(label);

              var input = HtmlHelperEditorExtensions.EditorFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control  {css}", @placeholder = placeHolder, @readonly = "readonly" }});
              div.InnerHtml.AppendHtml(input);

              if(readOnly)
              {
                 var inputReadOnly = HtmlHelperEditorExtensions.EditorFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control  {css}", @placeholder = placeHolder, @readonly = "readonly" } });
                 div.InnerHtml.AppendHtml(inputReadOnly);
              }

              div.WriteTo(ws,HtmlEncoder.Default);
              html = ws.ToString();
           }
           return new HtmlString(html);
        }

        public static IHtmlContent WSLabelDate<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string? placeHolder = null, string css = "", bool readOnly = false)
        {
           var html = string.Empty;

           using(StringWriter ws = new StringWriter())
           {
              var div = new TagBuilder("div");
              div.AddCssClass("mb-3");

              var label = HtmlHelperLabelExtensions.LabelFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control {css}", @placeholder = placeHolder } });
              div.InnerHtml.AppendHtml(label);

              var inputDate = HtmlHelperEditorExtensions.EditorFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control  {css}", @type = "date" } });
              div.InnerHtml.AppendHtml(inputDate);

              if(readOnly)
              {
                var inputDateReadOnly = HtmlHelperEditorExtensions.EditorFor(htmlHelper, expression, new { htmlAttributes = new { @class = $"form-control  {css}", @readonly = "readonly", @type = "date" } });
                div.InnerHtml.AppendHtml(inputDateReadOnly);
              }

              div.WriteTo(ws,HtmlEncoder.Default);
              html = ws.ToString();
           }
           return new HtmlString(html);
        }
   }   
}