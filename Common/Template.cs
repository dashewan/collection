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
        private Dictionary<string,object> classDic=new Dictionary<string,object>();//用于存放类
        private Dictionary<string, object> declareDic = new Dictionary<string, object>();//用于存储变量
        private Dictionary<string, object> tempDeclareDic = new Dictionary<string, object>();//用于存储临时变量
        private Regex _extends = new Regex(@"@extends\('((((\w+)\.)*)\w+)'\)");//引用其他页面
        private Regex _section = new Regex(@"@section\('(\w+)', '(\w+)'\)");//给变量赋值
        private Regex _import = new Regex(@"@import\('(\w+)', '(\w+)'\)");//导入对象
        private Regex _foreach = new Regex(@"@foreach\s*\(\s*(\w+)\s*as\s*(\w+)\s*\)([\s\S]*)@endforeach");
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
                if (declareDic.ContainsKey(coll[1].Value))
                {
                    declareDic.Remove(coll[1].Value);
                }
                declareDic.Add(coll[1].Value, coll[2].Value);
                html = html.Replace(coll[0].Value, "");
                Generate();
            }
            if (_import.IsMatch(html))
            {
                Match match = _import.Match(html);
                GroupCollection coll = match.Groups;
                if (!classDic.ContainsKey(coll[1].Value))
                { 
                    classDic.Add(coll[2].Value, ExtendClass(coll[1].Value));
                }
                html = html.Replace(coll[0].Value, "");
                Generate();
            }
            if (_foreach.IsMatch(html))
            {
                Match match = _foreach.Match(html);
                GroupCollection coll = match.Groups;
                if (!classDic.ContainsKey(coll[1].Value))
                {
                    classDic.Add(coll[2].Value, ExtendClass(coll[1].Value));
                }
                html = html.Replace(coll[0].Value, "");
                Generate();
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
        private object ExtendClass(string extend)
        {
            Type t = Type.GetType(extend);
            object obj = System.Activator.CreateInstance(t);
            return obj;
        }
        private string ExtendSection()
        {
            return "";
        }
        
    }
}
