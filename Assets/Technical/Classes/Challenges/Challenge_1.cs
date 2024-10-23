using Common.Controllers;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using WeightBlocks;
using Random = UnityEngine.Random;
using Balance;

namespace Challenges
{
    public class Challenge_1 : Challenge
    {
        public MainBalance MainBalance;
        [SerializeField]
        private GameObject _nextChallengeButton;
        [SerializeField]
        private GameObject _nextChallengeButton2;
        [SerializeField]
        private GameObject _nextChallengeButton3;
        [SerializeField]
        public float _trueWeight;
        [SerializeField]
        public float _trueWeighter;
        [SerializeField]
        private InputField _TrueWeight;
        [SerializeField]
        private GameObject _NoWeight;
        
        public override void StartChallenge()
        {//***********************************************1
        Debug.Log("chegou aqui" );
            _UnitInput.SetActive(false);
            _ValueInput.SetActive(false);
            _BlockFactorytoggle.SetActive(true);
            _confirmAnswerButton.SetActive(false);
            _nextChallengeButton.SetActive(false);
            _checkEquiButton.SetActive(false);
            _BlockFactorytoggle.SetActive(true);
            GameController.Singleton.BlockController.ResetWeightBlocks();
          
        }

        


        [SerializeField]
        private InputField _answerInputValue;
        [SerializeField]
        private Dropdown _answerInputUnit;
        [SerializeField]
        private GameObject _confirmAnswerButton;
        [SerializeField]
        private GameObject _checkEquiButton;
        [SerializeField]
        private GameObject _checkR;
        [SerializeField]
        private Text _answerCorrectionFeedback;
        [SerializeField]
        private GameObject _GreenButton;
        [SerializeField]
        private GameObject _RedButton;
        [SerializeField]
        private GameObject _UnitInput;
        [SerializeField]
        private GameObject _ValueInput;
        [SerializeField]
        private GameObject _BlockFactorybackground;
        [SerializeField]
        private GameObject _BlockFactorytoggle;
        [SerializeField]
        private GameObject _BlockFactorytoggleNew;
       //[SerializeField]
        //private GameObject _BlockFactorytoggle;

        public void CheckAnswer()
        {
            if (_answerInputValue.text != "")
            {
                float answer = WeightUnitConverter.TrueWeight(float.Parse(_answerInputValue.text), _answerInputUnit.value);
                if (answer == _trueWeight)
                {
                    _answerCorrectionFeedback.text = "Correto !";
                    _confirmAnswerButton.SetActive(false);
                    _nextChallengeButton.SetActive(true);
                }
                else
                {
                    _answerCorrectionFeedback.text = "Incorreto !";
                }
            }
        }
    
        public override void StartChallenge(string challengeX, string challengeP)
        {//******************************************************************2 
            int _desiredHook=0;
            float _convertedWeight;
            _checkR.SetActive(false);
            _nextChallengeButton3.SetActive(false);
            _UnitInput.SetActive(true);
            _ValueInput.SetActive(true);
            _BlockFactorytoggle.SetActive(true);
            _BlockFactorytoggleNew.SetActive(false);
            _confirmAnswerButton.SetActive(true);
            _nextChallengeButton.SetActive(false);
            _checkEquiButton.SetActive(false);
            
            GameController.Singleton.BlockController.ResetWeightBlocks();

            _convertedWeight = int.Parse(challengeP);
            _trueWeight = WeightUnitConverter.TrueWeight(_convertedWeight, 0);
            _answerInputValue.text = "";
            _answerCorrectionFeedback.text = "";
            
            int randomWeight = 0;
            bool left = true;
            int hook = 1;
            for (int i = 0; i < challengeX.Length; i++)
            {
                switch (challengeX[i]){
                    case '-': 
                        randomWeight = -1;
                    break;
                    case '+':
                        randomWeight = 0;
                    break;
                    case '=':
                        left = false;
                    break;
                    case 'x':
                    case 'X':
                        _desiredHook = (left) ? hook+3 : hook-1;
                        if (randomWeight == -1){
                            _desiredHook = _desiredHook + 8;
                        }
                        GameController.Singleton.BlockController.CreateChallengeBlock(randomWeight, _convertedWeight, 0, GameController.Singleton.LevelController.MainBalance.GetHooks()[_desiredHook].transform.position);
                        Debug.Log("True Weight: " + _trueWeight + ", randomWeight: " + randomWeight + ", _convertedWeight: " + _convertedWeight+ ", _desiredHook: " + _desiredHook);
                        hook=1;
                        randomWeight = 0;
                    break;
                    default: // 7 6 5 4 0 1 2 3 / 15 14 13 12 8 9 10 11 
                        if (Char.IsDigit(challengeX[i])){
                            hook = (int) Char.GetNumericValue(challengeX[i]);
                        }
                    break;

                }


            }

           /* if (GameController.Singleton.LevelController.MainBalance.GetTotalWeight() == 0)
            {
                GameController.Singleton.BlockController.CreateChallengeBlock(randomWeight, _convertedWeight, 0, GameController.Singleton.LevelController.MainBalance.GetHooks()[_desiredHook].transform.position);
            }*/

        }//**********************************************************************3
        public override void StartChallengeONLYWEIGHT(string[] peso,string nooblocks )
        {
            Vector3 weightBlockPosition=new Vector3(1.378f,0.0f,0.0f);
            for (int i = 0; i < int.Parse(nooblocks); i++)
            {
                
                GameController.Singleton.BlockController.CreateDefaultBlock(float.Parse(peso[i]), 0, weightBlockPosition);
                weightBlockPosition.x+=1.0f;
            }
            
            _checkEquiButton.SetActive(true);
            _confirmAnswerButton.SetActive(false);
            _nextChallengeButton.SetActive(false);
            _nextChallengeButton2.SetActive(false);
            _UnitInput.SetActive(false);
            _ValueInput.SetActive(false);
            _BlockFactorytoggle.SetActive(false);
            _BlockFactorybackground.SetActive(false);
            _answerInputValue.text = "";
            _answerCorrectionFeedback.text = "";
            
           // float totw=MainBalance._totalWeight;
           /*
            if (_totalWeight == 0)
            {
                _answerCorrectionFeedback.text = "Correto !";
                _confirmAnswerButton.SetActive(false);
                _nextChallengeButton.SetActive(true);
                Balance.MainBalance.BalancedState();
            }
            else
            {

               Balance.MainBalance.UnbalancedState(_totalWeight);
              }*/
        }
        public void CheckEqui()
        {
            {
                if(_GreenButton.activeSelf==true){
                   if(GameController.Singleton.LevelController.MainBalance.GetNoWeightval()==false)
                    {
                    Debug.Log("TACERTO!");  
                    _answerCorrectionFeedback.text = "Em equiíbrio !";
                    _nextChallengeButton2.SetActive(true);
                    }
                    else{
                        _answerCorrectionFeedback.text = "Sem pesos !";
                    }
                }
                else{
                    _confirmAnswerButton.SetActive(false);
                    _answerCorrectionFeedback.text = "Desbalanceada !";
                    _nextChallengeButton2.SetActive(false);
                    Debug.Log("NAO TA");
                }
            }
        }
        
        public override void StartRChallenge()
        {//***********************************************1
        Debug.Log("chegou aqui" );
            int _desiredHook=0;
            int _numberOfWeightBlocks;
            float _trueWeight;
            float _convertedWeight;

            _confirmAnswerButton.SetActive(false);
            _checkEquiButton.SetActive(false);
            _checkR.SetActive(true);
            _nextChallengeButton3.SetActive(false);
            _UnitInput.SetActive(true);
            _ValueInput.SetActive(true);
            _BlockFactorytoggle.SetActive(true);
            _BlockFactorytoggleNew.SetActive(false);
            _BlockFactorybackground.SetActive(true);
            
            GameController.Singleton.BlockController.ResetWeightBlocks();
            _numberOfWeightBlocks = Random.Range(1, 4);
            
            int randomWeight = Random.Range(-1, 1);

            do
            {
                _convertedWeight = Random.Range(-100, 100);
                _convertedWeight /= 10;
            } while (_convertedWeight == 0);

            _trueWeight = WeightUnitConverter.TrueWeight(_convertedWeight, 0);
            _answerInputValue.text = "";
            _answerCorrectionFeedback.text = "";
            _trueWeighter=_trueWeight;
            //_TrueWeight.text=_trueWeight.ToString() ;
            Debug.Log("Number: " + _numberOfWeightBlocks);
            
            for (int i = 0; i < _numberOfWeightBlocks; i++)
            {
                if (randomWeight < 0)
                {
                    _desiredHook = Random.Range(8, 16);
                }
                else
                {
                    _desiredHook = Random.Range(0, 8);
                }

                GameController.Singleton.BlockController.CreateChallengeBlock(randomWeight, _convertedWeight, 0, GameController.Singleton.LevelController.MainBalance.GetHooks()[_desiredHook].transform.position);
                Debug.Log("True Weight: " + _trueWeight + ", randomWeight: " + randomWeight + ", _convertedWeight: " + _convertedWeight+ ", _desiredHook: " + _desiredHook);
            }

            if (GameController.Singleton.LevelController.MainBalance.GetTotalWeight() == 0)
            {
                GameController.Singleton.BlockController.CreateChallengeBlock(randomWeight, _convertedWeight, 0, GameController.Singleton.LevelController.MainBalance.GetHooks()[_desiredHook].transform.position);
            }

        }
        public void CheckAnswerR()
        {
            if (_answerInputValue.text != "")
            {
                //float truer= float.Parse(_trueWeight.text);
                float answer = WeightUnitConverter.TrueWeight(float.Parse(_answerInputValue.text), _answerInputUnit.value);
                if (answer == _trueWeighter)
                {
                    _answerCorrectionFeedback.text = "Correto !";
                    _confirmAnswerButton.SetActive(false);
                    _nextChallengeButton3.SetActive(true);
                }
                else
                {
                    Debug.Log("Resposta="+_trueWeighter);
                    Debug.Log("Valor="+answer);
                    _answerCorrectionFeedback.text = "Incorreto !";
                }
            }
        }
    } 
    
}