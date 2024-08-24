namespace MobileShop.Classes
{
    public static class Toman
    {
        public static string ToToman(this int value)
        {
            return value.ToString("#,0 تومان");
        }

        public static string ToToman1(this int value)
        {
            return value.ToString("#,0 ");
        }
    }
}
