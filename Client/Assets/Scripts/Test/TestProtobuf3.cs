﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net;
using Msg;
using UnityDebuger;

public class TestProtobuf3 : MonoBehaviour
{
    #region 变量

    public GameObject mSendMsgGo;

    /// <summary>
    /// 显示信息
    /// </summary>
    public UILabel mShowInfo;

    #endregion

    #region 内置函数

    // Use this for initialization
    void Start ()
    {
        UIEventListener.Get(mSendMsgGo).onClick = OnSendMsgGoClick;

        NetManager.Instance.AddHandler(typeof(TocChat), TocChatCallback);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #endregion

    #region 回调函数

    private void OnSendMsgGoClick(GameObject go)
    {
        TosChat tos = new TosChat();
        tos.Name = name;
        tos.Content = "xieliujian";

        NetManager.Instance.SendMessage(tos);
    }

    private void TocChatCallback(object obj)
    {
        TocChat msg = (TocChat)obj;
        if (msg == null)
            return;

        Debuger.Log(msg.ToString());
        mShowInfo.text += msg.ToString();
        mShowInfo.text += "\n";
    }

    #endregion
}
