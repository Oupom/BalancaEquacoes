﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Singleton { get; set; }

        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else if (Singleton != this)
                Destroy(this.gameObject);
        }

        #region Controllers
        public LevelController LevelController = null;
        public BlockController BlockController = null;
        public JoystickController JoystickController = null;
        #endregion

        #region Game Modes
        public GameObject Menu;
        public GameObject Game;

        [SerializeField]
        private InputField _answerInputValueX;
        [SerializeField]
        private InputField _answerInputValueEq;

        public void StartGame(int gameModeId)
        {
            Menu.SetActive(false);
            Game.SetActive(true);
            GameController.Singleton.BlockController.ResetWeightBlocks();
            LevelController.StartChallenge(challengeId: gameModeId);
        }

        public void StartCustomGame(int gameModeId)
        {
            Menu.SetActive(false);
            Game.SetActive(true);
            GameController.Singleton.BlockController.ResetWeightBlocks();
            LevelController.StartChallenge(challengeId: gameModeId, _answerInputValueX.text, _answerInputValueEq.text);
        }

        public void ExitGame()
        {
            Application.Quit();
            #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        #endregion

        #region Audio
        public AudioSource ClickSound;
        public void PlayClickSound()
        {
            ClickSound.Stop();
            ClickSound.Play();
        }
        #endregion
    }
}

