using Assets.mBuild.Scripts.Gameplay;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.mBuild.Scripts.EntryPoint
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _entryPoint;
        private CoroutineManager _coroutineManager;
        private UIRootView _UIRootView;
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void ApplicationStart()
        {
            _entryPoint = new GameEntryPoint();
            _entryPoint.RunGame();
        }
        private GameEntryPoint()
        {
            _coroutineManager = new GameObject("[COROUTINE_MANAGER]").AddComponent<CoroutineManager>();
            Object.DontDestroyOnLoad(_coroutineManager);

            var prefabUIRootView = AssetDatabase.LoadAssetAtPath<UIRootView>("Assets/mBuild/Prefabs/Root/View/UIRoot.prefab");
            _UIRootView = Object.Instantiate(prefabUIRootView);
            Object.DontDestroyOnLoad(_UIRootView.gameObject);
        }
        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == SceneNames.GAMEPLAY)
            {
                _coroutineManager.StartCoroutine(LoadAndStartGameplay());
                return;
            }
            if(sceneName != SceneNames.BOOT) 
            {
                throw new System.Exception($"Не найдена сцена {sceneName}");
            }
#endif
            _coroutineManager.StartCoroutine(LoadAndStartGameplay());

        }
        private IEnumerator LoadAndStartGameplay()
        {
            _UIRootView.ShowLoadingScene();

            yield return LoadScene(SceneNames.BOOT);
            yield return LoadScene(SceneNames.GAMEPLAY);

            yield return new WaitForSeconds(2);
            
            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run();

            _UIRootView.HideLoadingScene();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
