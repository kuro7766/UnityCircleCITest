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
    private GameObject[] _gameObjects;
    private GameObject[] _barObjects;

    protected override void OnEnable()
    {
        base.OnEnable();
        _gameObjects = new[]
        {
            GameObject.Find("Sphere (0)"),
            GameObject.Find("Sphere (1)"),
            GameObject.Find("Sphere (2)"),
            GameObject.Find("Sphere (3)"),
            GameObject.Find("Sphere (4)"),
            GameObject.Find("Sphere (5)"),
            GameObject.Find("Sphere (6)"),
            GameObject.Find("Sphere (7)"),
        };
        _barObjects = new[]
        {
            GameObject.Find("Group16"),
            GameObject.Find("Group13"),
            GameObject.Find("Group11"),
            GameObject.Find("Group15"),
            GameObject.Find("Group10"),
            GameObject.Find("Group14"),
            GameObject.Find("Group9"),
            GameObject.Find("Group12"),
        };
    }

    public override Widget getFlutterCode(BuildContext context)
    {
        return
            new Stack(children: new List<Widget>
            {
                new Align(alignment: Alignment.topCenter, child: new Text("Welcome to football game",
                    style: new TextStyle(color: Colors.black
                        , fontSize: 50))),
                new GestureDetector(
                    child: new Container(color: Colors.transparent),
                    onPanUpdate: (details =>
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (IsRed(i))
                            {
                                _barObjects[i].transform.RotateAround(_gameObjects[i].transform.position, Vector3.back,
                                    4 * details.delta.dx);
                                _barObjects[i].transform.Translate(0, 0, -details.delta.dy * 0.1f);
                            }
                        }

                    })
                )
            });
    }

    bool IsRed(int i)
    {
        return i == 0 
               || i == 1
               || i == 3
               || i == 5
            ;
    }
}