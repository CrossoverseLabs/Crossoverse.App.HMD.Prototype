namespace Crossoverse.HMDApp.Quest.Domain.FaceTracking
{
    public interface IFaceTrackingSystem
    {
        void Tick();
        bool TryDequeue(ref FaceTrackingData data);
    }
}