namespace ToDoManager
{
    class ToDoItem()
    {
        int id {get; set;}
        string Title {get; set;} = string.Empty;
        string Description {get; set;} = string.Empty;
        bool IsCompleted {get; set;}
        DateTime CreatedAt {get; set;}
        DateTime CompletedAt {get; set;}

    }
}