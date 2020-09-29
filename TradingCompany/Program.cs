using AutoMapper;
using DTO;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALEF.Concrete;
using DAL.Interfaces;

namespace TradingCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.startWork();
        }
    }
}