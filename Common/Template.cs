using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class Template
    {
        public Template(string html)
        {
            this.html = html;
        }
        private string html;

        public string Html
        {
            get { return Generate(); }
            set { html = value; }
        }
        private Dictionary<string,object> ClassDic=new Dictionary<string,object>();//用于存放类
        private Dictionary<string, string> declareDic = new Dictionary<string, string>();
        private Regex _extends = new Regex(@"@extends\('((((\w+)\.)*)\w+)'\)");
        private Regex _section = new Regex(@"@section\('(w+)', '(w+)'\)");
        private Regex _import = new Regex(@"@import\('(w+)\)");
        private Regex _foreach = new Regex(@"@foreach\s*($categories as $category) @endforeach");
        private Regex _if = new Regex("@if () @endif");
        private Regex _else = new Regex("@else");
        private Regex _elseif = new Regex("@else if");
        private Regex _declare = new Regex("{{}}");
        private string Generate()
        {
            //StringBuilder sb = new StringBuilder();
            if (_extends.IsMatch(html))
            {
                Match match = _extends.Match(html);
                GroupCollection coll =match.Groups;
                html=html.Replace(coll[0].Value,FileOpera.Content(coll[1].Value));
                Generate();
            }
            if (_section.IsMatch(html))
            {
                Match match = _section.Match(html);
                GroupCollection coll = match.Groups;
                declareDic.Add(coll[1].Value, coll[2].Value);
                html = html.Replace(coll[0].Value, "");
            }
            return html;
        }
        private string CovertHtml()
        {
            StringBuilder sb = new StringBuilder();

            return "";

        }
        private string ExtendHtml(string extend)
        {

            return "";
        }
        private T ExtendClass<T>(string extend)
        {
            T t = Activator.CreateInstance<T>(); ;
            return t;
        }
        private string ExtendSection()
        {
            return "";
        }
        
    }
}
