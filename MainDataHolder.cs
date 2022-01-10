using UsersTestApi.Entity;
using System;
using System.Linq;

namespace UsersTestApi
{
    public class MainDataHolder
    {
        public static MainDataHolder Instance { get; private set; } = new MainDataHolder();

        public AppDbContext AppDbContextHolder { get; private set; } = new AppDbContext();

        public void WakeUp()
        {
            string logTest = Instance.AppDbContextHolder.UsersItems.ToList().Count.ToString();
            Console.WriteLine("Program Main logTest = " + logTest);
            //DogsFastFakeFiller.CallToInsertRanomdedElements();
        }
    }
}