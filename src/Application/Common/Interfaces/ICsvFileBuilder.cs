using demo_ca_app.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace demo_ca_app.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
