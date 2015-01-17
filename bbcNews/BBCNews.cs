﻿using NetNewsWindowsPluginDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbcNews
{
    class BBCNews : INews
    {
        public string NewsUrl
        {
            get;
            set;
        }

        public string Header
        {
            get;
            set;
        }

        public string News
        {
            get;
            set;
        }

        public string ImgUrl
        {
            get;
            set;
        }
    }
}