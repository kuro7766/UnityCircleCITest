using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class HelloUI : MyApp
{
    private string text = "no click";
    private bool accepted = false;

    public override Widget getFlutterCode(BuildContext context)
    {
        return new Center(child: new CustomScrollView(
            new PageStorageKey<string>("博主"),
            physics: new AlwaysScrollableScrollPhysics(),
            slivers: new List<Widget>
            {
                new SliverList(
                    del: new SliverChildBuilderDelegate(
                        builder: ((buildContext, index) =>
                        {
                            return new Text("item "+index);
                        }),
                        childCount: 50
                    )
                ),
            }
        ));

        // List<Widget> widgets = new List<Widget>();
        // for (int i = 20 - 1; i >= 0; i--)
        // {
        //     widgets.Add(new Text("item "+i));
        // }
        // return new Column(children: widgets);

        // return new Stack(children: new List<Widget>
        // {
        //     new Center(child: new Column(children: new List<Widget>
        //     {
        //         new RaisedButton(child: new Text(text),
        //             onPressed: (() => { text = "pressed"; }))
        //     }))
        // });
    }
}