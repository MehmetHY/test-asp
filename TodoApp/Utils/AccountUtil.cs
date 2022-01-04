using Microsoft.AspNetCore.Mvc;
using TodoModels.Models;

namespace TodoUtils.Utils
{
    public static class AccountUtil
    {
        private const string CURRENT_ACCOUNT_ID_KEY = "CURRENT_ACCOUNT_ID";
        private const string CURRENT_ACCOUNT_NAME_KEY = "CURRENT_ACCOUNT_NAME";
        
        public static int? GetCurrentAccountId(this Controller controller) => controller.HttpContext.Session.GetInt32(CURRENT_ACCOUNT_ID_KEY);
        public static string? GetCurrentAccountName(this Controller controller) => controller.HttpContext.Session.GetString(CURRENT_ACCOUNT_NAME_KEY);
        public static bool IsSignedIn(this Controller controller) => controller.GetCurrentAccountId() != null && controller.GetCurrentAccountName() != null;
        
        public static void SignOut(this Controller controller)
        {
            controller.HttpContext.Session.Remove(CURRENT_ACCOUNT_ID_KEY);
            controller.HttpContext.Session.Remove(CURRENT_ACCOUNT_NAME_KEY);
        }

        public static void SignIn(this Controller controller, UserModel model)
        {
            controller.HttpContext.Session.SetInt32(CURRENT_ACCOUNT_ID_KEY, model.Id!.Value);
            controller.HttpContext.Session.SetString(CURRENT_ACCOUNT_NAME_KEY, model.Name!);
        }
    }
}
