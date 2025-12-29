using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class ObjectsPool<TPoolable> where TPoolable : MonoBehaviour, IPoolable
    {
        private readonly Queue<TPoolable> _pool;
        private readonly TPoolable _poolablePrefab;
        private readonly Transform _poolParent;

        private readonly int _prewarmBatchSize;

        public ObjectsPool(TPoolable poolablePrefab, int capacity, Transform parent)
        {
            _poolablePrefab = poolablePrefab;
            _poolParent = parent;
            _pool = new Queue<TPoolable>(capacity);

            Prewarm(capacity);
        }

        private async void Prewarm(int count)
        {
            int created = 0;
            while (created < count)
            {
                for (int i = 0; i < _prewarmBatchSize; i++)
                {
                    CreatePoolable();
                    created++;
                }

                await Task.Yield();
            }
        }

        private void CreatePoolable()
        {
            var newPoolable = Object.Instantiate(_poolablePrefab, _poolParent);
            newPoolable.gameObject.SetActive(false);
            newPoolable.OnCreated();
            _pool.Enqueue(newPoolable);
        }

        public TPoolable Get()
        {
            if (_pool.Count == 0)
                CreatePoolable();

            var poolable = _pool.Dequeue();
            poolable.gameObject.SetActive(true);
            poolable.OnGet();
            return poolable;
        }

        public void Release(TPoolable poolable)
        {
            if (poolable.gameObject.activeSelf == false)
                return;

            poolable.gameObject.SetActive(false);
            poolable.OnRelease();
            _pool.Enqueue(poolable);
        }
    }
}