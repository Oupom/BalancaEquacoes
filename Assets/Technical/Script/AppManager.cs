using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField inputEmailLogin;
    [SerializeField] private InputField inputPasswordLogin;
    [SerializeField] private Button buttonLogin;
    [SerializeField] private GameObject userid;

    [Header("Signup")]
    [SerializeField] private InputField inputEmailSignup;
    [SerializeField] private InputField inputPasswordSignup;
    [SerializeField] private Button buttonSignup;

    [Header("RetrievePaswword")]
    [SerializeField] private InputField inputEmailRetrievePassword;
    [SerializeField] private Button buttonRetrievePassword;

    private void Start()
    {
        buttonLogin.onClick.AddListener(OnButtonLoginClicked);
        buttonSignup.onClick.AddListener(OnButtonSignupClicked);
        //buttonRetrievePassword.onClick.AddListener(OnButtonRetrievePasswordClicked);
    }

    private void OnButtonLoginClicked()
    {
        FirebaseManager.Instance.FireLogin(inputEmailLogin.text, inputPasswordLogin.text, (result, messsage) =>
        {
            if (result)
            {
                print("Success login");
                print("Message: " + messsage);
                File.WriteAllText(Application.dataPath + "/StorageLocal/userid.txt", messsage);
            }
            else
            {
                print("Error login");
                print("Message: " + messsage);
            }
        });
    }

    private void OnButtonSignupClicked()
    {
        FirebaseManager.Instance.FireSignup(inputEmailSignup.text, inputPasswordSignup.text, (result, messsage) =>
        {
            if (result)
            {
                print("Success signup");
                print("Message: " + messsage);
            }
            else
            {
                print("Error signup");
                print("Message: " + messsage);
            }
        });
    }
    private void OnButtonRetrievePasswordClicked()
    {
        FirebaseManager.Instance.RetrievePasswordFirebase(inputEmailRetrievePassword.text, (result,message) =>
        {
            if (result)
            {
                print("Success retrieve passowrd");
            }
            else
            {
                print("Error retrieve passowrd");
            }
        });
    }
}
