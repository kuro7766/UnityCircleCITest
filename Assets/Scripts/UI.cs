using System.Collections;
using System.Collections.Generic;
using MyUI.Reusable;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class UI : MyApp
{
    public override Widget getFlutterCode(BuildContext context)
    {
        return
            new Stack(children: new List<Widget>
            {
                new Align(alignment: Alignment.topRight,child:
                    new RaisedButton(onPressed:(() =>
                        {
                            
                        }),child:new Text("menu")))
                    ,
                new Center(child: new Text("Welcome to football game", style: new TextStyle(color: Colors.black
                    , fontSize: 50)))
            });
       
    }
}