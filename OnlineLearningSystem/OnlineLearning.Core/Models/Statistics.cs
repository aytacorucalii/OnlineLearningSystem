using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Statistics : BaseEntity
{
	public int StudentCount { get; set; }
	public int LearningProgramCount { get; set; }
	public int LanguageTrainingCount { get; set; }
	public int TeacherCount { get; set; }
	public int BranchCount { get; set; }
}

//search etme
//sual verme
//statistica deyismesi hazirdir
//email gonderir
//payment  var tam deyil
//login olsun sonra payment
// payment istese evvel login sonra payment
//admin panel var tam deyil