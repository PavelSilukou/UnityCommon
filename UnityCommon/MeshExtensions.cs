using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace UnityCommon
{
	public static class MeshExtensions
	{
		public static List<Vector3> GetTriangleVertices(this Mesh mesh, int start, int count)
		{
			var triangles = mesh.GetTriangleVertexIndices(start, count);
			var vertices = new List<Vector3>(mesh.vertices);
			var min = triangles.Min();
			var max = triangles.Max();
			return vertices.GetRange(min, max - min + 1);
		}

		public static List<int> GetTriangleVertexIndices(this Mesh mesh, int start, int count)
		{
			return new List<int>(mesh.triangles).GetRange(start * 3, count * 3);
		}
	}
}