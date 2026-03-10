using System.ComponentModel;
using System.Data.Common;

namespace ToDoManager
{
    public class ToDoItem
    {
        public int id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public bool IsCompleted {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime? CompletedAt {get; set;}

        public ToDoItem(int iD,string title, string description)
        {
            id = iD;
            Title = title;
            Description = description;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
        }

    }
}