//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StroitelnayaCompaniyaApp.FailiDannih
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stroimaterial
    {
        public int ID { get; set; }
        public string Naimenovaniye { get; set; }
        public string EdinicaIzmereniyaKod { get; set; }
        public decimal Ostatok { get; set; }
        public int SkladID { get; set; }
    
        public virtual EdinicaIzmereniya EdinicaIzmereniya { get; set; }
        public virtual Sklad Sklad { get; set; }
    }
}
