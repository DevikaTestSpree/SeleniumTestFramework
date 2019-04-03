using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTestFramework.Driver
{
    public interface IDriverConfiguration
    {
        string Browser { get; }
        string SeleniumServerAddress { get; }
        string CaptureLocation { get; }
        int TimeoutSeconds { get; }
        
    }
}
