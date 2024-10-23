using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using UnityEditor;
using Models;
using Models1;
using Proyecto26;
using UnityEngine.Networking;

public class RestAPI3Post : MonoBehaviour
{
    private RequestHelper currentRequest;
    private string url="https://middleware-4sq6zh45la-uc.a.run.app/user";
    string[] pesoeposi;
    [SerializeField] private InputField inputPeso;
    [SerializeField] private InputField inputPosicao;
    [SerializeField] private InputField inputUsername;
    [SerializeField] private InputField inputUsernamegame;
    [SerializeField] private Button button;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button buttonreg;
    [SerializeField] private Button buttonlog;
    
    private void LogMessage(string title, string message) {
    #if UNITY_EDITOR
            EditorUtility.DisplayDialog (title, message, "Ok");
    #else
            Debug.Log(message);
    #endif
    }
   private void Start(){
        button.onClick.AddListener(GetData);
        button2.onClick.AddListener(PostLogin);
        button3.onClick.AddListener(PutDataLogin);
        buttonreg.onClick.AddListener(PostLogin);
        buttonlog.onClick.AddListener(UserRead);
   }
   private void PostData()
   {
    string localfile=Application.dataPath + "/StorageLocal/userid.txt";
    string json=File.ReadAllText(localfile);
    Debug.Log(json); 
    SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
    string emailper= stats["localId"];
    //RestClient.DefaultRequestParams["param1"] = "My first param";
	//RestClient.DefaultRequestParams["param3"] = "My other param";

		currentRequest = new RequestHelper {
			Uri = url+"/"+emailper, /*+ "users",/*
			Params = new Dictionary<string, string> {
				{ "pes", "2" },
				{ "pos", "3x" }
			},*/
			Body = new PostNovo {
                pes=inputPeso.text,
                pos=inputPosicao.text,
			},
			EnableDebug = true
		};
		RestClient.Post<PostNovo>(currentRequest)
		.Then(res => {

			// And later we can clear the default query string params for all requests
			RestClient.ClearDefaultParams();

			this.LogMessage("Success"+res, JsonUtility.ToJson(true));
		})
		.Catch(err => this.LogMessage("Error", err.Message));
   }
   private void PostLogin()
   {
    string localfile=Application.dataPath + "/StorageLocal/userid.txt";
    string json=File.ReadAllText(localfile);
    Debug.Log(json); 
    SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
    string emailper= stats["localId"];
    File.WriteAllText(Application.dataPath + "/StorageLocal/username.txt",inputUsername.text);
		currentRequest = new RequestHelper {
			Uri = url+"/"+inputUsername.text, 
			Body = new Todos {
                id=emailper,
			},
			EnableDebug = true
		};
		RestClient.Post<PostNovo>(currentRequest)
		.Then(res => {

			RestClient.ClearDefaultParams();
			this.LogMessage("Success"+res, JsonUtility.ToJson(true));
		})
		.Catch(err => this.LogMessage("Error", err.Message));
   }
   private void PutDataLogin()
   {
    string localfile1=Application.dataPath + "/StorageLocal/username.txt";
    string usern=File.ReadAllText(localfile1);
    string localfile=Application.dataPath + "/StorageLocal/userid.txt";
    string json=File.ReadAllText(localfile);
    Debug.Log(json); 
    SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
    string emailper= stats["localId"];

    currentRequest = new RequestHelper {
        Uri = url+"/"+usern,
        Body = new PostNovo {
            pes=inputPeso.text,
            pos=inputPosicao.text,
        },
        Retries = 5,
        RetrySecondsDelay = 1,
        RetryCallback = (err, retries) => {
            Debug.Log (string.Format ("Retry #{0} Status {1}\nError: {2}", retries, err.StatusCode, err));
        }
    };
    RestClient.Put<PostNovo>(currentRequest, (err, res, body) => {
        if (err != null){
            this.LogMessage("Error", err.Message);
        }
        else {
            this.LogMessage("Success", JsonUtility.ToJson(body, true));
        }
    });
   }
   public void GetData()
   {
    string localfile=Application.dataPath + "/StorageLocal/userid.txt";
    string json=File.ReadAllText(localfile);
    Debug.Log(json); 
    SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
    string emailper= inputUsernamegame.text;
    RequestHelper requestOptions = null;
      RestClient.GetArray<PostNovo>(url+"/"+emailper).Then(res => {   
        requestOptions = new RequestHelper { 
            Uri = url+"/"+emailper,
            EnableDebug = true
        };
        return RestClient.Get(requestOptions);
        }).Then(res => {
            Debug.Log(res.Text);
            SimpleJSON.JSONNode jos=SimpleJSON.JSON.Parse(json);
            File.WriteAllText(Application.dataPath + "/StorageLocal/Userstring.txt",res.Text);
        }).Catch(err => this.LogMessage("Error", err.Message));
    }
    public void UserRead()
    {
        File.WriteAllText(Application.dataPath + "/StorageLocal/username.txt",inputUsername.text);
    }
    
}