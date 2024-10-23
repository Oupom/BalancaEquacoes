using Common.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Technical.Classes.HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private GameObject _activityPanel;
        [SerializeField]
        private Dropdown _weightUnit;
        [SerializeField]
        private GameObject _weightBlockCreationPanel;
        [SerializeField]
        private GameObject _activityPanelNew;
        [SerializeField]
        private GameObject _weightBlockCreationPanelNew;
        //[SerializeField]
      //  private GameObject _authorCreditPanel;

        private void Start()
        {
            _weightBlockCreationPanel.SetActive(false);            
        }

        public void SetJanela()
        {
            _weightBlockCreationPanel.SetActive(!_weightBlockCreationPanel.activeSelf);
            GameController.Singleton.PlayClickSound();
        }

        public void SetJanelaNew()
        {
            _weightBlockCreationPanelNew.SetActive(!_weightBlockCreationPanelNew.activeSelf);
            GameController.Singleton.PlayClickSound();
        }

    }
}
