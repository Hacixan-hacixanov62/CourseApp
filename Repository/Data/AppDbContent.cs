

namespace Repository.Data
{
    public static class AppDbContent<T>
    {

        public static List<T> datas;
        static AppDbContent()
        {
            datas = new List<T>();
        }
    }
}
