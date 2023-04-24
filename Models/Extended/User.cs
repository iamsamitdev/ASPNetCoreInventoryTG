using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreInventory.Models;

[ModelMetadataType(typeof(UserMetadata))]
public partial class User
{
    [NotMapped]
    public string ConfirmPassword { get; set; } = null!;
}

public class UserMetadata
{
    [Display(Name="ชื่อ")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนชื่อก่อน")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "นามสกุล")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนสกุลก่อน")]
    public string Lastname { get; set; } = null!;

    [Display(Name = "อีเมล์")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนอีเมล์ก่อน")]
    public string EmailID { get; set; } = null!;

    [Display(Name = "วันเกิด")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนวันเกิดก่อน")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "รหัสผ่าน")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "รหัสผ่านไม่น้อยกว่า 6 ตัวอักษร")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนรหัสผ่านก่อน")]
    public string Password { get; set; } = null!;

    // Confirmed Password
    [Display(Name = "ยืนยันรหัสผ่าน")]
    [DataType(DataType.Password)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "ป้อนยืนยันรหัสผ่านก่อน")]
    [Compare("Password", ErrorMessage = "รหัสผ่านไม่ตรงกัน")]
    public string ConfirmPassword { get; set; } = null!;
}
