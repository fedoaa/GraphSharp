using System.Collections.Generic;
using System.Linq;
using GraphSharp.Algorithms.Highlight;
using QuikGraph;

namespace GraphSharp.Controls
{
    public partial class GraphLayout<TVertex, TEdge, TGraph> : IHighlightController<TVertex, TEdge, TGraph>
        where TVertex : class
        where TEdge : IEdge<TVertex>
        where TGraph : class, IBidirectionalGraph<TVertex, TEdge>
    {
        #region IHighlightController<TVertex,TEdge,TGraph> Members

        private readonly IDictionary<TVertex, object> _highlightedVertices = new Dictionary<TVertex, object>();
        private readonly IDictionary<TVertex, object> _semiHighlightedVertices = new Dictionary<TVertex, object>();
        private readonly IDictionary<TEdge, object> _highlightedEdges = new Dictionary<TEdge, object>();
        private readonly IDictionary<TEdge, object> _semiHighlightedEdges = new Dictionary<TEdge, object>();

        public IEnumerable<TVertex> HighlightedVertices
        {
            get { return _highlightedVertices.Keys.ToArray(); }
        }

        public IEnumerable<TVertex> SemiHighlightedVertices
        {
            get { return _semiHighlightedVertices.Keys.ToArray(); }
        }

        public IEnumerable<TEdge> HighlightedEdges
        {
            get { return _highlightedEdges.Keys.ToArray(); }
        }

        public IEnumerable<TEdge> SemiHighlightedEdges
        {
            get { return _semiHighlightedEdges.Keys.ToArray(); }
        }

        public bool IsHighlightedVertex(TVertex vertex)
        {
            return _highlightedVertices.ContainsKey(vertex);
        }

        public bool IsHighlightedVertex(TVertex vertex, out object highlightInfo)
        {
            return _highlightedVertices.TryGetValue(vertex, out highlightInfo);
        }

        public bool IsSemiHighlightedVertex(TVertex vertex)
        {
            return _semiHighlightedVertices.ContainsKey(vertex);
        }

        public bool IsSemiHighlightedVertex(TVertex vertex, out object semiHighlightInfo)
        {
            return _semiHighlightedVertices.TryGetValue(vertex, out semiHighlightInfo);
        }

        public bool IsHighlightedEdge(TEdge edge)
        {
            return _highlightedEdges.ContainsKey(edge);
        }

        public bool IsHighlightedEdge(TEdge edge, out object highlightInfo)
        {
            return _highlightedEdges.TryGetValue(edge, out highlightInfo);
        }

        public bool IsSemiHighlightedEdge(TEdge edge)
        {
            return _semiHighlightedEdges.ContainsKey(edge);
        }

        public bool IsSemiHighlightedEdge(TEdge edge, out object semiHighlightInfo)
        {
            return _semiHighlightedEdges.TryGetValue(edge, out semiHighlightInfo);
        }

        public void HighlightVertex(TVertex vertex, object highlightInfo)
        {
            _highlightedVertices[vertex] = highlightInfo;
            VertexControl vc;
            if (VertexControls.TryGetValue(vertex, out vc))
            {
                GraphElementBehavior.SetIsHighlighted(vc, true);
                GraphElementBehavior.SetHighlightInfo(vc, highlightInfo);
            }
        }

        public void SemiHighlightVertex(TVertex vertex, object semiHighlightInfo)
        {
            _semiHighlightedVertices[vertex] = semiHighlightInfo;
            VertexControl vc;
            if (VertexControls.TryGetValue(vertex, out vc))
            {
                GraphElementBehavior.SetIsSemiHighlighted(vc, true);
                GraphElementBehavior.SetSemiHighlightInfo(vc, semiHighlightInfo);
            }
        }

        public void HighlightEdge(TEdge edge, object highlightInfo)
        {
            _highlightedEdges[edge] = highlightInfo;
            EdgeControl ec;
            if (EdgeControls.TryGetValue(edge, out ec))
            {
                GraphElementBehavior.SetIsHighlighted(ec, true);
                GraphElementBehavior.SetHighlightInfo(ec, highlightInfo);
            }
        }

        public void SemiHighlightEdge(TEdge edge, object semiHighlightInfo)
        {
            _semiHighlightedEdges[edge] = semiHighlightInfo;
            EdgeControl ec;
            if (EdgeControls.TryGetValue(edge, out ec))
            {
                GraphElementBehavior.SetIsSemiHighlighted(ec, true);
                GraphElementBehavior.SetSemiHighlightInfo(ec, semiHighlightInfo);
            }
        }

        public void RemoveHighlightFromVertex(TVertex vertex)
        {
            _highlightedVertices.Remove(vertex);
            VertexControl vc;
            if (VertexControls.TryGetValue(vertex, out vc))
            {
                GraphElementBehavior.SetIsHighlighted(vc, false);
                GraphElementBehavior.SetHighlightInfo(vc, null);
            }
        }

        public void RemoveSemiHighlightFromVertex(TVertex vertex)
        {
            _semiHighlightedVertices.Remove(vertex);
            VertexControl vc;
            if (VertexControls.TryGetValue(vertex, out vc))
            {
                GraphElementBehavior.SetIsSemiHighlighted(vc, false);
                GraphElementBehavior.SetSemiHighlightInfo(vc, null);
            }
        }

        public void RemoveHighlightFromEdge(TEdge edge)
        {
            _highlightedEdges.Remove(edge);
            EdgeControl ec;
            if (EdgeControls.TryGetValue(edge, out ec))
            {
                GraphElementBehavior.SetIsHighlighted(ec, false);
                GraphElementBehavior.SetHighlightInfo(ec, null);
            }
        }

        public void RemoveSemiHighlightFromEdge(TEdge edge)
        {
            _semiHighlightedEdges.Remove(edge);
            EdgeControl ec;
            if (EdgeControls.TryGetValue(edge, out ec))
            {
                GraphElementBehavior.SetIsSemiHighlighted(ec, false);
                GraphElementBehavior.SetSemiHighlightInfo(ec, null);
            }
        }

        #endregion

        protected void SetHighlightProperties(TVertex vertex, VertexControl presenter)
        {
            object highlightInfo;
            if (IsHighlightedVertex(vertex, out highlightInfo))
            {
                GraphElementBehavior.SetIsHighlighted(presenter, true);
                GraphElementBehavior.SetHighlightInfo(presenter, highlightInfo);
            }

            object semiHighlightInfo;
            if (IsSemiHighlightedVertex(vertex, out semiHighlightInfo))
            {
                GraphElementBehavior.SetIsSemiHighlighted(presenter, true);
                GraphElementBehavior.SetSemiHighlightInfo(presenter, semiHighlightInfo);
            }
        }

        protected void SetHighlightProperties(TEdge edge, EdgeControl edgeControl)
        {
            object highlightInfo;
            if (IsHighlightedEdge(edge, out highlightInfo))
            {
                GraphElementBehavior.SetIsHighlighted(edgeControl, true);
                GraphElementBehavior.SetHighlightInfo(edgeControl, highlightInfo);
            }

            object semiHighlightInfo;
            if (IsSemiHighlightedEdge(edge, out semiHighlightInfo))
            {
                GraphElementBehavior.SetIsSemiHighlighted(edgeControl, true);
                GraphElementBehavior.SetSemiHighlightInfo(edgeControl, semiHighlightInfo);
            }
        }
    }
}
