using UnityEngine;

namespace Assets.mBuild.Scripts.EntryPoint
{
    public class UIRootView : MonoBehaviour
    {
        public void HideLoadingScene()
        {
            gameObject.SetActive(false);
        }

        public void ShowLoadingScene()
        {
            gameObject.SetActive(true);
        }
    }
}
