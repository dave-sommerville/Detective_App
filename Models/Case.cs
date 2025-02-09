namespace Detective_App.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        //public string CaseRef { get; set; }
        //public string LeadDetectiveBadge { get; set; }
        public string Status { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateFileOpened  { get; set; } 
        public string CrimeSceneLocation { get; set; }
        public string Notes { get; set; }
        public string Suspects { get; set; }
        public string Evidence { get; set; }
        public Case()
        {
            DateFileOpened = DateTime.Now;
        }
    }
}
