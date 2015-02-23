﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNewsWindowsPluginDomain
{
    public interface INewsPlugin
    {
        IEnumerable<Message> GetNews();
    }
}
