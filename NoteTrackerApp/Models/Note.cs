using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTrackerApp.Models
{
    public class Note
    {
       
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
    }
}
