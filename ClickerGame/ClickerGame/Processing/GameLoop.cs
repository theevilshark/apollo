using System;
using System.Threading.Tasks;

namespace ClickerGame.Processing
{
    public class GameLoop
    {
        public delegate void TickHandler(decimal tickDuration);
        public event TickHandler Tick;

        private bool _enabled;
        private int _ticksPerSecond;

        public GameLoop(int ticksPerSecond)
        {
            _ticksPerSecond = ticksPerSecond;
        }

        public void Start() => Task.Run(() => Run());
        public void Stop() => _enabled = false;

        private void Run()
        {
            _enabled = true;
            while (_enabled)
            {
                var tickDurationInMilliseconds = 1000 / _ticksPerSecond;
                var tickDuration = tickDurationInMilliseconds / 1000m;
                // TODO This threw an object null reference, keep an eye on this, may need to shift logic.
                Tick(tickDuration);
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(tickDurationInMilliseconds));
            }
        }
    }
}
