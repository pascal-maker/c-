using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Exercise02.Models
{
    public class SurveyResponseMap : ClassMap<SurveyResponse>
    {
        public SurveyResponseMap()
        {
            Map(m => m.Age).Name("Age");
            Map(m => m.Gender).Name("Gender");
            Map(m => m.MaritalStatus).Name("Marital Status");
            Map(m => m.Occupation).Name("Occupation");
            Map(m => m.MonthlyIncome).Name("Monthly Income");
            Map(m => m.EducationalQualifications).Name("Educational Qualifications");
            Map(m => m.FamilySize).Name("Family size");
            Map(m => m.Latitude).Name("latitude");
            Map(m => m.Longitude).Name("longitude");
            Map(m => m.PinCode).Name("Pin code");

            // ✅ Fix for Output: convert "Yes"/"No" to bool
            Map(m => m.Output)
                .Name("Output")
                .TypeConverterOption.BooleanValues(true, true, "Yes")
                .TypeConverterOption.BooleanValues(false, true, "No");

            Map(m => m.Feedback).Name("Feedback");
        }
    }
}
