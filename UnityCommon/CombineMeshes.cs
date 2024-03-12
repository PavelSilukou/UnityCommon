using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityCommon
{
    // TODO: not optimized
    public class CombineMeshes
    {
        public void Combine(GameObject target)
        {
            var oldRotation = target.transform.rotation;
            var oldPosition = target.transform.position;
            
            target.transform.rotation = Quaternion.identity;
            target.transform.position = Vector3.zero;

            var filters = target.GetComponentsInChildren<MeshFilter>(false);

            var materials = new List<Material>();
            var renderers = target.GetComponentsInChildren<MeshRenderer>(false);
            foreach (var renderer in renderers)
            {
                if (renderer.transform == target.transform)
                {
                    continue;
                }
                var localMaterials = renderer.sharedMaterials;
                foreach (var localMaterial in localMaterials)
                {
                    if (!materials.Contains(localMaterial))
                    {
                        materials.Add(localMaterial);
                    }
                }
            }

            var subMeshes = new List<Mesh>();
            foreach (var material in materials)
            {
                var combineInstances = new List<CombineInstance>();
                foreach (var filter in filters)
                {
                    if (filter.transform == target.transform)
                    {
                        continue;
                    }
                    var renderer = filter.GetComponent<MeshRenderer>();
                    if (renderer == null)
                    {
                        continue;
                    }

                    var localMaterials = renderer.sharedMaterials;
                    for (var materialIndex = 0; materialIndex < localMaterials.Length; materialIndex++)
                    {
                        if (localMaterials[materialIndex] != material)
                        {
                            continue;
                        }
                        
                        var combineInstance = new CombineInstance
                        {
                            mesh = filter.sharedMesh,
                            subMeshIndex = materialIndex,
                            transform = filter.transform.localToWorldMatrix
                        };
                        combineInstances.Add(combineInstance);
                    }
                }

                var mesh = new Mesh();
                mesh.CombineMeshes(combineInstances.ToArray(), true);
                subMeshes.Add(mesh);
            }

            var finalMesh = new Mesh();
            finalMesh.CombineMeshes(subMeshes.Select(mesh => new CombineInstance { mesh = mesh, subMeshIndex = 0, transform = Matrix4x4.identity }).ToArray(), false);
            target.GetComponent<MeshFilter>().sharedMesh = finalMesh;

            var meshRenderer = target.GetComponent<MeshRenderer>();
            meshRenderer.materials = materials.ToArray();
            
            target.transform.rotation = oldRotation;
            target.transform.position = oldPosition;
        }
    }
}