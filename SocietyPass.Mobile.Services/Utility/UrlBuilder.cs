using System;
using System.Text;

namespace SocietyPass.Mobile.Services.Utility
{
    public class UrlBuilder
    {
        private readonly StringBuilder _url = new StringBuilder();
        public UrlBuilder(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;
            _url.Append(url.Trim());
        }
        public UrlBuilder Append(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                path = path.Trim();
                if (_url[_url.Length - 1] == '/')
                {
                    if (path[0] == '/')
                    {
                        _url.Remove(_url.Length - 1, 1);
                    }
                }
                else
                {
                    if (path[0] != '/')
                    {
                        _url.Append('/');
                    }
                }
                _url.Append(path);
            }
            return this;
        }
        public override string ToString()
        {
            return _url.ToString();
        }
        public Uri ToUri()
        {
            return new Uri(ToString());
        }
    }
}