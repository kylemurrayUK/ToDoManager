using System.ComponentModel.Design;

namespace ToDoManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoService toDoService = new ToDoService(FileStorage.LoadFile());
            Menu menu = new Menu(toDoService);
        }
    }
}