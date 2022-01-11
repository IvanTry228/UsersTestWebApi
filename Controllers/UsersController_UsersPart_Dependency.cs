using Microsoft.AspNetCore.Mvc;
using RepositoryTemplate;
using RepositoryTemplate.IValidationTemplates;
using UsersTestApi.Entity;
using UsersTestRest.OperationLogicImplement.Validations;

namespace UsersTestApi.Controllers
{
    public partial class UsersController : Controller, IRepositoryDependency<UserItem>
    {
        private IValidatorQueryableItems<UserItem> currentValidatePost;
        private IValidatorQueryableItems<UserItem> currentValidatePut;

        private IRepositoryGeneral<UserItem> currentRepository;

        public void SetRepository(IRepositoryGeneral<UserItem> _setRepository)
        {
            currentRepository = _setRepository; 
            CallApplyInjection();
        }

        public IRepositoryGeneral<UserItem> GetRepository()
        {
            return currentRepository;
        }

        private partial void PartialOnConstructor()
        {
            FastSelfInjection();
        }

        private void FastSelfInjection()
        {
            currentValidatePost = new ValidatePostUsers();
            currentValidatePut = new ValidatePutItems();

            var fastGeneratedRepository = new RepositoryEntityBase<UserItem>();

            ///fastGeneratedRepository.SetInjectDbSetEntity(MainDataHolder.Instance.AppDbContextHolder.UsersItems);
            ///fastGeneratedRepository.SetInjectAppDbContext(MainDataHolder.Instance.AppDbContextHolder);

            AppDbContext testAppDbCont = new AppDbContext();
            fastGeneratedRepository.SetInjectDbSetEntity(testAppDbCont.UsersItems);
            fastGeneratedRepository.SetInjectAppDbContext(testAppDbCont);

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