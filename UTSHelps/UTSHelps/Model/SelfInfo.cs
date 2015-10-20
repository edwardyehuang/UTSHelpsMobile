using System;

namespace UTSHelps.Model
{
	public class SelfInfo
	{
		public string StudentId 			{ get; set; }
		public string DateOfBirth 			{ get; set; } = "1 January 1995";
		public string Gender 				{ get; set; } = "M";
		public string Degree 				{ get; set; } = "UG";
		public string Status 				{ get; set; } = "International";
		public string FirstLanguage 		{ get; set; } = "English";
		public string CountryOrigin 		{ get; set;	} = "Australia";
		public string Background 			{ get; set; } = "Degree";
		public string DegreeDetails 		{ get; set; } = "1st";
		public string AltContact 			{ get; set; } = "0405294958";
		public string PreferredName 		{ get; set; } = "Tom";
		public string HSC 					{ get; set; } = "true";
		public string HSCMark 				{ get; set; } = "100";
		public string IELTS 				{ get; set; } = "false";
		public string IELTSMark 			{ get; set; } = "";
		public string TOEFL 				{ get; set; } = "false";
		public string TOEFLMark				{ get; set; } = "";
		public string TAFE 					{ get; set; } = "false";
		public string TAFEMark 				{ get; set; } = "";
		public string CULT 					{ get; set; } = "false";
		public string CULTMark				{ get; set; } = "";
		public string InsearchDEEP	 		{ get; set; } = "false";
		public string InsearchDEEPMark		{ get; set; } = "";
		public string InsearchDiploma		{ get; set; } = "false";
		public string InsearchDiplomaMark	{ get; set; } = "";
		public string FoundationCourse		{ get; set; } = "false";
		public string FoundationCourseMark	{ get; set; } = "";
		public string CreatorId				{ get; set; }
	}
}

