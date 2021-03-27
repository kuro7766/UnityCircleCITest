using System.Collections;
using System.Collections.Generic;
using MyUI.Reusable;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Stack = Unity.UIWidgets.widgets.Stack;

public class GoWithMouse : StatefulWidget
{
    public override State createState()
    {
        return new MyClass();
    }
}

class MyClass : State
{
    private float _x;
    private float _y;
    private float _localx;
    private float _localy;
    private bool firstTap = true;

    public override Widget build(BuildContext context)
    {
        return
            new Positioned(left: _x - _localx, top: _y - _localy, child:
                new Container(color: Colors.white, child:
                    new WhiteRoundBox(child: new GestureDetector(onPanDown: (details =>
                        {
                            if (firstTap)
                            {
                                _localx = details.globalPosition.dx;
                                _localy = details.globalPosition.dy;
                                firstTap = false;
                            }
                            else
                            {
                                var left = _x - _localx;
                                var leftUp = _y - _localy;
                                _localx = details.globalPosition.dx - left;
                                _localy = details.globalPosition.dy - leftUp;
                            }

                            // _localx = details.localPosition.dx;
                            // //_localx = _x - _localx;
                            // _localy = details.localPosition.dy;
                            // //_localy = _y - _localy;
                        }),
                        onPanUpdate: (details =>
                        {
                            _x = details.globalPosition.dx;
                            _y = details.globalPosition.dy;
                            setState();
                        }), onPanEnd: (details => { }),
                        child: new Text($"move me _x:{_x},_y:{_y},_localx:{_localx},_localy:{_localy}")))
                )
            )
            ;
    }
}