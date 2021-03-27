using System;
using System.Collections;
using System.Collections.Generic;
using RSG;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class DBG : MyApp
{
    private ScrollController _scrollController = new ScrollController();
    List<Widget> ch = new List<Widget>() {new Text("Debug面板")};
    private static DBG instance { get; set; }

    public override Widget getFlutterCode(BuildContext context)
    {
        instance = this;
        return new Column(children: new List<Widget>
        {
            new SizedBox(height:200,child:
            new ListView(
                children: ch
                , controller: _scrollController
            ))
        });
    }

    public static void Log(string s)
    {
        if (instance != null)
        {
            List<Widget> l = new List<Widget>();
            l.AddRange(instance.ch);
            // l.Add(new Text(s));
            l.Insert(0,new Text(s));
            instance.ch = l;
            instance.setState();
            // Promise.Delayed(TimeSpan.FromMilliseconds(1000)).Then(() => {
            //     instance.ScrollToBottom();
            // });
            // instance.StartCoroutine(instance.ScrollToBottom());
        }
    }

    private void ScrollToBottom()
    {
       Debug.Log("scooling");
        _scrollController.animateTo(_scrollController.position.maxScrollExtent,
            duration: new TimeSpan(0, 0, 2),
            curve: Curves.fastOutSlowIn);
    }
}