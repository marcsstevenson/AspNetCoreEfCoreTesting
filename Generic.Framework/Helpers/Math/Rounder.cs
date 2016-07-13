namespace Generic.Framework.Helpers.Math
{
    public static class Rounder
    {
         public static decimal Round2(this decimal value)
         {
             return System.Math.Round(value, 2);
         }
    }
}