namespace Yell.Models
{
    public class Voice
    {
        public decimal RecoveryRate { get; set; } // in fraction of max power per second
        public decimal MaxPower { get; set; } // in Watts
    }
}
