using System;

namespace KlantenWebAPi.contracten;

public class KlantResponseContract
{
     public Guid Id { get; set; }
     
    public string VolledigeNaam { get; set;}
     
    public String Emailadres{ get; set;}
     
    public string Wachtwoord{ get; set;}

}
