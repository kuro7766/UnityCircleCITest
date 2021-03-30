using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class UI : MyApp
{
    public override Widget getFlutterCode(BuildContext context)
    {
        return new Center( child:new Text("Welcome to football game" ,style:new TextStyle(color: Colors.black
        ,fontSize:50)));
    }
}
