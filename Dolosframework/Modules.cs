namespace Dolosframework
{
    public abstract class Module
    {
        public bool Enabled = true;

        public void Update()
        {
            if (Enabled)
                this.OnUpdate();
        }

        protected virtual void OnUpdate()
        {
        }
    }
}