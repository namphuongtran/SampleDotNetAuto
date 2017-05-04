using System;
using System.Text;

namespace ABM.Common
{
    public class PagerHelper
    {
        public static string PageLinks(int pageIndex, int pageSize, int totalItems, int numPage, string linkFormat)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

            if (totalPages == 1) return "";
            var result = new StringBuilder();

            if (totalPages > 0)
            {                
                if (pageIndex > 1)
                {
                    var tagFirst = new TagBuilder("a");
                    const int pageFirst = 1;
                    tagFirst.MergeAttribute("href", string.Format(linkFormat, pageFirst.ToString()));
                    tagFirst.MergeAttribute("class", "first");
                    tagFirst.InnerHtml = "Đầu";
                    result.AppendLine(tagFirst.ToString());

                    var tagBack = new TagBuilder("a");
                    var pageback = pageIndex - 1;
                    tagBack.MergeAttribute("href", string.Format(linkFormat, pageback.ToString()));
                    tagBack.MergeAttribute("class", "prev");
                    tagBack.InnerHtml = "Trước";
                    result.AppendLine(tagBack.ToString());
                }
                if (numPage > 0)
                {
                    if (totalPages <= numPage)
                    {
                        for (int i = 1; i <= totalPages; i++)
                        {
                            var tag = new TagBuilder("a"); // Construct an <a> tag 

                            tag.MergeAttribute("href", string.Format(linkFormat, i.ToString()));

                            tag.InnerHtml = i.ToString();
                            if (i == pageIndex)
                                tag.MergeAttribute("class", "active");
                            result.AppendLine(tag.ToString());
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= numPage; i++)
                        {
                            var j = i + (((int)pageIndex / numPage) * numPage);
                            if (j > totalPages) break;
                            if (j == 0) continue;
                            var tag = new TagBuilder("a"); // Construct an <a> tag

                            tag.MergeAttribute("href", string.Format(linkFormat, j.ToString()));
                            tag.InnerHtml = j.ToString();

                            if (j == pageIndex)
                                tag.MergeAttribute("class", "active");
                            result.AppendLine(tag.ToString());
                        }
                    }
                }
                if (pageIndex < totalPages)
                {
                    var tagNext = new TagBuilder("a");
                    var pagenext = pageIndex + 1;

                    tagNext.MergeAttribute("href", string.Format(linkFormat, pagenext.ToString()));
                    tagNext.MergeAttribute("class", "next");
                    tagNext.InnerHtml = "Tiếp";
                    result.AppendLine(tagNext.ToString());

                    var tagLast = new TagBuilder("a");
                    var pageLast = totalPages;

                    tagLast.MergeAttribute("href", string.Format(linkFormat, pageLast.ToString()));
                    tagLast.MergeAttribute("class", "next");
                    tagLast.InnerHtml = "Cuối";
                    result.AppendLine(tagLast.ToString());
                }                
            }
            return result.ToString();
        }
    }
}
