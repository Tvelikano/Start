using System;

namespace Start
{
    [Serializable]
    public class Record
    {
        public Record()
        {
            
        }
        public Record(string head, string content)
        {
            Head = head;
            Content = content;
            CreateDate = DateTime.Now;
        }
        public string Head { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
