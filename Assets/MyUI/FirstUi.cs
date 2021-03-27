using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
using Stack = Unity.UIWidgets.widgets.Stack;
using Transform = Unity.UIWidgets.widgets.Transform;

public class FirstUi : MyUpdateApp
{
    private int counter = 0;
    private float y = 0;
    private float r = 0;
    private float opacity = 1;
    public override Widget getFlutterCode(BuildContext context)
    {
        var l=Mathf.Lerp(y, Screen.height / 2.0f,Time.deltaTime);
        y =l;
        // Debug.Log(y);
        opacity = (Screen.height - y) / Screen.height;
        Debug.Log(opacity);
        return new Stack(children: new List<Widget>
        {
            new Positioned(top: y,
                child: new GestureDetector(
                    child: new RotatedBox(quarterTurns: 0, child: Transform.rotate(degree: 0,
                        child: new Text($"{counter} - " + (int)(Time.time),
                            style: new TextStyle(color: Color.black.withOpacity((opacity-0.5f)*2))))),
                    onTap: (() => { counter++;
                    })))
        });
    }

}