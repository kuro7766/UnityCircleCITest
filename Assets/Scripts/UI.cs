﻿using System;
using System.Collections;
using System.Collections.Generic;
using MyUI.Reusable;
using pEventBus;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class UI : MyApp, IEventReceiver<ConnectionToMaster>
{
    private GameObject[] _gameObjects;
    private GameObject[] _barObjects;
    private String _msg = "加载中";
    private bool _msgVisibility = false;
    private List<Widget> _msgList = new List<Widget>();

    protected override void OnEnable()
    {
        base.OnEnable();
        _gameObjects = new[]
        {
            GameObject.Find("Sphere (0)"),
            GameObject.Find("Sphere (1)"),
            GameObject.Find("Sphere (2)"),
            GameObject.Find("Sphere (3)"),
            GameObject.Find("Sphere (4)"),
            GameObject.Find("Sphere (5)"),
            GameObject.Find("Sphere (6)"),
            GameObject.Find("Sphere (7)"),
        };
        _barObjects = new[]
        {
            GameObject.Find("Group16"),
            GameObject.Find("Group13"),
            GameObject.Find("Group11"),
            GameObject.Find("Group15"),
            GameObject.Find("Group10"),
            GameObject.Find("Group14"),
            GameObject.Find("Group9"),
            GameObject.Find("Group12"),
        };
        EventBus.Register(this);
    }

    public override Widget getFlutterCode(BuildContext context)
    {
        return
            new Stack(children: new List<Widget>
            {
                new GestureDetector(
                    child: new Container(color: Colors.transparent),
                    onPanUpdate: (details =>
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (IsRed(i))
                            {
                                _barObjects[i].transform.RotateAround(_gameObjects[i].transform.position, Vector3.back,
                                    4 * details.delta.dx * 0.1f);
                                _barObjects[i].transform.Translate(0, 0, -details.delta.dy * 0.02f);
                            }
                        }
                    })
                ),
                new Align(alignment: Alignment.topLeft, child: new Row(
                    children: new List<Widget>
                    {
                        new Visibility(child:
                            new SizedBox(width: 200, child:
                                new Container(color: Colors.lightBlue, child: new Column(children: new List<Widget>
                                {
                                    new Expanded(
                                        child: new ListView(children:
                                            _msgList
                                        )
                                    ),
                                    new GestureDetector(child: new Container(width: float.PositiveInfinity, child:
                                        new WhiteRoundBox(child: new Text("btm"))
                                    ), onTap: (() =>
                                    {
                                        _msgList=new List<Widget>(_msgList);
                                        _msgList.Add(new Text("test"));
                                        setState();
                                    }))
                                }))
                            )
                            , visible: _msgVisibility),
                        new Align(alignment: Alignment.topCenter, child: new GestureDetector(child:
                            new WhiteRoundBox(child: new Text(_msgVisibility?"展开":"收回"))
                            , onTap: (() =>
                            {
                                _msgVisibility = !_msgVisibility;
                                setState();
                            })))
                    }
                )),

                new Align(alignment: Alignment.topCenter, child:
                    new Column(children: new List<Widget>
                    {
                        new CircularProgressIndicator(),
                        new Text(_msg,
                            style: new TextStyle(color: Colors.black
                                , fontSize: 30)),
                    })
                ),
            });
    }

    bool IsRed(int i)
    {
        return i == 0
               || i == 1
               || i == 3
               || i == 5
            ;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventBus.UnRegister(this);
    }

    public void OnEvent(ConnectionToMaster e)
    {
        _msg = "连接成功";
        List<Widget> n=new List<Widget>(_msgList);
        n.Add(new Text("连接成功"));
        _msgList = n;
        Debug.Log("recv");
        setState((() => { }));
    }
}