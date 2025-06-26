using OnlineTopupCommon;
using OnlineTopupDataService;
using OnlineTopupBusinessLogic;

namespace TopupDataService
{
    public class TopupDataService
    {
        ITopupDataService topupDataService;

        public TopupDataService()
        {
            //topupDataService = new TextFileDataService();
            //topupDataService = new InMemoryDataService();
            //topupDataService = new JsonFileDataService();
            topupDataService = new DBDataService();
        }

        public List<OnlineTopupCommon.UserAccount> GetAllAccounts()
        {
            return topupDataService.GetAccounts();
        }

        public void AddAccount(UserAccount topupAccount)
        {
            topupDataService.CreateAccount(topupAccount);
        }

        public void UpdateAccount(UserAccount topupAccount)
        {
            topupDataService.UpdateAccount(topupAccount);
        }

        public void RemoveAccount(UserAccount topupAccount)
        {
            topupDataService.RemoveAccount(topupAccount);
        }
    }
}

