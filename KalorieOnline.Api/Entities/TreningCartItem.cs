namespace KalorieOnline.Api.Entities
{
    public class TreningCartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ExerciseId { get; set; }
        public int Weight { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }

    }
}
