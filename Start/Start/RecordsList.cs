using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Start
{
    [Serializable]
    public class RecordList
    {
        public List<Record> list;

        public RecordList()
        {
            list = new List<Record>();
        }
    }
}
