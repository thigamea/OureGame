using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
public class LoginPanel : BasePanel
{

    public InputField usernameIF;
    public InputField passwordIF;
    private LoginRequest loginRequest;
    //private Button loginButton;
    //private Button registerButton;
    void Awake()
    {
        loginRequest = GetComponent<LoginRequest>();
    }
    private void Start()
    {
    }
    public void OnClickRegisterBut()
    {
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "密码不能为空 ";
        }
        Debug.Log("按钮点击成功");
        loginRequest.sendRequest(usernameIF.text, passwordIF.text);
    }
    public void OnLoginResponse(ReturnCode returnCode)
    {
        Debug.Log("准备切换界面");
        if (returnCode == ReturnCode.Success)
        {
            GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.MainMenu);
        }
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }



}
