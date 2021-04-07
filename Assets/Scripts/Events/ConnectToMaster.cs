using System;
using System.Collections;
using System.Collections.Generic;
using pEventBus;
using UnityEngine;

namespace MyEvents
{
    public struct ConnectionToMaster : IEvent
    {
    }

    public struct UiMessage : IEvent
    {
        public String msg;

        public UiMessage(string msg)
        {
            this.msg = msg;
        }
    }

    public struct ChatMessage : IEvent
    {
        public String msg;
    }

    public struct PunEvent : IEvent
    {
        
    }
}