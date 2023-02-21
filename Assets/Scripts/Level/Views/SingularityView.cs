using Utils.FactoryTool;

namespace Level.Views
{
    public class SingularityView : PoolableMonoBehaviour
    {
        public bool isActivate;

        public override void Dispose()
        {
            isActivate = false;
        }
    }
}