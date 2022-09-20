namespace REST_API_MECATEC.Models;

public class Bills
{
   public string  billID { get; set; }
    public string service { get; set; }
    public int servicePrice { get; set; }
    public string carPartslist { get; set; }
    public int carPartslistPrices{ get; set; }
    public string mechanic { get; set; }
    
}