//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DungensAndDragonsGenerator
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableSubRace
    {
        public int ID { get; set; }
        public int RaceID { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public string AdditionalInfo { get; set; }
        public string AdditionHitPoints { get; set; }
        public string DESCRIPTION { get; set; }
        public string ABILITYBONUS { get; set; }
        public string ABILITYOPTBONUS { get; set; }
    
        public virtual TableRace TableRace { get; set; }
    }
}
