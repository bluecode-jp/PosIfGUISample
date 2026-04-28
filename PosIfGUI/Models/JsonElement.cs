//
// Copyright (c) 2025, 合同会社玉木栄三郎事務所.
// All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosIfGUI.Models
{
    // screenInfo 要素の定義
    public class JsonElement
    {
        public string VI { get; set; }
        public string VT { get; set; }
        public string VTX { get; set; }
        public string CD { get; set; }
        public bool EN { get; set; } = true; // ← デフォルト true
    }
}
