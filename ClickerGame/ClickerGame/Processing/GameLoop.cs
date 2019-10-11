using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame.Processing
{
    public class GameLoop
    {
        public delegate void TickHandler();
        public event TickHandler Tick;

        private bool _enabled;
        private double _ticksPerSecond;

        public GameLoop(double ticksPerSecond)
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
                Tick(); // TODO This threw an object null reference, keep an eye on this, may need to shift logic.
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(1000 / _ticksPerSecond));
            }
        }
    }
}