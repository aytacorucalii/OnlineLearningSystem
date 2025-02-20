﻿using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Contact: BaseEntity
{
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Subject { get; set; }
	public string Message { get; set; }
}
