using network;

namespace persistent.network
{
    public class C2WTransformer : MainTransformers
    {
        public int windingA { get; set; } = 0;
        public int windingB { get; set; } = 0;
        public string Type { get; set; } = "C2WTransformer";
    }
}
