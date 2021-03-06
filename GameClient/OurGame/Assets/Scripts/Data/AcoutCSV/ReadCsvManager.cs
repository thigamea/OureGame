﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCsvManager : MonoBehaviour {
    private static ReadCsvManager instance;
    public int c = 10;
    public static ReadCsvManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("GameFacade").GetComponent<ReadCsvManager>();
            return instance;
        }   
    }
   public List<LevData> levdata;
    void Awake()
    {
        levdata = ReadLexData();
        Debug.Log(levdata[0].currName+"当前目标经验："+levdata[0].targetExp);
    }

   public List<LevData> ReadLexData()
    {
         levdata=new List<LevData>();
        //读取csv二进制文件
        TextAsset binAsset = Resources.Load("人物境界", typeof(TextAsset)) as TextAsset;
        //读取每一行的内容
        string[] lineArray = binAsset.text.Split("\r"[0]);

        for (int i = 1; i < lineArray.Length; i++)
        {
            string[] lineArray1 = lineArray[i].Split(","[0]);
            LevData tempData = new LevData();
            tempData.currName = lineArray1[0];
            tempData.targetExp = int.Parse(lineArray1[2]);
            tempData.currExpRate = int.Parse(lineArray1[1]);
            levdata.Add(tempData);
        }
        return levdata;
    }


}

