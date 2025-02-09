using Microsoft.AspNetCore.Components.Routing;

namespace Detective_App.Models
{
    public class Evidence
    {
        public int EvidenceID { get; set; }
        public string Title { get; set; }
        public DateTime DateFound { get; set; }
        public DateTime DateLogged { get; set; }
        public string RetrievalLocation { get; set; }
        public string EvidenceType { get; set; }
        public string Description { get; set; }
        public string CollectedBy { get; set; }
    public Evidence()
        {
            DateLogged = DateTime.Now;
        }
    }
}
