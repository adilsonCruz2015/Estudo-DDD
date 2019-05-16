

using ADC.Portal.Solution.Util.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ADC.Portal.Solution.Domain.Command.Common
{
    public abstract class FiltrarCmd
    {
        public FiltrarCmd()
        {
            Clear();
        }

        public virtual void Clear()
        {
            Maximum = 300;
            Page = 1;
        }

        protected int _maximum;
        public virtual int Maximum
        {
            get { return _maximum; }
            set => _maximum = value <= 0 ? 1 : value;
        }

        protected int _page;
        public virtual int Page
        {
            get { return _page; }
            set => _page = value <= 0 ? 1 : value;
        }

        public virtual string KeyWord { get; set; }

        public IList<string> DismemberKeyWord()
        {
            List<string> results = new List<string>();

            if (string.IsNullOrWhiteSpace(KeyWord))
                return results;

            string text = KeyWord;
            text = Regex.Replace(text, @"[`|'|;]", " ").Trim();
            text = Regex.Replace(text, @"[ ]{2,}", " ").Trim();

            if (!string.IsNullOrWhiteSpace(text))
            {
                MatchCollection agroup = Regex.Matches(text, "(\"[^\"]+\")", RegexOptions.IgnoreCase);
                if (agroup.Count > 0)
                {
                    foreach (Match item in agroup)
                    {
                        text = text.Replace(item.Groups[1].Value, "");
                        string novo = item.Groups[1].Value.Replace("\"", "");
                        results.Add(novo);
                        results.Add(ForText.CodeHtml(novo));

                    }
                    text = Regex.Replace(text, @"[`|'|;]", " ").Trim();
                    text = Regex.Replace(text, @"[ ]{2,}", " ").Trim();
                }
                if (!string.IsNullOrWhiteSpace(text))
                {
                    string[] separar = text.Split(' ');
                    results.Add(text);
                    results.Add(ForText.CodeHtml(text));
                    foreach (string item in separar)
                    {
                        if (item.Length > 0)
                        {
                            results.Add(item);
                            results.Add(ForText.CodeHtml(item));
                        }
                    }
                }
            }

            return results.Where(x => x.Length > 2).Distinct().ToList();
        }

    }

    public abstract class FiltrarCmd<TClass> : FiltrarCmd where TClass : class
    {
        public abstract TClass SetMax(int value);

        public abstract TClass SetPage(int value);

        public abstract TClass SetKeyWord(string value);
    }
}
