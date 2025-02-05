// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using UnityEngine;

namespace UnityCommon
{
	public static class CloneUtils
	{
		public static Mesh Clone(Mesh mesh)
		{
			return new Mesh
			{
				vertices = mesh.vertices,
				triangles = mesh.triangles,
				uv = mesh.uv,
				normals = mesh.normals,
				colors = mesh.colors,
				tangents = mesh.tangents
			};
		}
	}
}