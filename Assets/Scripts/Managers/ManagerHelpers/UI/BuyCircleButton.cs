using Managers.Game;
using Utility;

namespace Managers.UI
{
    public class BuyCircleButton : BuyButton
    {
        public override void HandleButtonClicked()
        {
            ServiceLocator.Resolve<GameManager>().BuyHitter();
        }

        public override void Initialize(GameConfiguration gameConfig)
        {
            priceText.text = gameConfig.InitialHitterPrice + "";
            ServiceLocator.Resolve<EventManager>().RegisterEvent<int>("OnHitterAcquired", OnCircleAcquired);
        }

        public void OnCircleAcquired(int hitterId)
        {
            var hitter = ServiceLocator.Resolve<GameManager>().GetHitter(hitterId + 1);
            if(hitter == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                priceText.text = hitter.Price + "";
            }
        }
    }
}