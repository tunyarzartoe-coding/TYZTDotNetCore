using System;
using System.Collections.Generic;

namespace TYZTDotNetCore.RealtimeChartApp.Models;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Duration { get; set; }

    public decimal Charges { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblResult> TblResults { get; set; } = new List<TblResult>();

    public virtual ICollection<TblStudentCourse> TblStudentCourses { get; set; } = new List<TblStudentCourse>();
}
