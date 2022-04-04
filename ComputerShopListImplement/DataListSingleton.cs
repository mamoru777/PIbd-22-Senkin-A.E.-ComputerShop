using System;
using ComputerShopListImplement.Models;
using System.Collections.Generic;

namespace ComputerShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Complect> Complects { get; set; }
        public List<Zakupka> Zakupkas { get; set; }
        public List<Sborka> Sborkas { get; set; }
        private DataListSingleton()
        {
            Complects = new List<Complect>();
            Zakupkas = new List<Zakupka>();
            Sborkas = new List<Sborka>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
