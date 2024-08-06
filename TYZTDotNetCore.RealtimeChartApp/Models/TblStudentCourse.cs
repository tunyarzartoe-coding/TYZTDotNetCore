using System;
using System.Collections.Generic;

namespace TYZTDotNetCore.RealtimeChartApp.Models;

public partial class TblStudentCourse
{
    public int StudentCourseId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public virtual TblCourse? Course { get; set; }

    public virtual TblStudent? Student { get; set; }
}
