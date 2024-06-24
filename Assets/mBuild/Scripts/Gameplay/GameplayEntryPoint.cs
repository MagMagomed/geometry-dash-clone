using Assets.mBuild.Scripts.Gameplay.Character;
using UnityEditor;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private MyCharacterController m_characterController;
        public void Run() 
        {
            var player = AssetDatabase.LoadAssetAtPath<MyCharacterController>("Assets/mBuild/Prefabs/Gameplay/Player.prefab");
            m_characterController = Instantiate(player);
            Debug.Log("Gameplay started");
        }
    }
}
