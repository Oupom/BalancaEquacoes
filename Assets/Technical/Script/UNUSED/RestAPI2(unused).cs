/*using System.Collections;
using System.Collections.Generic;
using Unity.UI;
using Unity.Networking
using UnityEngine;

public class RestAPI2 : MonoBehaviour
{
    InputField outputArea;
    Text tezt;
    void Start()
    {
        
    }
    void GetData()=>StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine()
    {
        outputArea.text="Carregando";
        string url="";
        using(UnityWebRequest request=UnityWebRequest.get(url))
        {
            yield return request.SendWebRequest();
            if(request.isNetworkError or request.isHttpError){
                outputArea.text=request.error;
            }
            else{
                outputArea.text=request.downloadHandler.text;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
*/