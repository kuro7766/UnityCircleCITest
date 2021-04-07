using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class NEWUI : UIWidgetsPanel
{
    protected override Widget createWidget()
    {
        var widget = new NEWU();
        return new WidgetsApp(
            home: widget,
            pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
                new PageRouteBuilder(
                    settings: settings,
                    pageBuilder: (BuildContext context, Animation<float> animation,
                        Animation<float> secondaryAnimation) => builder(context)
                )
        );
    }
}

