using System;
using System.Collections;
using System.Collections.Generic;
using pEventBus;
using Photon.Realtime;
using UnityEngine;

namespace MyMessage
{
    public struct ClientMessage
    {
        public int code;
    }

    public struct RoomUpdate : IEvent
    {
        public List<RoomInfo> RoomInfos;
    }
}
