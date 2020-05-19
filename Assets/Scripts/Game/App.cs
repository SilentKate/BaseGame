using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using SilentPartyGames.Game.Service;
using SilentPartyGames.Game.State;
using SilentPartyGames.Game.UI;
using UnityEngine;

namespace SilentPartyGames.Game
{
    public class App : MonoBehaviour
    {
        public static T Resolve<T>() where T : class 
        {
            var type = typeof(T);
            if (_dependencies.TryGetValue(type, out var service)) return service as T;
            throw new InvalidOperationException("App :: Services : Try to access a non-existent service");
        }
        private static readonly Dictionary<Type, object> _dependencies = new Dictionary<Type, object>();

        [SerializeField] private MenuScreenView _menuScreenView;
        [SerializeField] private LevelScreenView _levelScreenView;
        
        private UserDataStorage _userDataStorage;
        private AppPersistenceService _appPersistenceService;

        [UsedImplicitly]
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        [UsedImplicitly]
        private void Start()
        {
            _menuScreenView.Hide();
            _levelScreenView.Hide();
            
            _userDataStorage = new UserDataStorage();
            _appPersistenceService = new AppPersistenceService(Path.Combine(Application.persistentDataPath, "local"));
            
            SetupUserPersistence(_userDataStorage);
            SetupUserServices(_userDataStorage);
            SetupGameServices();
            Resolve<IGameFlowService>().ChangeState();
        }

        private void SetupUserPersistence(UserDataStorage userDataStorage)
        {
            _appPersistenceService.Register(userDataStorage.Results, "results");
            _appPersistenceService.ApplyFromSaveFile();
        }

        private void SetupUserServices(UserDataStorage userDataStorage)
        {
            _dependencies.Add(typeof(IResultService), new UserResultService(userDataStorage.Results));
        }
        
        private void SetupGameServices()
        {
            var roundController = new DummyRoundController();
            _dependencies.Add(typeof(IRoundController), roundController);
            var gameFlowService = new GameFlowService(new GameFlowContainer());
            _dependencies.Add(typeof(IGameFlowService), gameFlowService);
            _dependencies.Add(typeof(MenuScreenController), 
                new MenuScreenController(new MenuScreenModelFactory(gameFlowService), _menuScreenView));
            _dependencies.Add(typeof(LevelScreenController), 
                new LevelScreenController(new LevelScreenModelFactory(gameFlowService), _levelScreenView));
        }

        [UsedImplicitly]
        private void OnApplicationQuit()
        {
            _appPersistenceService?.ApplyToSaveFile();
        }

        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}