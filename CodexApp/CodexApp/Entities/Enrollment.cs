﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodexApp.Entities;

public partial class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; }

    public int StudentID { get; set; }

    public int CourseID { get; set; }

    public int RoundNumber { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? GeneralGrade { get; set; }

    [Column(TypeName = "text")]
    public string InstructorFeedback { get; set; }

    [ForeignKey("CourseID, RoundNumber")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; }

    [InverseProperty("Enrollment")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [InverseProperty("Enrollment")]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    [ForeignKey("StudentID")]
    [InverseProperty("Enrollments")]
    public virtual Student Student { get; set; }

    [InverseProperty("Enrollment")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}