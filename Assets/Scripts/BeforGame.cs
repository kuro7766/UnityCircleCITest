using System.Collections;
using System.Collections.Generic;
using com.unity.uiwidgets.Runtime.rendering;
using MyEvents;
using MyMessage;
using pEventBus;
using Photon.Pun;
using Photon.Realtime;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

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
        return
            new Scaffold(
                backgroundColor: Colors.transparent,
                body:
                new Column(children:
                    new List<Widget>
                    {
                        new Text("input user nickname"),
                        new TextField(controller: _editingController),

                        new Builder(builder: (buildContext =>
                        {
                            return new InkWell(
                                onTap: (() =>
                                {
                                    Scaffold.of(buildContext).showSnackBar(
                                        new SnackBar(content:
                                            new Text("snsldkf")));
                                    PhotonNetwork.JoinOrCreateRoom(_editingController.text,
                                        new RoomOptions() {MaxPlayers = 2}, default);
                                }), child:
                                new SizedBox(height: 50, child:
                                    new Center(child:
                                        new Text("login")))
                            );
                        })),

                        new Expanded(child:
                            new ListView(children: GetRooms())),
                    }
                )
                ,
                resizeToAvoidBottomInset:
                true
            );
    }

    private List<Widget> GetRooms()
    {
        Debug.Log("xxx " + rooms.Count);

        if (rooms.Count > 0)
        {
            return rooms;
        }
        else
        {
            List<Widget> list = new List<Widget>();
            list.Add(
                new Text("empty")
            );
            Debugger.Log(1, list.Count + "");
            return list;
        }
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
            rooms.Add(new RaisedButton(onPressed: (() => { }), child: new Text(r.Name + r.PlayerCount)));
        }

        setState();
    }
}