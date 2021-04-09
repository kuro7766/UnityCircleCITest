using System;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;


public class MyWidgetParent : StatefulWidget
{
    private State currentState;

    public delegate Widget WidgetBuilder(BuildContext context);

    public void setState()
    {
        currentState.setState();
    }

    public MyWidgetParent(
        Key key = null,
        WidgetBuilder builder = null
    ) : base(key: key)
    {
        this.builder = builder;
    }

    public WidgetBuilder builder;
    public readonly AnimationController controller;

    public override State createState()
    {
        currentState = new _CustomActivityIndicatorState();
        return currentState;
    }
}

class _CustomActivityIndicatorState : State<MyWidgetParent>, TickerProvider
{
    AnimationController _controller;


    public override void initState()
    {
        base.initState();

        if (this.widget.controller == null)
        {
            this._controller = new AnimationController(
                duration: new TimeSpan(0, 0, 1),
                vsync: this
            );
            this._controller.repeat();
        }
        else
        {
            this._controller = this.widget.controller;
        }

        //this._controller.addStatusListener((status => { Debug.Log($"{status}"); }));
    }

    public Ticker createTicker(TickerCallback onTick)
    {
        return new Ticker(onTick: onTick, () => $"created by {this}");
    }

    public override void didUpdateWidget(StatefulWidget oldWidget)
    {
        base.didUpdateWidget(oldWidget: oldWidget);
        if (oldWidget is MyWidgetParent customActivityIndicator)
        {
        }
    }

    public override Widget build(BuildContext context)
    {
        return this.widget.builder(context);
        
        
        // return new AnimatedBuilder(
        //     animation: this._controller,
        //     builder: (cxt, widget) => { return this.widget.builder(context); }
        // );
    }

    public override void dispose()
    {
        if (this.widget.controller == null)
        {
            this._controller.dispose();
        }

        base.dispose();
    }
}