using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class RushThrough : StatefulWidget
{
    public override State createState()
    {
        return new RS();
    }
}

class RS : State
{
    private float x = 0;
    private float y = Random.Range(0, 300);
    private float speed = Random.Range(30,70);

    public override Widget build(BuildContext context)
    {
        return new MyUpdateWidget(builder: (buildContext =>
        {
            x += speed * Time.deltaTime;
            return
                new Stack(children: new List<Widget>
                {
                    new Positioned(left: x, top: y, child: new Text($"{x}"))
                });
        }));
    }
}