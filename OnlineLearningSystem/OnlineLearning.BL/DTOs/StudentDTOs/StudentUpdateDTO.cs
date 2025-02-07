﻿using Microsoft.AspNetCore.Http;
using OnlineLearning.Core.Enums;

namespace OnlineLearning.BL.DTOs;

public class StudentUpdateDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public DateTime EnrollmentDate { get; set; }
	public string Grade { get; set; }
	public Gender? Gender { get; set; }
	public IFormFile? Image { get; set; }
	public string? ImgUrl { get; set; }
}
