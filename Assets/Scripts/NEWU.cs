using System;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using System.Collections.Generic;
using MyUI.Reusable;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class NEWU : StatefulWidget
{
    public override State createState()
    {
        return new _CustomActivityIndicatorStateX();
    }
}

class _CustomActivityIndicatorStateX : State<NEWU>
{
    private GameObject[] _gameObjects;
    private GameObject[] _barObjects;
    private String _msg = "加载中";
    private bool _msgVisibility = false;
    private List<Widget> _msgList = new List<Widget>();

    public override void initState()
    {
        base.initState();

        //this._controller.addStatusListener((status => { Debug.Log($"{status}"); }));
    }

    public override Widget build(BuildContext context)
    {
        return
            new Stack(children: new List<Widget>
            {
                new GestureDetector(
                    child: new Container(color: Colors.transparent),
                    onPanUpdate: (details => { })
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
                                        _msgList.Add(new Text("test"));
                                        setState();
                                    }))
                                }))
                            )
                            , visible: _msgVisibility),
                        new Align(alignment: Alignment.topCenter, child: new GestureDetector(child:
                            new WhiteRoundBox(child: new Text("dflkj"))
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

    public override void dispose()
    {
        base.dispose();
    }
}