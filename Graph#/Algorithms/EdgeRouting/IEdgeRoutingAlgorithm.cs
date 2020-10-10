using System.Collections.Generic;
using QuikGraph.Algorithms;
using QuikGraph;
using System.Windows;

namespace GraphSharp.Algorithms.EdgeRouting
{
	public interface IEdgeRoutingAlgorithm<TVertex, TEdge, TGraph> : IAlgorithm<TGraph>
		where TEdge : IEdge<TVertex>
		where TGraph : IVertexAndEdgeListGraph<TVertex, TEdge>
	{
		IDictionary<TEdge, Point[]> EdgeRoutes { get; }
	}
}