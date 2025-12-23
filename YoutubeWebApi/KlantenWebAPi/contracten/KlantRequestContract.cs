using System;
using System.ComponentModel.DataAnnotations;

namespace KlantenWebAPi.contracten;

public class KlantRequestContract
{
    
      [Required]
     [MaxLength(40)]
    public string VolledigeNaam { get; set;}
     [Required]
     [MaxLength(70)]
    public String Emailadres{ get; set;}
     [Required]
     [MaxLength(50)]
    public string Wachtwoord{ get; set;}

}
