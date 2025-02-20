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

//search etmenin viewsu yoxdur
//payment var islemir yeqin ki
//payment istese evvel login sonra payment
//create update ishlemir 
//dizayn duzelt
//settings footer 
//email isleyir
//statistica deyismesi hazirdir check olunmalidir
//message check+ view
//Amin Allah razi olsun eger baxsan :( 