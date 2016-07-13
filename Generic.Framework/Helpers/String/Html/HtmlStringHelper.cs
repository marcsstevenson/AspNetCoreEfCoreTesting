using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Helpers.String.Html
{
    public static class HtmlStringHelper
    {
        public static HtmlViewModel StringToHtmlViewModel(string htmlString)
        {
            var htmlViewModel = new HtmlViewModel();



            return htmlViewModel;
        }

        /// <summary>
        /// Returns the head tag from the html string
        /// </summary>
        /// <param name="htmlString">A string in Html format</param>
        /// <returns>The head tag and its contents</returns>
        /// <example>
        /// var string htmlString = "<html><head>Something</head></html>";
        /// var headTag = ExtractHeadFromHtmlString(htmlString);
        /// Assert.IsTrue(headTag == "<head>Something</head>");
        /// </example>
        public static string ExtractHeadFromHtmlString(string htmlString)
        {
            return ExtractFirstTagFromHtmlString(htmlString, "head");
        }

        /// <summary>
        /// Returns the first tag from the html string
        /// </summary>
        /// <param name="htmlString">A string in Html format</param>
        /// <param name="tag">The first tag to extract</param>
        /// <returns>A tag and its contents</returns>
        /// <example>
        /// var string htmlString = "<html><head>Something</head></html>";
        /// var headTag = ExtractFirstTagFromHtmlString(htmlString, "head");
        /// Assert.IsTrue(headTag == "<head>Something</head>");
        /// </example>
        public static string ExtractFirstTagFromHtmlString(string htmlString, string tag)
        {
            var splitOnTagResult = SplitOnTag(htmlString, "head");

            return splitOnTagResult.TagHtml;
        }

        public static string RemoveTagFromHtmlString(string htmlString, string tag)
        {
            var startTag = "<" + tag + ">";
            var endTag = "</" + tag + ">";

            var startParts = htmlString.Split(new[] { startTag }, StringSplitOptions.RemoveEmptyEntries);

            var tagContents = new StringBuilder(startTag);

            var nextLevel = 1; //Track he nesting level so that we can handle situations like <div><div></div></div>
            foreach (var part in startParts)
            {
                if (part.Contains(endTag))
                    nextLevel--;
                else
                    nextLevel++;

                tagContents.Append(part);

                if (nextLevel == 0)
                    break; //We are done
            }

            return tagContents.ToString();
        }

        private static SplitOnTagResult SplitOnTag(string htmlString, string tag)
        {
            var splitOnTagResult = new SplitOnTagResult();

            var startTag = "<" + tag + ">";
            var endTag = "</" + tag + ">";

            var startParts = htmlString.Split(new[] { startTag }, StringSplitOptions.RemoveEmptyEntries);

            var tagHtml = new StringBuilder(startTag);
            var postTagHtml = new StringBuilder();

            var nestLevel = 1; //Track he nesting level so that we can handle situations like <div><div></div></div>
            bool preTag = true;
            bool postTag = false;
            foreach (var part in startParts)
            {
                if (preTag)
                {
                    preTag = false;
                    splitOnTagResult.PreTagHtml = part;
                    continue;
                }
                else if (postTag)
                    postTagHtml.Append(part);

                if (part.Contains(endTag))
                    nestLevel--;
                else
                    nestLevel++;
                
                if (nestLevel == 0)
                {
                    postTag = true; //We are done with the tag   

                    //Split and add
                    var endParts = part.Split(new[] { endTag }, StringSplitOptions.None);

                    tagHtml.Append(endParts[0] + endTag);

                    for (int i = 1; i < endParts.Count(); i++)
                        postTagHtml.Append(endParts[i]);
                }
                else
                {
                    tagHtml.Append(part);
                }
            }

            splitOnTagResult.TagHtml = tagHtml.ToString();
            splitOnTagResult.PostTagHtml = postTagHtml.ToString();

            return splitOnTagResult;
        }
        
        private struct SplitOnTagResult
        {
            public string PreTagHtml { get; set; }
            public string TagHtml { get; set; }
            public string PostTagHtml { get; set; }
        }
    }
}
