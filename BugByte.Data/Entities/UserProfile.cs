using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugByte.Data.Entities;

public class UserProfile
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(32)]public  string Id { get; set; }
    
    
    public string Name { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }


}