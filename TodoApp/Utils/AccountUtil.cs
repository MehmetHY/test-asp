using Microsoft.AspNetCore.Mvc;
using TodoModels.Models;

namespace TodoUtils.Utils
{
    public static class AccountUtil
    {
        private const string CURRENT_ACCOUNT_ID_KEY = "CURRENT_ACCOUNT_ID";
        private const string CURRENT_ACCOUNT_NAME_KEY = "CURRENT_ACCOUNT_NAME";
        
        public static int? GetCurrentAccountId(this ISession session) => 
            session.GetInt32(CURRENT_ACCOUNT_ID_KEY);
        public static int? GetCurrentAccountId(this Controller controller) =>
            controller.HttpContext.Session.GetCurrentAccountId();

        public static string? GetCurrentAccountName(this ISession session) => 
            session.GetString(CURRENT_ACCOUNT_NAME_KEY);
        public static string? GetCurrentAccountName(this Controller controller) =>
            controller.HttpContext.Session.GetCurrentAccountName();

        public static bool IsSignedIn(this ISession session) => session.GetCurrentAccountId() != null && session.GetCurrentAccountName() != null;
        public static bool IsSignedIn(this Controller controller) => 
            controller.HttpContext.Session.IsSignedIn();
        
        public static void SignIn(this ISession session, UserModel model)
        {
            session.SetInt32(CURRENT_ACCOUNT_ID_KEY, model.Id!.Value);
            session.SetString(CURRENT_ACCOUNT_NAME_KEY, model.Name!);
        }
        public static void SignIn(this Controller controller, UserModel model)
        {
            controller.HttpContext.Session.SignIn(model);
        }

        public static void SignOut(this ISession session)
        {
            session.Remove(CURRENT_ACCOUNT_ID_KEY);
            session.Remove(CURRENT_ACCOUNT_NAME_KEY);
        }
        public static void SignOut(this Controller controller)
        {
            controller.HttpContext.Session.SignOut();
        }
    }
}
