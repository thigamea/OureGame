using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class DataRequest : BaseRequest
{
    public override void Awake()
    {
    }
    public  void RegisterAction()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.GetPlayInspecture;
        base.Awake();
    }
    public void sendRequest(string username)
    {
        string data = username;
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        resertPlayerIns(data);
        GameFacade.Instance.isLoad = true;
    }
    //初始化角色属性
    public void resertPlayerIns(string data)
    {
        Debug.Log("加载角色数据成功");
        string[] strs = data.Split(',');
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        PlayerManager.Instance.playerCoin.nicheng = strs[1];
        PlayerManager.Instance.playerCoin.qianneng = int.Parse(strs[2]);
        PlayerManager.Instance.playerCoin.jinbi = int.Parse(strs[3]);
        PlayerManager.Instance.playerCoin.yuanbao = int.Parse(strs[4]);
        PlayerManager.Instance.playerCoin.lingshi = int.Parse(strs[5]);
        PlayerManager.Instance.playerCoin.exp = int.Parse(strs[6]);
        PlayerManager.Instance.playerCoin.lev = int.Parse(strs[7]);
        if (returnCode == ReturnCode.Success)
        {

            Debug.Log("获取角色数据成功");
        }
    }
}
