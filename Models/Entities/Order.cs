﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebBanHang.Models.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? UserId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedOnUtc { get; set; }
}