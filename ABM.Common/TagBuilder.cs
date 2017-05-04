using System.Collections.Generic;
using System.Text;

namespace ABM.Common
{
    public class TagBuilder
    {
        readonly string _tagtype;
        readonly List<StringBuilder> _tagAttribute = new List<StringBuilder>();
        public TagBuilder(string tagtype)
        {
            _tagtype = tagtype;
        }
        public void MergeAttribute(string attr, string value)
        {
            var attrhtml = new StringBuilder();
            attrhtml.Append(attr);
            attrhtml.Append("=\"");
            attrhtml.Append(value);
            attrhtml.Append("\"");
            _tagAttribute.Add(attrhtml);

        }
        public string InnerHtml { get; set; }
        public override string ToString()
        {
            var tag = new StringBuilder();                        
            
            tag.Append("<li><");
            tag.Append(_tagtype);
            tag.Append(" ");
            foreach (var attr in _tagAttribute)
            {
                tag.Append(attr);
            }
            tag.Append(">");
            tag.Append(InnerHtml);
            tag.Append("</");
            tag.Append(_tagtype);
            tag.Append("></li>");

            return tag.ToString();
        }
    }
}
