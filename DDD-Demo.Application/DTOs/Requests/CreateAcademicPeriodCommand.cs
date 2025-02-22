﻿namespace Core.DTOs.Requests;


public class CreateAcademicPeriodCommand
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}