using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UsersTestApi.Entity;

namespace UsersTestApi.OperationLogicImplement
{
    public class UsersFastFakeFiller
    {
        private static Random random = new Random();

        public static void TestCallLogUsersItems(IEnumerable<UserItem> _fastLog)
        {
            foreach (var item in _fastLog)
            {
                UserItem.TestLogItem(item);
            }
        }

        public static void CallFillRandomElementToDb(DbSet<UserItem> dbSource, int countItems = 100)
        {
            var bufferObjects = GetRandomElementsUsersList(countItems);
            dbSource.AddRange(bufferObjects);
        }

        public static IList<UserItem> GetRandomElementsUsersList(int countItems = 100)
        {
            IList<UserItem> fastCollections = new List<UserItem>(countItems);

            for (int i = 0; i < countItems; i++)
            {
                UserItem bufferDog = GetGenerateRandomUserItem();
                fastCollections.Add(bufferDog);
                //_argFastQuaryable.Add(bufferDog);
                //MainDataHolder.Instance.AppDbContextHolder.DogsItems.Add(GetGenerateRandomDogItem()); //
            }

            return fastCollections;
        }

        public static UserItem GetGenerateRandomUserItem()
        {
            UserItem generated = new UserItem();

            string randomdedName = "UserName " + RandomString(5);
            generated.Name = randomdedName;
            generated.FullName = randomdedName;
            generated.DateCreated = DateTime.Now;
            generated.DateLastUpdated = DateTime.Now;
            generated.Status = "Default";

            return generated;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
