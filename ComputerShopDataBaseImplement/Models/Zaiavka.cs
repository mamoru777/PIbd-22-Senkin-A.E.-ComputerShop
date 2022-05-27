﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShopDataBaseImplement.Models
{
    public class Zaiavka
    {
        public int? Id { get; set; }
        public string ZaiavkaName { get; set; }
        [ForeignKey("ZaiavkaId")]
        public virtual List<SborkaZaiavka> SborkaZaiavka { get; set; }
    }
}
