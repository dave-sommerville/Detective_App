namespace Detective_App.Models
{
    public class Suspect
    {
        public int SuspectID { get; set; }
        public string SuspectFirstName { get; set; }
        public string SuspectLastName { get; set; }
        public string SuspectFullName => $"{SuspectFirstName } + {SuspectLastName}";
        public string KnownAliases  { get; set; }
        public string Mugshot {  get; set; } // Unsure of how to use 
        public string PhysicalDescription { get; set; }
        public string Motive { get; set; }
        public string Alibi { get; set; }

    }
}
