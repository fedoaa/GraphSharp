using System.Collections.Generic;
using System.Windows;
using GraphSharp.AttachedBehaviors;

namespace GraphSharp.Controls
{
    public partial class VertexControl : IDragBehavior
    {
        public IEnumerable<FrameworkElement> GetChildElements()
        {
            foreach (EdgeControl control in AsSources)
            {
                VertexControl target = control.Target;
                yield return target;

                foreach (FrameworkElement element in target.GetChildElements())
                {
                    yield return element;
                }
            }
        }

        public EdgeControlCollection AsSources { get; } = new EdgeControlCollection();

        public EdgeControlCollection AsTargets { get; } = new EdgeControlCollection();



    }
}
