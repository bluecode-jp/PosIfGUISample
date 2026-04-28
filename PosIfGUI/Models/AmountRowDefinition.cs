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
    // 金額エリア特殊扱い用の事前定義
    public class AmountRowDefinition
    {
        public string Key { get; set; } = "";
        public string LabelVI { get; set; } = "";
        public string ValueVI { get; set; } = "";
        public string UnitVI { get; set; }
        public bool LikeInput { get; set; } = false;
        public bool Highlight { get; set; } = false;
        public string Suffix { get; set; }
    }
}

