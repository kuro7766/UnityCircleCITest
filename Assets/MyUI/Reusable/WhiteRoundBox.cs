using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace MyUI.Reusable
{
    public class WhiteRoundBox : StatefulWidget
    {
        private Widget _child;
        
        public WhiteRoundBox(Widget child=null)
        {
            this._child = child;
        }
        public override State createState()
        {
            return new MyClass();
        }

        class MyClass : State<WhiteRoundBox>
        {
            public override Widget build(BuildContext context)
            {
                return new Container(child:
                    new Padding(padding: EdgeInsets.all(5),
                        child: widget._child)
                    , decoration: new BoxDecoration(color: Colors.white, borderRadius: BorderRadius.all(10)));
            }
        }
    }
}
