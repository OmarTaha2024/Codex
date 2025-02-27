﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodexApp.Entities;

[PrimaryKey("CourseID", "RoundNumber")]
public partial class Course
{
    [Key]
    public int CourseID { get; set; }

    [Key]
    public int RoundNumber { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Type { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Category { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MarketingCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalesCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? InstCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MentorCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? WorkSpaceCost { get; set; }

    [Column(TypeName = "decimal(14, 2)")]
    public decimal? TotalCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public int InstructorID { get; set; }

    public int MentorID { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("InstructorID")]
    [InverseProperty("Courses")]
    public virtual Instructor Instructor { get; set; }

    [ForeignKey("MentorID")]
    [InverseProperty("Courses")]
    public virtual Mentor Mentor { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}