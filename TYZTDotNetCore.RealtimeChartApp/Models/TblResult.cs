using System;
using System.Collections.Generic;

namespace TYZTDotNetCore.RealtimeChartApp.Models;

public partial class TblResult
{
    public int ResultId { get; set; }

    public decimal Score { get; set; }

    public int Status { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public virtual TblCourse Course { get; set; } = null!;

    public virtual TblStudent Student { get; set; } = null!;
}
