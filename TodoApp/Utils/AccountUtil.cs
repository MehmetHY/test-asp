using TodoModels.Models;

namespace TodoUtils.Utils
{
    public class AccountUtil
    {
        private readonly ISession _session;
        public AccountUtil(ISession session)
        {
            _session = session;
        }
        
        private const string CURRENT_ACCOUNT_ID_KEY = "CURRENT_ACCOUNT_ID";
        private const string CURRENT_ACCOUNT_NAME_KEY = "CURRENT_ACCOUNT_NAME";
        
        public int? CurrentAccountId => _session.GetInt32(CURRENT_ACCOUNT_ID_KEY);
        public string? CurrentAccountName => _session.GetString(CURRENT_ACCOUNT_NAME_KEY);
        public bool SignedIn => CurrentAccountId != null && CurrentAccountName != null;
        
        public void SignOut()
        {
            _session.Remove(CURRENT_ACCOUNT_ID_KEY);
            _session.Remove(CURRENT_ACCOUNT_NAME_KEY);
        }

        public void SignIn(UserModel model)
        {
            _session.SetInt32(CURRENT_ACCOUNT_ID_KEY, model.Id!.Value);
            _session.SetString(CURRENT_ACCOUNT_NAME_KEY, model.Name!);
        }
    }
}
