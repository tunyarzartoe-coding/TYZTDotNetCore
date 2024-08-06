using System;
using System.Collections.Generic;

namespace TYZTDotNetCore.RealtimeChartApp.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public int RollNo { get; set; }

    public string? Name { get; set; }

    public int? GenderStatus { get; set; }

    public int Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TblResult> TblResults { get; set; } = new List<TblResult>();

    public virtual ICollection<TblStudentCourse> TblStudentCourses { get; set; } = new List<TblStudentCourse>();
}
