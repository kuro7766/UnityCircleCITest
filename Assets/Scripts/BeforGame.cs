using System.Collections;
using System.Collections.Generic;
using com.unity.uiwidgets.Runtime.rendering;
using MyEvents;
using MyMessage;
using pEventBus;
using Photon.Pun;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class BeforGame : MyApp, IEventReceiver<ConnectionToMaster>, IEventReceiver<RoomUpdate>
{
    private TextEditingController _editingController = new TextEditingController();
    private List<Widget> rooms = new List<Widget>();

    protected override void OnEnable()
    {
        base.OnEnable();
        EventBus.Register(this);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventBus.UnRegister(this);
    }

    public override Widget getFlutterCode(BuildContext context)
    {
        return new Scaffold(
            backgroundColor: Colors.transparent,
            body:
            new ListView(children:
                new List<Widget>
                {
                    new Column(
                        children: new List<Widget>
                        {
                            new Text("input user nickname"),
                            new TextField(controller: _editingController),

                            new InkWell(onTap: (() => { }), child:
                                new SizedBox(height: 50, child:
                                    new Center(child:
                                        new Text("login")))
                            )
                        }
                    ),
                    new Column(
                        children: rooms
                    )
                }
            )
            ,
            resizeToAvoidBottomInset:
            true
        );
    }

    public void OnEvent(ConnectionToMaster e)
    {
        Debug.Log("receive CONN");
        rooms.Clear();
    }

    public void OnEvent(RoomUpdate e)
    {
        Debug.Log("ON ROOM UPDATE -");
        Debug.Log(e.RoomInfos.Count);
        rooms = new List<Widget>(rooms);
        
        foreach (var r in e.RoomInfos)
        {
            rooms.Add(new RaisedButton(child: new Text(r.Name + r.PlayerCount)));
        }
        setState();
    }
}