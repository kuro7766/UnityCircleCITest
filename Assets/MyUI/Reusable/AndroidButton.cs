using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Image = Unity.UIWidgets.widgets.Image;
using Transform = Unity.UIWidgets.widgets.Transform;
using Stack = Unity.UIWidgets.widgets.Stack;

public class AndroidButton : MyApp
{
    public static bool l = false;
    public static bool t = false;
    public static bool r = false;
    public static bool b = false;

    public override Widget getFlutterCode(BuildContext context)
    {
        return
            new Stack(children: new List<Widget>
            {
                new Row(mainAxisAlignment: MainAxisAlignment.end, children: new List<Widget>
                {
                    new Column(mainAxisAlignment: MainAxisAlignment.end,children: new List<Widget>
                    {
                        Transform.rotate(degree: 1.57f, child:
                            new GestureDetector(child: Image.asset("arr", scale: 3f), onPanDown: ((d) => { t = true; }),
                                onPanEnd: (details => { t = false; }))
                            , origin: new Offset(5, 50)),
                        Transform.rotate(degree: -1.57f,origin:new Offset(5,-10),child:
                            new GestureDetector(child: Image.asset("arr", scale: 3f), onPanDown: ((d) => { b = true; }),
                                onPanEnd: (details => { b = false; }))
                        ),
                        new SizedBox(height:45)
                    })
                }),
                new Row(children: new List<Widget>
                {
                    Transform.rotate(degree: 3.14f, child:
                        new GestureDetector(onPanDown: ((d) =>
                            {
                                l = true;
                                Debug.Log("l tapped");
                            }),
                            onPanEnd: (details =>
                            {
                                l = false;
                                Debug.Log("pandend");
                            }), child: Image.asset("arr", scale: 3f))
                        , origin: new Offset(40, 20)),
                    new GestureDetector(child: Image.asset("arr", scale: 3f), onPanDown: ((d) => { r = true; }),
                        onPanEnd: (details => { r = false; })),
                })
            });
    }
}