using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Blog b1 = new Blog();
            //b1.BlogId = 1;
            //b1.Name = "1111";
            //Blog b2 = new Blog();
            //b2.BlogId = 2;
            //b2.Name = "2222";
            //Blog b3 = new Blog();
            //b3.BlogId = 3;
            //b3.Name = "3333";
            //Blog b4 = new Blog();
            //b4.BlogId = 4;
            //b4.Name = "4444";
            //Blog b5 = new Blog();
            //b5.BlogId = 5;
            //b5.Name = "5555";
            //List<Blog> list = new List<Blog>();
            //list.Add(b1);
            //list.Add(b2);
            //list.Add(b3);
            //list.Add(b4);
            //list.Add(b5);
            //DataTable dt= CovertModel.ListToTable<Blog>(list);
            //List<Blog> l =CovertModel.TableToList<Blog>(dt);
            Template template = new Template(@"@extends('aa.html')@section('title', 'fffff')@extends('aa.html')@section('title', '医疗系统')@foreach(a as b)dfdsfsdfdfdfdsfsd@endforeach");
            string html = template.Html;
            //string input = "1851 1999 1950 1905 2003";
            //string pattern = @"(?<!19)\d{2}\b";

            //foreach (Match match in Regex.Matches(input, pattern))
            //    Console.WriteLine(match.Value);
        }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }
}
