namespace ThapHaNoi.Models
{
    public class MoveStep
    {
        public int From { get; set; }
        public int To { get; set; }
        public MoveStep(int from, int to) { From = from; To = to; }
    }
}