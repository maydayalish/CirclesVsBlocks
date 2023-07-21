using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using Managers.Game;
using Utility;

namespace Managers
{
    public class RemoteConfigManager : MonoBehaviour
    {
        [SerializeField] private GameConfiguration gameConfig;
        public struct userAttributes { }
        public struct appAttributes { }

        async Task InitializeRemoteConfigAsync()
        {
            // initialize handlers for unity game services
            await UnityServices.InitializeAsync();

            // remote config requires authentication for managing environment information
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
        }

        async Task Start()
        {
            if (Utilities.CheckForInternetConnection())
            {
                await InitializeRemoteConfigAsync();
            }

            RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
            RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
        }

        void ApplyRemoteSettings(ConfigResponse configResponse)
        {
            Debug.Log("RemoteConfigService.Instance.appConfig fetched: " + RemoteConfigService.Instance.appConfig.config.ToString());
            gameConfig.ApplyConfiguration();
            ServiceLocator.Resolve<MainManager>().Initialize(gameConfig);
        }
    }
}