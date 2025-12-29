namespace MomIsComing.Scripts
{
    public interface IPoolable
    {
        void OnCreated();
        void OnGet();
        void OnRelease();
    }
}