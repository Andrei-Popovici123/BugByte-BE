using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugByte.Data.Entities;

public class Application
{   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string id { get; set; }
    public string name { get; set; }

    
    
}