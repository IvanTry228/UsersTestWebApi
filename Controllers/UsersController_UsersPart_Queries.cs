using System;
using System.Linq;
using UsersTestApi.Entity;
using Microsoft.AspNetCore.Mvc;
using OtherCustomTools;
using RepositoryTemplate;
using UsersTestApi.OperationLogicImplement;
using CustomTools;

namespace UsersTestApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public partial class UsersController : Controller
    {
        //get
        [HttpGet("Ping")]
        public string Ping()
        {
            return "teststring";
        }

        [HttpGet("Users")]
        public JsonResult Users(string attribute, string descParam = QueryToolHelper.paramOrderAsc,
                                        int currentPage = 1, int countPerPage = 10, int limit = 10)
        {
            //log query:
            var fastLog = new { attribute, descParam, currentPage, countPerPage, limit };
            Console.WriteLine("Users query = " + fastLog.ToString());

            IQueryable<UserItem> queryResult = currentRepository.GetQueryableItems();
            //sort by attribute:
            queryResult = QueryHelperConcreteLogic.OrderByAttributeReflectQuery(queryResult, attribute, descParam);
            //pagination
            queryResult = QueryToolHelper.PaginationPages(queryResult, currentPage, countPerPage);
            //limit:
            queryResult = QueryToolHelper.SelectWithLimits(queryResult, limit); //queryResult.Take(limit);

            return Json(queryResult);
        }

        //post
        [HttpPost("User")]
        public JsonResult User([FromBody] UserItem argItem)
        {
            IResultOperation bufferIResultOperation = new ResultOperation();

            bool isResultSuccess = currentValidatePost.IsValidatedItem(argItem, bufferIResultOperation);
            UserItem.TestLogItem(argItem);

            if (isResultSuccess)
            {
                argItem.DateCreated = DateTime.Now;
                argItem.DateLastUpdated = DateTime.Now;

                currentRepository.AddItem(argItem);
                currentRepository.SaveChangesApply();
            }

            string resultString = bufferIResultOperation.GetResultStringLog();

            return Json(new { resultString, argItem });
        }

        //put
        [HttpPut("User")]
        public JsonResult UserUpdate([FromBody] UserItem argItem)
        {
            IResultOperation bufferIResultOperation = new ResultOperation();

            bool isResultSuccess = currentValidatePut.IsValidatedItem(argItem, bufferIResultOperation);
            UserItem.TestLogItem(argItem);

            if (isResultSuccess)
            {
                argItem.DateLastUpdated = DateTime.Now;

                UserItem bufferItem = currentRepository.GetItemById(argItem.Id);
                bufferItem.Name = argItem.Name;
                bufferItem.FullName = argItem.FullName;
                bufferItem.Status = argItem.Status;

                bufferItem.DateLastUpdated = DateTime.Now;

                currentRepository.UpdateItem(bufferItem);
                currentRepository.SaveChangesApply();
            }

            string resultString = bufferIResultOperation.GetResultStringLog();

            return Json(new { resultString, argItem });
        }

        //delete
        [HttpDelete("User")]
        public JsonResult UserDelete(int id, string deleteToken)
        {
            string fastFakeToken = "admin";
            if (deleteToken != fastFakeToken)
                return Json(new { resultString = "delete token not correct" });

            var bufferItem = currentRepository.GetItemById(id);

            if (bufferItem != null)
            {
                currentRepository.RemoveItem(bufferItem);
                currentRepository.SaveChangesApply();
                return Json(new { resultString = "Success deleted item with id " + id });
            }
            else
                return Json(new { resultString = "Not found id to delete item with id " + id });
        }

        //put update status
        [HttpPut("UserStatus")]
        public JsonResult UserUpdateStatus(int id, string newstatus)
        {
            var bufferItem = currentRepository.GetItemById(id);

            if (bufferItem != null)
            {
                bufferItem.Status = newstatus;
                currentRepository.UpdateItem(bufferItem);
                currentRepository.SaveChangesApply();
                return Json(new { resultString = "Success deleted item with id " + id, bufferItem });
            }
            else
                return Json(new { resultString = "Not found id to delete item with id " + id });
        }
    }
}
