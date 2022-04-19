using workWithDb.UtilityClasses;

namespace workWithDb
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAplication.WriteToFile(DBAplication.ExecuteFirstRequest(),"FIRST");
            DBAplication.WriteToFile(DBAplication.ExecuteSecondRequest(), "SECOND");
            DBAplication.WriteToFile(DBAplication.ExecuteThirdRequest(), "THIRD");
            DBAplication.WriteToFile(DBAplication.ExecuteFourRequest(), "FOUR");          
        }
    }
}
