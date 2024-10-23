using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RestAPI : MonoBehaviour
{
    private string url="https://middleware-i2yffdhjkq-uc.a.run.app/";
  //  public Text user;
    public Text po;
    public Text pes;
    public int num;
    [SerializeField] Text pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData()); 
    }
    IEnumerator GetData()
    {
        using(UnityWebRequest request=UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if(request.result==UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error);
            }
            else{
                string json=request.downloadHandler.text;
                //Debug.Log(json);    
                SimpleJSON.JSONNode stats=SimpleJSON.JSON.Parse(json);
               // Debug.Log("aqui");
                //Debug.Log(stats[0][0]["pes"]);
                po.text="Peso:"+stats[0][0]["pes"]; 
                pos.text="Posição:"+stats[0][0]["pos"]; 
                //pes.text=stats["0"]["pes"];
            }
        }
    }

    
}
