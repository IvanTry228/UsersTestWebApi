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

        private IRepositoryGeneral<UserItem> GetRepositoryFromContext(AppDbContext _testAppDbCont)
        {
            IRepositoryEntity<UserItem>  createdRepository = new RepositoryEntityBase<UserItem>();
            createdRepository.SetInjectDbSetEntity(_testAppDbCont.UsersItems);
            createdRepository.SetInjectAppDbContext(_testAppDbCont);

            return (IRepositoryGeneral<UserItem>)createdRepository;
        }

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

            SetRepository(currentRepository);
        }

        private void CallApplyInjection()
        {
            currentValidatePost.SetQueryableItems(currentRepository.GetQueryableItems()); 
            currentValidatePut.SetQueryableItems(currentRepository.GetQueryableItems());
        }
    }
}