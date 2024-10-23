using System.Collections;
using System.Collections.Generic;
using System;
using Proyecto26;
using UnityEngine;


public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance;
    [Header("Jsons")]
    [SerializeField] private TextAsset jsonLoginSignup;
    [SerializeField] private TextAsset jsonPasswordreset;
    [SerializeField] private TextAsset jsonUserid;
    [SerializeField] private GameObject FireMenu;
    [SerializeField] private GameObject GameMenu;

    
    private void Awake()
	{
		Instance = this;
	}
    public void FireLogin(string email, string password, Action<bool,string> result=null)
    {
        string uri=Constants.ENDPOINT_LOGIN_OL+Constants.API_KEY_FIREBASE;
        string payload=jsonLoginSignup.text;
        payload=payload.Replace("{email}",email);
        payload=payload.Replace("{password}",password);
        RestClient.Post(uri,payload)
            .Then((res)=>
            {
                if(result!=null){
                    
                    result?.Invoke(true, res.Text);
                    FireMenu.SetActive(false);
                    GameMenu.SetActive(true);
                }
            })
            .Catch((err)=>
            {
                result?.Invoke(false, err.Message);
                
            });
    }
    public void FireSignup(string email, string password, Action<bool,string> result=null){
        string uri=Constants.ENDPOINT_SIGNUP_OL+Constants.API_KEY_FIREBASE;
        string payload=jsonLoginSignup.text;
        payload=payload.Replace("{email}",email);
        payload=payload.Replace("{password}",password);
        RestClient.Post(uri,payload)
        .Then((res)=>
            {
                result?.Invoke(true, res.Text);
                FireMenu.SetActive(false);
                GameMenu.SetActive(true);
            })
            .Catch((err)=>
            {
                result?.Invoke(false, err.Message);
            });
    }
    public void RetrievePasswordFirebase(string email, Action<bool, string> result = null)
	{
		string uri = Constants.ENDPOINT_RESET_PASSWORD_OL + Constants.API_KEY_FIREBASE;
		string payload = jsonPasswordreset.text;
		payload = payload.Replace("{email}", email);

		RestClient.Post(uri, payload)
				  .Then((res) =>
				  {
					  result?.Invoke(false, res.Text);
				  })
				  .Catch((err) =>
				  {
					  result?.Invoke(true, err.Message);
				  });
	}
}
