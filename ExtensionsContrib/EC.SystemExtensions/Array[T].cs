
namespace EC.SystemExtensions
{
    public static class Array<T>
    {
        private readonly static T[] empty = new T[0];

        public static T[] Empty()
        {
            return empty;
        }
    }
}