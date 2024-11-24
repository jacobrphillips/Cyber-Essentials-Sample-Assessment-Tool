﻿namespace CyberEssentialsApp.Models
{
    public class AssessmentViewModel
    {
        public List<Workstation> Workstations { get; set; }
        public List<Server> Servers { get; set; }
        public List<Mobile> Mobiles { get; set; }
        public int TotalWorkstations { get; set; }
        public int TotalServers { get; set; }
        public int TotalMobiles { get; set; }
        public int RequiredSampleSize { get; set; }
    }
}