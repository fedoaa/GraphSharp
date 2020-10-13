using System.Collections.Generic;
using System.Windows;

namespace GraphSharp.AttachedBehaviors
{
    public interface IDragBehavior
    {
        IEnumerable<FrameworkElement> GetChildElements();
    }
}
