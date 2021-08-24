using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Filters
{
    public class UserApplicationFilterInSql
    {
        public string SearchText { get; set; }

        public string Region { get; set; }

        public string ProfessionalDirection { get; set; }

        public string Where => !string.IsNullOrEmpty(SearchText) ? "WHERE" : String.Empty;

        public string SelectedFieldsForSql =>
@"DISTINCT UApps.[Id] as Id
,UApps.[AverageMark] as AverageMark
,UApps.[FirstName] as FirstName
,UApps.[PhoneNumber] as PhoneNumber
,UApps.[SecondName] as SecondName
  FROM UserApplications as UApps";

        public string RegionConditionForSql =>
            string.IsNullOrWhiteSpace(Region) ? String.Empty :
@$"INNER JOIN RegionUserApplication as RegionUApp ON UApps.[Id] = RegionUApp.UserApplicationsId
  INNER JOIN (SELECT * FROM Regions
		WHERE [Name] <> {{[RegionNumberForParameter]}}) as Regions ON Regions.[Id] = RegionUApp.RegionsId";
        
        public string ProfessionalDirectionConditionForSql =>
            string.IsNullOrWhiteSpace(ProfessionalDirection) ? String.Empty :
@$"INNER JOIN ProfessionalDirectionUserApplication as PDirectionUApp ON UApps.[Id] = PDirectionUApp.[UserApplicationsId]
  INNER JOIN (SELECT * FROM ProfessionalDirections
	WHERE [Name] = {{[ProfessionalDirectionNumberForParameter]}}) as PDirections ON PDirections.[Id] = PDirectionUApp.ProfessionalDirectionsId";

        public string SearchTextConditionForSql => 
            string.IsNullOrWhiteSpace(SearchText) ? String.Empty : $"LOWER(CONCAT(UApps.[FirstName],UApps.[SecondName])) Like CONCAT(CONCAT('%', {{[SearchTextNumberForParameter]}} ),'%')";

        public IDictionary<string, string> GetParametersSequence()
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SearchText)) result.Add("[SearchTextNumberForParameter]", SearchText);
            if (!string.IsNullOrWhiteSpace(Region)) result.Add("[RegionNumberForParameter]", Region);
            if (!string.IsNullOrWhiteSpace(ProfessionalDirection)) result.Add("[ProfessionalDirectionNumberForParameter]", ProfessionalDirection);

            return result;
        }
    }
}
