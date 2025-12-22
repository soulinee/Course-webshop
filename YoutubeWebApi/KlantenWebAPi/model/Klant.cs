using System;
using System.ComponentModel.DataAnnotations;

namespace KlantenWebAPi.model;

public class Klant
{
    public Guid Id { get; set; }
     [MaxLength(40)]
    public string VolledigeNaam { get; set;}
     [MaxLength(70)]
    public String Emailadres{ get; set;}
     [MaxLength(50)]
    public string Wachtwoord{ get; set;}


}
