using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public class Debugger
{
    private static int _level = 0;

    public static void Log(int lv, string s)
    {
        if (lv > _level)
        {
            Debug.Log(lv+ " : " + s);
        }
    }
}