using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Canvas = UnityEngine.Canvas;

public class BallShadow : MyApp
{
    private GameObject _follow;
    protected override void OnEnable()
    {
        base.OnEnable();
        _follow=GameObject.Find("Ball 3DS");
    }

    public override Widget getFlutterCode(BuildContext context)
    {
        
        return new Container(child:new CustomPaint(painter: new MakeCircle()));
    }
    class MakeCircle : CustomPainter {
        public void addListener(VoidCallback listener)
        {
            
        }

        public void removeListener(VoidCallback listener)
        {
            
        }

        public void paint(Unity.UIWidgets.ui.Canvas canvas, Size size)
        {
            var paint =new  Paint();
                paint.color = Colors.red;
                paint.strokeCap = StrokeCap.round;
                paint.strokeWidth = 10;
                paint.style = PaintingStyle.stroke; //important set stroke style

                var path = new Path();
                // path.moveTo(10, 10);
                // path.arcToPoint(new Offset(size.width - 10, size.height - 10),
                //     radius: Radius.circular(100));
                path.addCircle(50,50,40);
            canvas.drawPath(path, paint);
        }

        public bool shouldRepaint(CustomPainter oldDelegate)
        {
            return false;
        }

        public bool? hitTest(Offset position)
        {
            return false;
        }
    }

    private void FixedUpdate()
    {
        var transform1 = transform;
        var position = _follow.transform.position;
        transform1.position=new Vector3( position.x,transform1.position.y,position.z);
    }
}
