using UnityEngine;

namespace MomIsComing.Scripts.UsefulExtensions.Runtime
{
    public static class GameObjectExtensions
    {
        public static Component GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent(out T tcomponent))
            {
                return tcomponent;
            }

            return gameObject.AddComponent<T>();
        }
        
        public static bool IsRenderedByCamera(this Transform transform, bool checkFrustumOnly = false, Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            if (camera == null)
            {
                Debug.LogWarning("Camera not found!");
                return false;
            }

            if (checkFrustumOnly)
            {
                if (transform.IsInFrustum()) return true;
            }

            Vector3 viewportPoint = camera.WorldToViewportPoint(transform.position);

            if (viewportPoint.z < 0 || viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1)
            {
                return false;
            }
            
            Ray ray = new Ray(camera.transform.position, (transform.position - camera.transform.position).normalized);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                return hit.transform == transform;
            }

            return false;
        }
        
        public static bool IsInFrustum(this Transform targetTransform, Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            if (camera == null)
            {
                Debug.LogWarning("Camera not found!");
                return false;
            }

            Plane[] cameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);

            Vector3 targetPosition = targetTransform.position;
            return GeometryUtility.TestPlanesAABB(cameraFrustumPlanes, new Bounds(targetPosition, Vector3.zero));
        }
    }
}
