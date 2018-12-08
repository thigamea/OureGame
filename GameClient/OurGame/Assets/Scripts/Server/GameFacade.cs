using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class GameFacade : MonoBehaviour
{

    private static GameFacade _instance;
    public static GameFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return _instance;
        }
    }

    public UIManager uiMng;
    private RequestManager requestMng;
    private ClientManager clientMng;


    private void Awake()
    {
        uiMng = UIManager.Instance;
    }

    // Use this for initialization
    void Start()
    {
        InitManager();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManager();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        requestMng = new RequestManager(this);
        clientMng = new ClientManager(this);
        requestMng.OnInit();
        clientMng.OnInit();
        uiMng.OnInit();
    }
    private void DestroyManager()
    {
        requestMng.OnDestroy();
        clientMng.OnDestroy();
    }
    private void UpdateManager()
    {
        requestMng.Update();
        clientMng.Update();
        uiMng.Update();
    }

    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        requestMng.AddRequest(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        requestMng.RemoveRequest(actionCode);
    }
    public void HandleReponse(ActionCode actionCode, string data)
    {
        requestMng.HandleReponse(actionCode, data);
    }
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        clientMng.SendRequest(requestCode, actionCode, data);
    }

}
