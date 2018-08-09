namespace OperationMars.Requests
{
    public class CreatePlateauRequest
    {
        public string Name { get; set; }
        public int? TopRightAxis { get; set; }
        public int? TopRightOrdinate { get; set; }
    }
}