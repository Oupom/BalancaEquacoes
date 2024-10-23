using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{

    string[] pesoeposi;
    public Text po;
    [SerializeField] private Button buttona;

    private void Start()
    {
        buttona.onClick.AddListener(vai);
        //buttonRetrievePassword.onClick.AddListener(OnButtonRetrievePasswordClicked);
    }
    private void vai()
    {
        string localfile=Application.dataPath + "/StorageLocal/userid.txt";
        string json=File.ReadAllText(localfile);
        Debug.Log(json); 
        SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
        po.text=stats["email"];
        Debug.Log(po.text);  
    }
}
