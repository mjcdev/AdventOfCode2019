namespace AOC2019.Ten.Model
{
    public class Coordinate
    { 
        public Coordinate(int x, int y, int xvelocity, int yvelocity)
        {
            X = x;
            Y = y;
            XVelocity = xvelocity;
            YVelocity = yvelocity;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int XVelocity { get; set; }

        public int YVelocity { get; set; }
        
        public Coordinate Move()
        {
            X += XVelocity;
            Y += YVelocity;

            return this;
        }
    }
}
