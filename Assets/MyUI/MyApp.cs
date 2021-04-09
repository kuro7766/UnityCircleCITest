using System;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

public abstract class MyApp : UIWidgetsPanel
{
    //public delegate Widget build(BuildContext context);

    public MyWidgetParent widget;
    public abstract Widget getFlutterCode(BuildContext context);
    public delegate void CallBack();
    public void setState(CallBack callBack=null)
    {
        widget.setState();
    }
    
    protected override Widget createWidget()
    {

        widget = new MyWidgetParent(builder: (context => getFlutterCode(context)));
        
        return new MaterialApp(
            home: widget
            );
        
        // return new WidgetsApp(
        //     home: widget,
        //     pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
        //         new PageRouteBuilder(
        //             settings: settings,
        //             pageBuilder: (BuildContext context, Animation<float> animation,
        //                 Animation<float> secondaryAnimation) => builder(context)
        //         )
        // );
    }
}