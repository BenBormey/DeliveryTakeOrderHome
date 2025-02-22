using System;

public class ARAgingDetail : ICloneable
{
    public bool IsChecked { get; set; } = true;
    public string InvNumber { get; set; }
    public string PONumber { get; set; }
    public DateTime ShipDate { get; set; }
    public DateTime DueDate { get; set; }
    public string CusNum { get; set; }
    public string CusName { get; set; }
    public decimal DeltoId { get; set; }
    public string DelTo { get; set; }
    public int DaysOver { get; set; }
    public decimal GrandTotal { get; set; }
    public string Division { get; set; }
    public string IsBgorLandTitle { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}