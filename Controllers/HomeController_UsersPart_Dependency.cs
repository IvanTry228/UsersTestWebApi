using Microsoft.AspNetCore.Mvc;
using RepositoryTemplate;
using RepositoryTemplate.IValidationTemplates;
using UsersTestApi.Entity;
using UsersTestRest.OperationLogicImplement.Validations;

namespace UsersTestApi.Controllers
{
    public partial class HomeController : Controller, IRepositoryDependency<UserItem> //IQueryableInjectedItemsDog
    {
        private IValidatorQueryableItems<UserItem> currentValidatePost;
        private IValidatorQueryableItems<UserItem> currentValidatePut;

        private IRepositoryGen<UserItem> currentRepository;

        public void SetRepository(IRepositoryGen<UserItem> _setRepository)
        {
            currentRepository = _setRepository; 
            CallApplyInjection();
        }

        public IRepositoryGen<UserItem> GetRepository()
        {
            return currentRepository;
        }

        private partial void PartialOnConstructor()
        {
            FastSelfInjectionDb();
        }

        private void FastSelfInjectionDb()
        {
            currentValidatePost = new ValidatePostUsers();
            currentValidatePut = new ValidatePutItems();

            var fastGeneratedRepository = new RepositoryUsersItem();

            fastGeneratedRepository.SetInjectDbSetEntity(MainDataHolder.Instance.AppDbContextHolder.UsersItems);
            fastGeneratedRepository.SetInjectAppDbContext(MainDataHolder.Instance.AppDbContextHolder);

            SetRepository(fastGeneratedRepository);
            //CallApplyInjection();
        }

        private void CallApplyInjection()
        {
            currentValidatePost.SetQueryableItems(currentRepository.GetQueryableItems()); 
            currentValidatePut.SetQueryableItems(currentRepository.GetQueryableItems());
        }
    }
}
