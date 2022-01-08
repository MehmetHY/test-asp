using TodoData.UnitOfWork;
using TodoModels.Models;
using TodoUtils.ViewModels;

namespace TodoUtils.Adapters
{
    public class UserSignAdapter
    {
        private readonly UnitOfWork _unitOfWork;
        public UserSignAdapter(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserModel GetUser(SigninViewModel model)
        {
            UserModel user = _unitOfWork.UserRepo.GetByName(model.Name!)!;
            return user;
        }
        public UserModel GetUser(SignupViewModel model)
        {
            UserModel user = new UserModel { Name = model.Name, Password = model.Password };
            return user;
        }
    }
}
