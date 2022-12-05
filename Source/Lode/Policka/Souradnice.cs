namespace Lode
{
    class Souradnice
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Souradnice()
        {
            X = 0;
            Y = 0;
        }
        public Souradnice(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
